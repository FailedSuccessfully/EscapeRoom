using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class PlayerCamera : MonoBehaviour
{
    public Camera unityCamera;
    public float sensitivity;
    public float smoothing;
    private Vector2 smoothedVelocity;
    private Vector2 currentLookingPos;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        unityCamera = GetComponent<Camera>();
    }

    void Update()
    {
        if (!Cursor.visible)
            RotateCamera();
    }

    private void RotateCamera()
    {
        Vector2 values = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        values = Vector2.Scale(values, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

        smoothedVelocity.x = Mathf.Lerp(smoothedVelocity.x, values.x, 1f / smoothing);
        smoothedVelocity.y = Mathf.Lerp(smoothedVelocity.y, values.y, 1f / smoothing);

        currentLookingPos += smoothedVelocity;

        transform.localRotation = Quaternion.AngleAxis(-currentLookingPos.y, Vector3.right);

        GameManager.player.transform.localRotation = Quaternion.AngleAxis(currentLookingPos.x, GameManager.player.transform.up);
    }

    public void ToggleLock(){
        Rigidbody rb = GameManager.player.GetComponent<Rigidbody>();
        rb.constraints = rb.constraints == RigidbodyConstraints.FreezeRotation ? RigidbodyConstraints.FreezeAll : RigidbodyConstraints.FreezeRotation;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = !Cursor.visible;
    }
}

