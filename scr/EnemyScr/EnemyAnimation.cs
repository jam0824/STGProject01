using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quaternion EnemyRotation(Vector3 direction) {
       return Quaternion.LookRotation(direction);
    }
}
