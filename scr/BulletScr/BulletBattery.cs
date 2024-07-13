using UnityEngine;

public class BulletBattery : MonoBehaviour
{
    public GameObject bulletPrefab;
    Transform player;
    public float initialTime = 2;
    public float fireRate;
    public int numberOfBullets;
    public float bulletSpeed;
    public float spreadAngle;
    public float randomFireTiming = 1f;

    private float startFireTime = 0f;
    private float nextFireTime = 0f;
    private IShootingPattern shootingPattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startFireTime = Time.time + initialTime;
        shootingPattern = GetComponent<IShootingPattern>();
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time < startFireTime) return;
        if (Time.time > nextFireTime) {
            if (randomFireTiming == 1) {
                Shoot();
            }
            else {
                if(Random.value < randomFireTiming) Shoot();
            }
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
