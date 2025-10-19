using UnityEngine;

public class Information : MonoBehaviour
{
    public GameObject infoPanel; // Assign your InfoPanel in the Inspector

    // Call this from the "Show Info" button
    public void ShowPanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(true);
    }

    // Call this from the "Close" button inside the panel
    public void HidePanel()
    {
        if (infoPanel != null)
            infoPanel.SetActive(false);
    }
}
