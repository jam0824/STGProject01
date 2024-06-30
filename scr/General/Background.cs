using UnityEngine;

public class Background : MonoBehaviour
{
    public float BgSpeed = 0.01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        pos.z += BgSpeed;
        this.transform.position = pos;
    }
}
