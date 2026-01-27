using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 10.0f;
    public float rotationSpeed = 10f; // how fast the player rotates
    public float xRange = 15.0f;
    public float zMin;
    public float zMax;
    public Transform projectileSpawnPoint;

    public GameObject projectilePrefab;

    void Update()
    {
        // --- Movement ---
        horizontalInput = Input.GetAxis("Horizontal");
        CsvLogger.LogEvent("Player", "Moves Down or Up");
        verticalInput = Input.GetAxis("Vertical");
        CsvLogger.LogEvent("Player", "Move Left or Right");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            // Move the player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

            // Rotate to face movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        // --- Clamp position ---
        float clampedX = Mathf.Clamp(transform.position.x, -xRange, xRange);
        float clampedZ = Mathf.Clamp(transform.position.z, -zMin, zMax);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(
                projectilePrefab,
                projectileSpawnPoint.position,
                projectileSpawnPoint.rotation
            );

            CsvLogger.LogEvent("Player", "Shoot");
        }

    }
}