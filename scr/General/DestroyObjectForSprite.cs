using UnityEngine;

public class DestroyObjectForSprite : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //基本アニメーションから呼ぶ
    public void DestroyObject() {
        Destroy(gameObject);
    }
}
