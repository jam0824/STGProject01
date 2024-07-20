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
        //yÇ0Ç…Ç∑ÇÈ
        Vector3 playerPos = playerTransform.position;
        playerPos.y = 0;
        // Calculate the base direction towards the player
        Vector3 directionToPlayer = (playerPos - enemyTransform.position).normalized;

        //íeêîÇ™1ÇÃéûÇÕï ÅiangleStepÇ≈0äÑÇ…Ç»ÇÈÇΩÇﬂ)
        if(numberOfBullets == 1) {
            OneShoot(bulletPrefab, enemyTransform, bulletSpeed, directionToPlayer);
            return;
        }

        // Calculate the initial angle
        float halfSpread = spreadAngle / 2;
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // Calculate the current angle
            float currentAngle = -halfSpread + angleStep * i;

            // Calculate the rotation
            Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

            // Calculate the bullet direction
            Vector3 bulletDir = rotation * directionToPlayer;

            // Create the bullet and set its direction
            GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletDir * bulletSpeed;
            bullet.transform.rotation = Quaternion.LookRotation(bulletDir);
        }
    }

    void OneShoot(GameObject bulletPrefab, Transform enemyTransform, float bulletSpeed, Vector3 directionToPlayer) {
        GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = directionToPlayer * bulletSpeed;
    }
}
