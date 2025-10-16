using UnityEngine;

public class PullProjectile : MonoBehaviour
{
    public float speed = 25f;
    public float lifetime = 5f;
    public Vector3 holdOffset = new Vector3(0, -0.5f, 2f);

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            
            Vector3 holdPosition = player.position + player.transform.TransformDirection(holdOffset);
            other.transform.position = holdPosition;

            
            other.transform.SetParent(player);

            
            if (other.TryGetComponent<Rigidbody>(out Rigidbody rb))
            {
                rb.linearVelocity = Vector3.zero;     
                rb.angularVelocity = Vector3.zero;    
                rb.isKinematic = true;
            }

           
            if (other.TryGetComponent<AnimalMovement>(out AnimalMovement moveScript))
                moveScript.enabled = false;

            
            Destroy(gameObject);
        }
    }
}
