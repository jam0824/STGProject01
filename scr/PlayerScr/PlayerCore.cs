using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private PlayerAction action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = transform.parent.gameObject;
        action = obj.GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {       
        if (collision.gameObject.tag == "EnemyBullet") {
            action.HitEnemyBullet(collision);
        }
    }
}
