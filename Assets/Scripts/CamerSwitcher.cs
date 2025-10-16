using UnityEngine;

public class CamerSwitcher : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey = KeyCode.F;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(switchKey)){

            mainCamera.enabled =!mainCamera.enabled;
            hoodCamera.enabled =!hoodCamera.enabled;
            
            //If !main or !hood is not enabled, then enable the following camera.
        }
        
    }
}
