using UnityEngine;

public class MagnetMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float zLimit;
    private float movementSpeed;

    void Start()
    {
        zLimit = Camera.main.transform.position.z;
        movementSpeed = 30f;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.back * movementSpeed * Time.fixedDeltaTime);

        if (transform.position.z < zLimit + 2)
        {
            Destroy(gameObject);
        }
    }
}
