using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scrollSpeed = GameObject.Find("StageManager").GetComponent<StageManager>().scrollSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scrollSpeed == null) return;
        Vector3 pos = this.transform.position;
        pos.z -= scrollSpeed;
        this.transform.position = pos;
    }
}
