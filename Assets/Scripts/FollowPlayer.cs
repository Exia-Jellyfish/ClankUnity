using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 400f;
    private float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = playerBody.transform.position;

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSensitivity;

        if (!PauseMenu.GameIsPaused)
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        if (Input.GetMouseButtonDown(1))
        {
            Camera.main.fieldOfView /= 3;
            mouseSensitivity /= 2;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            Camera.main.fieldOfView *= 3;
            mouseSensitivity *= 2;
        }
    }
}