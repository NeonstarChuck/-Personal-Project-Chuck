using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created¨

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime = 60f;
    private bool timerActive = false;

    [HideInInspector]
    public GameManager gameManager;

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (!timerActive) return;

        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            if (remainingTime <= 10f && timerText != null)
            timerText.color = Color.red;
            
            if (remainingTime < 0) remainingTime = 0;
            
        }
        else
        {
            timerActive = false;
            
            NoTime();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

     public void StartTimer(float seconds)
    {
        remainingTime = seconds;
        timerActive = true;
    }

    private void NoTime()
    {
        if (gameManager != null)
            gameManager.TimeIsOver();
    }
}
