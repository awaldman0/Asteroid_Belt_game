using UnityEngine;

public class DroneManager : MonoBehaviour
{
    private GameObject player;
    public GameObject drone;
    private int droneCount;
    private float[,] dronePositions = {{1.5f, 1.5f}, {-1.5f, 1.5f}, {1.5f, -1.5f}, {-1.5f, -1.5f}};
    private bool[] droneDeployed = {false, false, false, false};
    void Start()
    {
        player = GameObject.Find("SpaceshipCollider");
        droneCount = 0;
    }

    public void deployDrone()
    {
        if (droneCount >= 4)
        {
            return;
        }
        for (int i = 0; i < droneDeployed.Length; i++)
        {
            if (droneDeployed[i] == false)
            {
                Vector3 vec = player.transform.position;
                GameObject d = Instantiate(drone, vec, new Quaternion(0, 0, 0, 1) * Quaternion.Euler(0, 0, 0));
                var dm = d.GetComponent<DroneMovement>();
                dm.xoffset = dronePositions[i, 0];
                dm.yoffset = dronePositions[i, 1];
                droneDeployed[i] = true;
                break;
            }
        }
        droneCount++;
    }

    public void removeDrone(float dronex, float droney, float playerx, float playery)
    {
        if (dronex > playerx && droney > playery)
        {
            droneDeployed[0] = false;
        }
        else if (dronex < playerx && droney > playery)
        {
            droneDeployed[1] = false;
        }
        else if (dronex > playerx && droney < playery)
        {
            droneDeployed[2] = false;
        } else
        {
            droneDeployed[3] = false;
        }
        droneCount--;
    }
}
