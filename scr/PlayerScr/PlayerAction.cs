using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    private bool isShooting = false; // ���˒����ǂ����̃t���O
    private float nextFireTime = 0f; // ���ɒe�𔭎˂ł��鎞��

    PlayerConfig config;
    

    private void Start() {
        config = GetComponent<PlayerConfig>();
    }

    public void PlayerMove(Vector3 movement) {
        if (movement == Vector3.zero) return;
        Vector3 pos = this.transform.position;
        pos.x += movement.x * config.mvVelocity;
        pos.z += movement.z * config.mvVelocity;
        this.transform.position = pos;
    }

    public void ShootStart() {
        if (!isShooting) {
            StartCoroutine(Shoot());
        }
    }
    public void SetIsShooting(bool flag) {
        isShooting = flag;
    }
    IEnumerator Shoot() {
        isShooting = true;
        while (isShooting) {
            if (Time.time >= nextFireTime) {
                nextFireTime = Time.time + config.fireRate;
                Instantiate(config.bulletPrefab, config.firePoint.position, config.firePoint.rotation);
            }
            yield return null; // �t���[�����ƂɃ`�F�b�N���s��
        }
    }

    public void HitEnemyBullet(Collision collision) {
        Debug.Log("EnemyBulletHit!!!!!!!!!!!!!!!!!!");
        DeleteEnemyBullet(collision.gameObject);
    }

    private void DeleteEnemyBullet(GameObject obj) {
        GameManager.Instance.CalcBulletNum(-1);
        Destroy(obj);
    }

}
