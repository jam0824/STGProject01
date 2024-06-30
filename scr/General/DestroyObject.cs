using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private float LEFT_MAX = -8.0f;
    private float RIGHT_MAX = 8.0f;
    private float TOP_MAX = 5.0f;
    private float BOTTOM_MAX = -5.0f;

    private void Update() {
        if ((this.gameObject.transform.position.x < LEFT_MAX )|| 
            (this.gameObject.transform.position.x > RIGHT_MAX)||
            (this.gameObject.transform.position.z > TOP_MAX) ||
            (this.gameObject.transform.position.z < BOTTOM_MAX)
            ) {
            //“G’e‚¾‚Á‚½‚çŠÇ—‚©‚ç“G’e‚ðŒ¸‚ç‚·
            if (this.gameObject.tag == "EnemyBullet") GameManager.Instance.CalcBulletNum(-1);
            
            GameObject.Destroy(gameObject);
        }
    }
}
