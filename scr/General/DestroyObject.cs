using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    private void Update() {
        if ((this.gameObject.transform.position.x < -GameManager.Instance.RIGHT_LEFT) || 
            (this.gameObject.transform.position.x > GameManager.Instance.RIGHT_LEFT) ||
            (this.gameObject.transform.position.z > GameManager.Instance.TOP_BOTTOM) ||
            (this.gameObject.transform.position.z < -GameManager.Instance.TOP_BOTTOM)
            ) {
            //“G’e‚¾‚Á‚½‚çŠÇ—‚©‚ç“G’e‚ðŒ¸‚ç‚·
            if (this.gameObject.tag == "EnemyBullet") GameManager.Instance.CalcBulletNum(-1);
            
            GameObject.Destroy(gameObject);
        }
    }
}
