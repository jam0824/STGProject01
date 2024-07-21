using UnityEngine;

public class Warning : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //‰¹‚ð–Â‚ç‚·‚¾‚¯
        SoundManager.Instance.PlaySE(GameConstants.SE_WARNING);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
