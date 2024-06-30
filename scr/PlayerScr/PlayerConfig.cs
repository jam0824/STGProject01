using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint; // 弾を発射する位置
    public float mvVelocity = 0.005f;
    public float fireRate = 0.5f; // 弾を発射する間隔（秒）

    void Start() {
        //firePointのyを0に補正しておく
        Vector3 pos = firePoint.position;
        pos.y = 0;
        firePoint.position = pos;
    }



}
