using UnityEngine;

public class DestroyObjectTime : MonoBehaviour
{
    public float deleteTime = 5;
    private float execTime = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        execTime = Time.time + deleteTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > execTime) {
            Destroy(gameObject);
        }
    }
}
