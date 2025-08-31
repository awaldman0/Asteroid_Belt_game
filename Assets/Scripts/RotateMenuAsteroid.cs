using UnityEngine;

public class RotateMenuAsteroid : MonoBehaviour
{
    public float rotationSpeed;
    private Vector3 rotationDirection;
    void Start()
    {
        rotationDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    void Update()
    {
        transform.Rotate(rotationDirection * Time.fixedDeltaTime * rotationSpeed);
    }
}
