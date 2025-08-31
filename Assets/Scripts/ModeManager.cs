using UnityEngine;

public class ModeManager : MonoBehaviour
{
    public static ModeManager Instance;
    public float timeLimit = 60f;
    public float asteroidSpawnRate = 0.18f;
    public float[] itemSpawnRates = { 3f, 4f, 5f };
    public int playerHealth = 5;
    public int playerAmmo = 50;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SelectNormalMode()
    {
        float[] x = { 3f, 4f, 5f };
        timeLimit = 60f;
        asteroidSpawnRate = 0.18f;
        itemSpawnRates = x;
        playerHealth = 5;
        playerAmmo = 50;
}
    public void SelectHardMode()
    {
        float[] x = { 5f, 6f, 7f };
        timeLimit = 90f;
        asteroidSpawnRate = 0.13f;
        itemSpawnRates = x;
        playerHealth = 3;
        playerAmmo = 35;

    }

    public void SelectInfiniteMode()
    {
        float[] x = { 3f, 4f, 5f };
        timeLimit = float.MaxValue;
        asteroidSpawnRate = 0.18f;
        itemSpawnRates = x;
        playerHealth = 5;
        playerAmmo = 50;
    }

    public float[] GetItemSpawnRates()
    {
        return itemSpawnRates;
    }

    public float GetTimeLimit()
    {
        return timeLimit;
    }

    public float GetAsteroidSpawnRate() 
    { 
        return asteroidSpawnRate; 
    }

    public int GetPlayerHealth()
    {
        return playerHealth;
    }

    public int GetPlayerAmmo()
    {
        return playerAmmo;
    }
}
