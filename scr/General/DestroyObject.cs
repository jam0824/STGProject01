using UnityEngine;

public class DestroyObject : MonoBehaviour
{

    private void Update() {
        if ((this.gameObject.transform.position.x < -GameManager.Instance.RIGHT_LEFT) || 
            (this.gameObject.transform.position.x > GameManager.Instance.RIGHT_LEFT) ||
            (this.gameObject.transform.position.z > GameManager.Instance.TOP_BOTTOM) ||
            (this.gameObject.transform.position.z < -GameManager.Instance.TOP_BOTTOM)
            ) {
            //�G�e��������Ǘ�����G�e�����炷
            if (this.gameObject.tag == "EnemyBullet") GameManager.Instance.CalcBulletNum(-1);
            
            GameObject.Destroy(gameObject);
        }
    }
}
