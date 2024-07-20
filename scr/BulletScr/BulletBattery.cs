using UnityEngine;

public class BulletBattery : MonoBehaviour
{
    [SerializeField]GameObject bulletPrefab;
    [SerializeField]float initialTime = 2;
    [SerializeField]float fireRate;
    [SerializeField]int numberOfBullets;
    [SerializeField]float bulletSpeed;
    [SerializeField]float spreadAngle;
    [SerializeField]float randomFireTiming = 1f;
    [SerializeField]GameObject parentObject;

    Transform player;
    private float startFireTime = 0f;
    private float nextFireTime = 0f;
    private IShootingPattern shootingPattern;
    private Enemy enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startFireTime = Time.time + initialTime;
        shootingPattern = GetComponent<IShootingPattern>();
        player = GameObject.FindWithTag("Player").transform;
        enemy = parentObject.GetComponent<Enemy>();
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
