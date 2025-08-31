using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public float cooldownTime;
    public GameObject laser;
    private float t;
    private Quaternion laserRotation = new Quaternion(0, 0, 0, 1) * Quaternion.Euler(90, 0, 0);
    private GameObject parent;
    private AudioSource a;
    private PlayerInput pi;
    public InputActionReference iar;


    void Start()
    {
        a = GetComponent<AudioSource>();
        parent = transform.parent.gameObject;
    }

    void Update()
    {
        if (parent.TryGetComponent<PlayerMovement>(out var pm))
        {
            int ammo_count = pm.GetCurrAmmo();
            if (t > 0)
            {
                t -= Time.deltaTime;
            }
            else if ((Input.GetKey(KeyCode.J)) && ammo_count > 0)
            {
                var laserPos = transform.TransformPoint(Vector3.forward * 1f);
                Instantiate(laser, laserPos, laserRotation);
                a.Play();
                t = cooldownTime;
                pm.SetCurrAmmo(ammo_count - 1);
            }
        }
    }

    public void touch()
    {
        if (parent.TryGetComponent<PlayerMovement>(out var pm))
        {
            int ammo_count = pm.GetCurrAmmo();
            if (t > 0)
            {
                t -= Time.deltaTime;
            }
            else if (ammo_count > 0)
            {
                var laserPos = transform.TransformPoint(Vector3.forward * 1f);
                Instantiate(laser, laserPos, laserRotation);
                a.Play();
                t = cooldownTime;
                pm.SetCurrAmmo(ammo_count - 1);
            }
        }
    }

}
