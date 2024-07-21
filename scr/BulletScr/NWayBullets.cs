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
        //y‚ğ0‚É‚·‚é
        Vector3 playerPos = playerTransform.position;
        playerPos.y = 0;
        // Player‚Ì•ûŒü‚ğo‚µ‚Ä•W€‰»
        Vector3 directionToPlayer = (playerPos - enemyTransform.position).normalized;

        //’e”‚ª1‚Ì‚Í•ÊiangleStep‚Å0Š„‚É‚È‚é‚½‚ß)
        if(numberOfBullets == 1) {
            OneShoot(bulletPrefab, enemyTransform, bulletSpeed, directionToPlayer);
            return;
        }

        // 30“x‚¾‚Æ‚µ‚½‚çplayer‚ğ‹²‚ñ‚Å15“x15“x‚É‚È‚é
        float halfSpread = spreadAngle / 2;
        //’e‚Ì”­ËŠp“x‚ÌŠÔŠu‚ğo‚·
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // ‚±‚Ì’e‚ğ”­Ë‚·‚éŠp“x‚ğo‚·
            float currentAngle = -halfSpread + angleStep * i;

            // y²‚ğ’†S‚É¡‚ÌŠp“x‚Å‰ñ“]‚³‚¹‚é
            Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

            // ’e‚Ì•ûŒü‚ğo‚·
            Vector3 bulletDir = rotation * directionToPlayer;

            GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletDir * bulletSpeed;
            bullet.transform.rotation = Quaternion.LookRotation(bulletDir); //’e‚ÌŠp“x‚ğ‰ñ“]•ûŒü‚É‚·‚é
        }
    }

    //‚P”­‚¾‚¯Œ‚‚Â‚Æ‚«‚Í‚±‚Á‚¿
    void OneShoot(GameObject bulletPrefab, Transform enemyTransform, float bulletSpeed, Vector3 directionToPlayer) {
        GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = directionToPlayer * bulletSpeed;
    }
}
