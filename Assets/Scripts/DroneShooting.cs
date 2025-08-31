using UnityEngine;
using System.Collections;

public class DroneShooting : MonoBehaviour
{
    public float shootingTime;
    public GameObject laser;
    private float t;
    private Quaternion laserRotation = new Quaternion(0, 0, 0, 1) * Quaternion.Euler(90, 0, 0);
    private AudioSource a;
    bool firstShot = true;

    void Start()
    {
        StartCoroutine(ShootLaser());
        a = GetComponent<AudioSource>();
    }

    private IEnumerator ShootLaser()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootingTime);
            a.Play();
            Instantiate(laser, transform.position, laserRotation);
        }
    }
}
