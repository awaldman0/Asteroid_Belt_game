using UnityEngine;

public class LaserLogic : MonoBehaviour
{
    public float speed;
    public float lifetime;
    private float timeLived;
    public GameObject explosion;
    bool destory = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLived = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        timeLived += Time.deltaTime;
        if (timeLived > lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
            var e = Instantiate(explosion, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
            Destroy(gameObject);
            Destroy(e, 1.2f);
        }
    }
}
