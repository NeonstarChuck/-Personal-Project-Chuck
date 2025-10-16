using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float turnSpeed = 50f;
    public float changeDirectionTime = 3f;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;


        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        transform.Rotate(Vector3.up * turnSpeed * Time.deltaTime);

       
        if (timer >= changeDirectionTime)
        {
            turnSpeed = Random.Range(-80f, 80f);
            timer = 0;
        }
    }
}
