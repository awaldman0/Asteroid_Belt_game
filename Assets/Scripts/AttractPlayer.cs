using Unity.VisualScripting;
using UnityEngine;

public class AttractPlayer : MonoBehaviour
{
    private GameObject player;
    private CharacterController c;
    Vector3 vecFromPlayer;
    private float dist;
    public float distUpperThreshold;
    public float magnetismScalar;
    void Start()
    {
        player = GameObject.Find("SpaceshipCollider");
        c = player.GetComponent<CharacterController>();
    }

    void Update()
    {
        vecFromPlayer = transform.position - player.transform.position;
        dist = vecFromPlayer.magnitude;
        vecFromPlayer.z = 0;
        vecFromPlayer.Normalize();
        //sort of an inverse square law for magnetic attraction
        Vector3 movement = vecFromPlayer * (1 / dist * dist);
        if (dist > distUpperThreshold)
        {
            movement = new Vector3(0, 0, 0);
        } else if (Mathf.Abs(transform.position.x - player.transform.position.x) < 0.5 &&
            Mathf.Abs(transform.position.y - player.transform.position.y) < 0.5)
        {
            movement = new Vector3(0, 0, 0);
        }
        c.Move(movement * magnetismScalar * Time.deltaTime);
    }
}
