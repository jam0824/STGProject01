using UnityEngine;

public class Enemy01 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform player;
    public float fireRate = 1f;
    public int numberOfBullets = 5; // äÔêîÇ…Ç∑ÇÈÇ±Ç∆
    public float bulletSpeed = 10f;
    public float spreadAngle = 30f;

    private float nextFireTime = 0f;
    private IShootingPattern shootingPattern;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        shootingPattern = GetComponent<IShootingPattern>();
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
