using UnityEngine;

public class DroneTilting : MonoBehaviour
{
    private GameObject player;
    void Start()
    {
        player = GameObject.Find("SpaceshipVisual");
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.transform.rotation * Quaternion.Euler(-90, 0, 0);
    }
}
