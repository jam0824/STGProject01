using UnityEngine;

public class NWayBullets : MonoBehaviour, IShootingPattern
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(
        GameObject bulletPrefab,
        Transform enemyTransform,
        Transform playerTransform,
        float bulletSpeed,
        int numberOfBullets,
        float spreadAngle) {
        //yを0にする
        Vector3 playerPos = playerTransform.position;
        playerPos.y = 0;
        // Playerの方向を出して標準化
        Vector3 directionToPlayer = (playerPos - enemyTransform.position).normalized;

        //弾数が1の時は別（angleStepで0割になるため)
        if(numberOfBullets == 1) {
            OneShoot(bulletPrefab, enemyTransform, bulletSpeed, directionToPlayer);
            return;
        }

        // 30度だとしたらplayerを挟んで15度15度になる
        float halfSpread = spreadAngle / 2;
        //弾の発射角度の間隔を出す
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // この弾を発射する角度を出す
            float currentAngle = -halfSpread + angleStep * i;

            // y軸を中心に今の角度で回転させる
            Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

            // 弾の方向を出す
            Vector3 bulletDir = rotation * directionToPlayer;

            GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletDir * bulletSpeed;
            bullet.transform.rotation = Quaternion.LookRotation(bulletDir); //弾の角度を回転方向にする
        }
    }

    //１発だけ撃つときはこっち
    void OneShoot(GameObject bulletPrefab, Transform enemyTransform, float bulletSpeed, Vector3 directionToPlayer) {
        GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = directionToPlayer * bulletSpeed;
    }
}
