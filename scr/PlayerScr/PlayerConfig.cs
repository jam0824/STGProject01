using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public Transform firePoint; // �e�𔭎˂���ʒu
    public float mvVelocity = 0.005f;
    public float fireRate = 0.5f; // �e�𔭎˂���Ԋu�i�b�j

    void Start() {
        //firePoint��y��0�ɕ␳���Ă���
        Vector3 pos = firePoint.position;
        pos.y = 0;
        firePoint.position = pos;
    }



}
