using UnityEngine;

public class DirectionBullets : MonoBehaviour, IShootingPattern
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

        DirectionShoot(bulletPrefab, enemyTransform, spreadAngle, bulletSpeed);

    }

    void DirectionShoot(GameObject bulletPrefab, Transform enemyTransform, float angle, float speed) {
        Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
        // ‰º‚ð0“x‚Æ‚·‚é
        Vector3 direction = new Vector3(0f, 0f, -1f);
        Vector3 bulletDir = rotation * direction;

        GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bulletDir * speed;
    }

}
