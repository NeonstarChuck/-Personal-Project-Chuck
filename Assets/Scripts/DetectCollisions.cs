using UnityEngine;
using UnityEngine.UI; // Needed for UI Text
using TMPro;


public class DetectCollisions : MonoBehaviour
{
    private static int destroyCount = 0;
    public TMP_Text counterText;

    private void Start()
    {
        if (counterText != null)
        {
            counterText.text = "Destroyed: 0";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
        else
        {
            destroyCount++;

            if (counterText != null)
            {
                counterText.text = "Destroyed: " + destroyCount;
            }

            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}
