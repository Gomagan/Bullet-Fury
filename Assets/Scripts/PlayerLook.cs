using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;
    public Vector2 sensitivity;
    
    private Vector2 _mouseLook; //xyRotation Swap
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2
        {
            x = Input.GetAxis("Mouse X"),
            y = Input.GetAxis("Mouse Y")
        };
        
        _mouseLook.x -= mouseInput.y * sensitivity.y;
        _mouseLook.y += mouseInput.x * sensitivity.x;
        
        _mouseLook.x = Mathf.Clamp(_mouseLook.x, -90f, 90f);
        
        transform.eulerAngles = new Vector3(0f, _mouseLook.y, 0f);
        playerCamera.localEulerAngles = new Vector3(_mouseLook.x, 0f, 0f);
    }
}
