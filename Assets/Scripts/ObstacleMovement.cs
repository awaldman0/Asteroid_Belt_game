using UnityEngine;
using UnityEngine.UIElements;

public class ObstacleMovement : MonoBehaviour
{
    private float rotationSpeed;
    private float movementSpeed;
    private Rigidbody rb;
    private float zLimit;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        zLimit = Camera.main.transform.position.z;
        movementSpeed = UnityEngine.Random.Range(40f, 90f);
        rotationSpeed = UnityEngine.Random.Range(0f, 60f);
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.back * movementSpeed * Time.fixedDeltaTime);
        transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotationSpeed);

        if (transform.position.z < zLimit + 2)
        {
            Destroy(gameObject);
        }
    }
}
