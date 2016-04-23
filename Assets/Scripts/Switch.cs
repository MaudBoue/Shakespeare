using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour
{
//    private bool IsSwitch = false;
    public Camera mainCamera;
    public Camera fpsCamera;

    // Use this for initialization
    void Start()
    {

        mainCamera.enabled = true;
        fpsCamera.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown (KeyCode.V))   
        {
            if (fpsCamera.enabled == false)
            {
                fpsCamera.enabled = true;
            }

            else
            {
                fpsCamera.enabled = false;
            }
            
        }
    }
}