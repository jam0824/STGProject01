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
    private bool isMeshRendererEnable = true;   //メッシュの表示状態

    PlayerManager playerManager;
    GameManager gameManager;

    private void Start() {
        gameManager = GameManager.Instance;
        playerManager = GetComponent<PlayerManager>();
        
    }

    public Vector3 PlayerMove(GameObject gameObject, Vector3 movement, float velocity) {
        if (movement == Vector3.zero) return gameObject.transform.position;

        Vector3 pos = gameObject.transform.position;
        pos.x += movement.x * velocity;
        pos.z += movement.z * velocity;
        return FixPos(pos);
    }

    //画面端ならそれ以上いかないようにする
    Vector3 FixPos(Vector3 pos) {
        pos.x = Mathf.Clamp(pos.x, -gameManager.RIGHT_LEFT, gameManager.RIGHT_LEFT);
        pos.z = Mathf.Clamp(pos.z, -gameManager.TOP_BOTTOM, gameManager.TOP_BOTTOM);
        return pos;
    }

    // TODO
    //ボス対戦時は画面移動を可能にする
    public void BigGirlMove(Vector3 pos, Vector3 movement, float velocity) {
        if (!playerManager.GetBossMode()) return;
        GameObject bigGirl = playerManager.GetBigGirlPrefab();
        Vector3 bigGirlPos = bigGirl.transform.position;
        float v = velocity * 0.5f;
        if ((pos.x <= -gameManager.RIGHT_LEFT)&&(movement.x < 0)) {
            bigGirlPos.x += -movement.x * v;
        }
        if ((pos.x >= gameManager.RIGHT_LEFT) && (movement.x > 0)) {
            bigGirlPos.x += -movement.x * v;
        }
        if ((pos.z <= -gameManager.TOP_BOTTOM) && (movement.z < 0)) {
            bigGirlPos.z += -movement.z * v;
        }
        if ((pos.z >= gameManager.TOP_BOTTOM) && (movement.z > 0)) {
            bigGirlPos.z += -movement.z * v;
        }
        bigGirl.transform.position = bigGirlPos;

    }


    public void ShootStart() {
        if (!isShooting) {
            StartCoroutine(Shoot());    //コールチンで弾を撃つ
        }
    }
    public void SetIsShooting(bool flag) {
        isShooting = flag;
    }
    IEnumerator Shoot() {
        isShooting = true;
        while (isShooting) {
            if (Time.time >= nextFireTime) {
                //次の発射可能時間を計算
                nextFireTime = Time.time + playerManager.fireRate;
                FireBullet();
                SoundManager.Instance.PlaySE(GameConstants.SE_PLAYER_FIRE_FLASH);
            }
            yield return null; // フレームごとにチェックを行う
        }
    }

    //放射状の自弾
    private void FireBullet() {
        float n = Mathf.Floor(GameManager.Instance.GetItemNum() / GameManager.Instance.POWERUP_ITEM_NUM);
        int num = (int)n * 2 + 1;
        // 全体の発射角度は弾数*5
        Shoot(playerManager.bulletPrefab,
            playerManager.firePoint.transform,
            num,
            num * 5);
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
        // 発射角度の始点を出す
        float halfSpread = spreadAngle / 2;
        // 発射する弾の角度の間隔
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // 発射角度の始点からステップで発射する角度を求める
            float currentAngle = -halfSpread + angleStep * i;
            GameObject bullet = Object.Instantiate(bulletPrefab, fireTransform.position, Quaternion.Euler(0,currentAngle,0));
        }
    }

    //敵弾にあたった時に呼ばれる
    public void HitEnemyBullet(Collider collision) {
        SoundManager.Instance.PlaySE(GameConstants.SE_PLAYER_DAMAGE);
        StartBlinkPlayer(playerManager.GetPlayer());
        DeleteEnemyBullet(collision.gameObject);
    }

    private void DeleteEnemyBullet(GameObject obj) {
        GameManager.Instance.CalcBulletNum(-1);
        Destroy(obj);
    }

    //被弾時の無敵スタート
    // TODO まだ表示しか実装してない
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
        // 最後にメッシュレンダラーを表示する
        ToggleSkinnedMeshRenderers(player, true); 
    }

    // メッシュのオンオフ
    void ToggleSkinnedMeshRenderers(GameObject player, bool enable) {
        // 親オブジェクトのすべての子オブジェクトからSkinned Mesh Rendererを取得
        SkinnedMeshRenderer[] skinnedMeshRenderers = player.GetComponentsInChildren<SkinnedMeshRenderer>();

        // 各Skinned Mesh Rendererの有効/無効を設定
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in skinnedMeshRenderers) {
            skinnedMeshRenderer.enabled = enable;
        }
    }



}
