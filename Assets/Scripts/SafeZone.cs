using UnityEngine;

public class SafeZone : MonoBehaviour
{
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        // Only act on animals
        if (other.CompareTag("Animal"))
        {
            if (gameManager != null)
                gameManager.AnimalRescued();

            Destroy(other.gameObject); // only destroy the animal
        }
    }
}
