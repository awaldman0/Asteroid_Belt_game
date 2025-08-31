using UnityEngine;
using TMPro;

public class HealthHUD : MonoBehaviour
{
    private GameObject player;
    private TMP_Text txt;
    void Start()
    {
        player = GameObject.Find("SpaceshipCollider");
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.TryGetComponent<PlayerMovement>(out var pm))
        {
            //display heart count
            int currHealth = pm.GetCurrHealth();
            txt.text = "Hearts: " + currHealth;
        }
    }
}
