using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_camera : MonoBehaviour
{   
    public float sensitivity = 100f;
    public Transform playerBody;
    public GameObject pause;
    float xRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        pause.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 0)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                pause.SetActive(false);
            } else
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                pause.SetActive(true);
            }
        }
        
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")* sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
