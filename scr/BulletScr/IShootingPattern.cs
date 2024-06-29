using UnityEngine;

public interface IShootingPattern
{
    void Shoot(
        GameObject bulletPrefab, 
        Transform enemyTransform, 
        Transform playerTransform, 
        float bulletSpeed, 
        int numberOfBullets, 
        float spreadAngle);
}