using UnityEngine;

public class DestroyParent : MonoBehaviour
{

    private float lifetime = 30;
    private float currTime = 0;

    // Update is called once per frame
    void Update()
    {
        currTime += Time.deltaTime;
        if (currTime >= lifetime)
        {
            Destroy(gameObject);
        }
    }
}
