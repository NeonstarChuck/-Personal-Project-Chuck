using UnityEngine;
using UnityEngine.AI;
using System.Linq; // for easy nearest-target lookup

public class NavigationScript : MonoBehaviour
{
    [Header("Targets")]
    public Transform player;
    public string animalTag = "Animal";

    [Header("Attack Settings")]
    public float damage = 10f;
    public float attackCooldown = 1f;
    private float lastAttackTime;

    [Header("Navigation Settings")]
    public float checkInterval = 1f; // how often to find new target
    private NavMeshAgent agent;
    private Transform currentTarget;
    private float timer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = player; // fallback target
    }

    void Update()
    {
        // periodically find closest animal
        timer += Time.deltaTime;
        if (timer >= checkInterval)
        {
            timer = 0f;
            FindClosestAnimal();
        }

        // move toward target
        if (currentTarget != null)
            agent.destination = currentTarget.position;
    }

    void FindClosestAnimal()
    {
        GameObject[] animals = GameObject.FindGameObjectsWithTag(animalTag);

        if (animals.Length == 0)
        {
            currentTarget = player;
            return;
        }

        // find the nearest animal
        GameObject closest = animals
            .OrderBy(a => Vector3.Distance(transform.position, a.transform.position))
            .FirstOrDefault();

        currentTarget = closest != null ? closest.transform : player;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // only damage animals
        if (collision.gameObject.CompareTag(animalTag))
        {
            if (Time.time - lastAttackTime >= attackCooldown)
            {
                AnimalHealth animal = collision.gameObject.GetComponent<AnimalHealth>();
                if (animal != null)
                {
                    animal.TakeDamage(damage);
                }

                lastAttackTime = Time.time;
            }
        }
    }
}
