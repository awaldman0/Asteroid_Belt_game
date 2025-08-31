using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerTilting : MonoBehaviour
{
    float xInput;
    float yInput;
    public float rotationSpeed;
    public float rotationLimitX;
    public float rotationLimitY;
    public float recoverySpeed;
    public InputActionReference iar;


    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            xInput = Input.GetAxis("Horizontal");
        }
        else
        {
            Vector2 m = iar.action.ReadValue<Vector2>();
            xInput = m.x;
        }
        float currXAngle = transform.eulerAngles.z;
        if (currXAngle > 180)
        {
            currXAngle -= 360;
        }
        if (xInput < 0 && currXAngle < rotationLimitX)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
        }
        else if (xInput > 0 && currXAngle > -1 * rotationLimitX)
        {
            transform.Rotate(Vector3.back * Time.deltaTime * rotationSpeed);
        }


        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            yInput = Input.GetAxis("Vertical");
        }
        else
        {
            Vector2 m = iar.action.ReadValue<Vector2>();
            yInput = m.y;
        }
        float currYAngle = transform.eulerAngles.x;
        if (currYAngle > 180)
        {
            currYAngle -= 360;
        }
        if (yInput < 0 && currYAngle < rotationLimitY)
        {
            transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        }
        else if (yInput > 0 && currYAngle > -1 * rotationLimitY)
        {
            transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
        }

        if (xInput == 0 && yInput == 0) {
            Quaternion defaultRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, Time.deltaTime * rotationSpeed / recoverySpeed);
        } 
        else if (xInput == 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.eulerAngles.x, 0, 0), Time.deltaTime * rotationSpeed / recoverySpeed);
        }
        else if (yInput == 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, transform.eulerAngles.z), Time.deltaTime * rotationSpeed / recoverySpeed);
        }
    }
}
