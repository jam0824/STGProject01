using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    private PlayerAction action;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject obj = GameObject.Find("PlayerManager");
        action = obj.GetComponent<PlayerAction>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //“G‚Ì’e‚É“–‚½‚Á‚½ŽžŒÄ‚Î‚ê‚é
    private void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "EnemyBullet") {
            action.HitEnemyBullet(collision);
        }
    }
 
}
