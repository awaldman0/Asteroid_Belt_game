using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Spawner : MonoBehaviour
{
    public GameObject[] obstacles;
    private float spawnRate;
    private float[] powerupRates;
    private float currPowerupRate;
    public float magnetRate;
    public float minScl;
    public float maxScl;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    public float Z;
    public float Zoffset;
    private float timeLimit;
    private bool coroutinesStopped;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (ModeManager.Instance != null)
        {
            spawnRate = ModeManager.Instance.GetAsteroidSpawnRate();
            powerupRates = ModeManager.Instance.GetItemSpawnRates();
            timeLimit = ModeManager.Instance.GetTimeLimit();
        }
        currPowerupRate = powerupRates[0];
        StartCoroutine(SpawnAsteroids());
        StartCoroutine(SpawnPowerUps());
        StartCoroutine(SpawnMagnet());
        coroutinesStopped = false;
    }

    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit < 0 && coroutinesStopped == false)
        {
            StopAllCoroutines();
            coroutinesStopped = true;
        } else if (timeLimit < -22.5)
        {
            //if you outlast the asteroids, you win
            SceneManager.LoadSceneAsync("WinScreen");
        }
    }

    private IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject obstacle;
            Quaternion obstacleRotation;
            Vector3 obstaclePos;
            int r = UnityEngine.Random.Range(0, 100);
            if (r > 4) //95% chance of spawing asteroid
            {
                obstacle = obstacles[Random.Range(0, 8)];
            }
            else //5% chance of spawning car, cone, or soccer ball
            {
                obstacle = obstacles[Random.Range(8, 11)];
            }  
            //choose obstacle asset from array and instantiate it with random posistion and scale
            obstacleRotation = new Quaternion(0, 0, 0, Random.Range(minScl, maxScl))
            * Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
            obstaclePos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(Z, Z + Zoffset));
            Instantiate(obstacle, obstaclePos, obstacleRotation);

        }
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(currPowerupRate);
            GameObject obstacle;
            float r = UnityEngine.Random.Range(0f, 10f);
            if (r > 6.5) //35% chance of spawning heart
            {
                obstacle= obstacles[13];
            } 
            else if (r > 3) //35% chance of spawning ammo
            {
                obstacle = obstacles[14];
            }
            else //30% chance of spawning drone
            {
                obstacle = obstacles[15];
            }
            Quaternion obstacleRotation = new Quaternion(0, 0, 0, 1) * Quaternion.Euler(0, 0, 0);
            Vector3 obstaclePos = new Vector3(Random.Range(-9, 9), Random.Range(1, 10), Z - 10);
            Instantiate(obstacle, obstaclePos, obstacleRotation);
            currPowerupRate = powerupRates[Random.Range(0, powerupRates.Length)];
        }
    }
    private IEnumerator SpawnMagnet()
    {
        while (true)
        {
            yield return new WaitForSeconds(magnetRate);
            GameObject obstacle = obstacles[12];
            Quaternion obstacleRotation = new Quaternion(0, 0, 0, 100) * Quaternion.Euler(-90, 0, 0);
            Vector3 obstaclePos = new Vector3(Random.Range(-9, 9), Random.Range(1, 10), Random.Range(Z, Z - 10));
            GameObject x = Instantiate(obstacle, obstaclePos, obstacleRotation);
            x.transform.localScale = new Vector3(220, 220, 220);
        }
    }
}
