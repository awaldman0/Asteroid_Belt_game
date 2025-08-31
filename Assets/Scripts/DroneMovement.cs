using UnityEngine;

public class DroneMovement : MonoBehaviour
{
    private GameObject player;
    public float xoffset;
    public float yoffset;
    private GameObject droneManager;
    public GameObject miniExplosion;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("SpaceshipCollider");
        droneManager = GameObject.Find("droneManager");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(xoffset, yoffset, 0);
        transform.position = offset + player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            if (droneManager.TryGetComponent<DroneManager>(out var d))
            {
                d.removeDrone(transform.position.x, transform.position.y, player.transform.position.x, player.transform.position.y);
            }
            Vector3 t = transform.position;
            Destroy(gameObject);
            var e = Instantiate(miniExplosion, t, Quaternion.Euler(0, 0, 0));
            Destroy(e, 1.2f);
        }
    }
}
