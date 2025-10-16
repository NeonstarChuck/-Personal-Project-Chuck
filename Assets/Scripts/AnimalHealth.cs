using UnityEngine;

public class AnimalHealth : MonoBehaviour
{
    public float maxHealth = 20f;
    private float currentHealth;

     [HideInInspector]
    public GameManager gameManager;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Notify GameManager
        if (gameManager != null)
        {
            gameManager.AnimalDead();
        }

        // Destroy animal
        Destroy(gameObject);
    }
}

