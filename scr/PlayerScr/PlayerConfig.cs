using UnityEngine;

public class PlayerConfig : MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌƒvƒŒƒnƒu
    public Transform firePoint; // ’e‚ğ”­Ë‚·‚éˆÊ’u
    public float mvVelocity = 0.005f;
    public float fireRate = 0.5f; // ’e‚ğ”­Ë‚·‚éŠÔŠui•bj

    void Start() {
        //firePoint‚Ìy‚ğ0‚É•â³‚µ‚Ä‚¨‚­
        Vector3 pos = firePoint.position;
        pos.y = 0;
        firePoint.position = pos;
    }



}
