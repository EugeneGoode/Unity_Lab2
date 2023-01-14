using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensX;
    public float sensY;
    public Transform orientation;

    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float yInput = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        yRotation += xInput;
        xRotation -= yInput;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

    }
}
