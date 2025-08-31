using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float camShakeTime;
    private int playerHealth;
    private int playerAmmo;
    private int currHealth;
    private int currAmmo;
    CharacterController c;
    public GameObject explosion;
    public GameObject ammoPowerup;
    public GameObject heartPowerup;
    public GameObject dronePowerup;
    private GameObject droneManager;
    private GameObject camera;
    private AudioSource a;
    public AudioClip[] clips;
    public InputActionReference iar;

    void Start()
    {
        if (ModeManager.Instance != null)
        {
            playerAmmo = ModeManager.Instance.GetPlayerAmmo();  
            playerHealth = ModeManager.Instance.GetPlayerHealth();
        }
        currHealth = playerHealth;
        currAmmo = playerAmmo;
        c = GetComponent<CharacterController>();
        a = GetComponent<AudioSource>();
        droneManager = GameObject.Find("droneManager");
        camera = GameObject.Find("Main Camera");
    }

    void Update()
    {
        Vector3 movementVec;
        if (Application.platform == RuntimePlatform.WindowsPlayer)
        {
            movementVec = new Vector3(Input.GetAxis("Horizontal"), 0, 0) + new Vector3(0, Input.GetAxis("Vertical"), 0);
        } else
        {
            Vector2 m = iar.action.ReadValue<Vector2>();
            movementVec = new Vector3(m.x, 0, 0) + new Vector3(0, m.y, 0);
        }
        c.Move(movementVec * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            currHealth -= 1;
            if (currHealth <= 0)
            {
                //load lose screen
                a.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                SceneManager.LoadSceneAsync("LoseScreen");

            } 
            else
            {
                Vector3 t = other.gameObject.transform.position;
                Destroy(other.gameObject);
                var e = Instantiate(explosion, t, Quaternion.Euler(0, 0, 0));
                //play explosion sound
                a.PlayOneShot(clips[Random.Range(0, clips.Length)]);
                //do camera shake 
                if (camera.TryGetComponent<CameraShake>(out var cs))
                {
                    cs.shakeTime = camShakeTime;
                }
                Destroy(e, 1.2f);
            }
        } else if (other.gameObject.layer == 8)
        {
            if (other.gameObject.tag == "ammo")
            {
                currAmmo += 10;
                var a = Instantiate(ammoPowerup, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(a, 1.2f);
            } 
            else if (other.gameObject.tag == "heart")
            {
                currHealth += 1;
                var b = Instantiate(heartPowerup, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(b, 1.2f);
            } 
            else
            {
                var c = Instantiate(dronePowerup, other.gameObject.transform.position, Quaternion.Euler(0, 0, 0));
                Destroy(c, 1.2f);
                if (droneManager.TryGetComponent<DroneManager>(out var d))
                {
                    d.deployDrone();
                }
            }
            Destroy(other.gameObject);
        }
    }

    public int GetCurrAmmo()
    {
        return currAmmo;
    }

    public int GetCurrHealth()
    {
        return currHealth;
    }

    public void SetCurrAmmo(int x)
    {
        currAmmo = x;
    }
}
