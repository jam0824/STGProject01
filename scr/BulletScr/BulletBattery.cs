using UnityEngine;

public class BulletBattery : MonoBehaviour
{
    public GameObject bulletPrefab;
    Transform player;
    public float fireRate;
    public int numberOfBullets;
    public float bulletSpeed;
    public float spreadAngle;

    private float nextFireTime = 0f;
    private IShootingPattern shootingPattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootingPattern = GetComponent<IShootingPattern>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextFireTime) {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot() {
        shootingPattern.Shoot(
            bulletPrefab, 
            this.transform, 
            player,
            bulletSpeed, 
            numberOfBullets, 
            spreadAngle);
    }

}
