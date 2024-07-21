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
        //y��0�ɂ���
        Vector3 playerPos = playerTransform.position;
        playerPos.y = 0;
        // Player�̕������o���ĕW����
        Vector3 directionToPlayer = (playerPos - enemyTransform.position).normalized;

        //�e����1�̎��͕ʁiangleStep��0���ɂȂ邽��)
        if(numberOfBullets == 1) {
            OneShoot(bulletPrefab, enemyTransform, bulletSpeed, directionToPlayer);
            return;
        }

        // 30�x���Ƃ�����player�������15�x15�x�ɂȂ�
        float halfSpread = spreadAngle / 2;
        //�e�̔��ˊp�x�̊Ԋu���o��
        float angleStep = spreadAngle / (numberOfBullets - 1);

        for (int i = 0; i < numberOfBullets; i++) {
            // ���̒e�𔭎˂���p�x���o��
            float currentAngle = -halfSpread + angleStep * i;

            // y���𒆐S�ɍ��̊p�x�ŉ�]������
            Quaternion rotation = Quaternion.AngleAxis(currentAngle, Vector3.up);

            // �e�̕������o��
            Vector3 bulletDir = rotation * directionToPlayer;

            GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody>().linearVelocity = bulletDir * bulletSpeed;
            bullet.transform.rotation = Quaternion.LookRotation(bulletDir); //�e�̊p�x����]�����ɂ���
        }
    }

    //�P���������Ƃ��͂�����
    void OneShoot(GameObject bulletPrefab, Transform enemyTransform, float bulletSpeed, Vector3 directionToPlayer) {
        GameObject bullet = Object.Instantiate(bulletPrefab, enemyTransform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().linearVelocity = directionToPlayer * bulletSpeed;
    }
}
