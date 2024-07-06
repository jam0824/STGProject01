using UnityEngine;
using System.Collections;

public class PlayerAction : MonoBehaviour
{
    private bool isShooting = false; // 発射中かどうかのフラグ
    private float nextFireTime = 0f; // 次に弾を発射できる時間

    // 無敵時間の秒数
    public float invincibilityDuration = 2.0f;
    // 点滅する間隔
    public float blinkInterval = 0.1f;
    private bool isMeshRendererEnable = true;

    PlayerManager playerManager;


    private void Start() {
        playerManager = GetComponent<PlayerManager>();
        
    }

    public Vector3 PlayerMove(GameObject gameObject, Vector3 movement, float velocity) {
        if (movement == Vector3.zero) return gameObject.transform.position;

        Vector3 pos = gameObject.transform.position;
        pos.x += movement.x * velocity;
        pos.z += movement.z * velocity;
        return FixPos(pos);
    }

    Vector3 FixPos(Vector3 pos) {
        if (pos.x < -GameManager.Instance.RIGHT_LEFT) pos.x = -GameManager.Instance.RIGHT_LEFT;
        if (pos.x > GameManager.Instance.RIGHT_LEFT) pos.x = GameManager.Instance.RIGHT_LEFT;
        if (pos.z < -GameManager.Instance.TOP_BOTTOM) pos.z = -GameManager.Instance.TOP_BOTTOM;
        if (pos.z > GameManager.Instance.TOP_BOTTOM) pos.z = GameManager.Instance.TOP_BOTTOM;
        return pos;
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
                nextFireTime = Time.time + playerManager.fireRate;
                Shoot(playerManager.bulletPrefab, 
                    playerManager.firePoint.transform, 
                    playerManager.GetNumberOfBullet(),
                    playerManager.GetNumberOfBullet() * 5);
                
            }
            yield return null; // フレームごとにチェックを行う
        }
    }

    public void Shoot(
        GameObject bulletPrefab,
        Transform fireTransform,
        int numberOfBullets,
        float spreadAngle) {

        if(numberOfBullets == 1) {
            Instantiate(playerManager.bulletPrefab, playerManager.firePoint.position, playerManager.firePoint.rotation);
            return;
        }
        // Calculate the initial angle
        float halfSpread = spreadAngle / 2;
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // Calculate the current angle
            float currentAngle = -halfSpread + angleStep * i;

            // Create the bullet and set its direction
            GameObject bullet = Object.Instantiate(bulletPrefab, fireTransform.position, Quaternion.Euler(0,currentAngle,0));
        }
    }

    public void HitEnemyBullet(Collision collision) {
        StartBlinkPlayer(playerManager.GetPlayer());
        DeleteEnemyBullet(collision.gameObject);
    }

    private void DeleteEnemyBullet(GameObject obj) {
        GameManager.Instance.CalcBulletNum(-1);
        Destroy(obj);
    }

    //無敵スタート
    public void StartBlinkPlayer(GameObject player) {
        StartCoroutine(BlinkPlayer(player));
    }
    IEnumerator BlinkPlayer(GameObject player) {
        float elapsedTime = 0f;
        while (elapsedTime < invincibilityDuration) {
            //一定時間ごとにメッシュのenabledを反転
            isMeshRendererEnable = !isMeshRendererEnable;
            ToggleSkinnedMeshRenderers(player, isMeshRendererEnable);
            

            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        // 最後にレンダラーを表示する
        ToggleSkinnedMeshRenderers(player, true); 
    }

    void ToggleSkinnedMeshRenderers(GameObject player, bool enable) {
        // 親オブジェクトのすべての子オブジェクトからSkinned Mesh Rendererを取得
        SkinnedMeshRenderer[] skinnedMeshRenderers = player.GetComponentsInChildren<SkinnedMeshRenderer>();

        // 各Skinned Mesh Rendererの有効/無効を設定
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers) {
            skinnedMeshRenderer.enabled = enable;
        }
    }



}
