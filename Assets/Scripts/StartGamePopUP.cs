using UnityEngine;

public class StartGamePopUP : MonoBehaviour
{
    public GameObject p;
    void Start()
    {
        var txt = Instantiate(p, transform);
        Destroy(txt, 5f);
    }
}
