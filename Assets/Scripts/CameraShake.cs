using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 pos;
    public float shakeTime = 0f;
    public float shakeIntensity;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTime > 0)
        {
            transform.position = pos + (Random.insideUnitSphere * shakeIntensity * Mathf.Sqrt(shakeTime));
            shakeTime -= Time.deltaTime;
        } else
        {
            shakeTime = 0f;
            transform.position = pos;
        }
    }
}
