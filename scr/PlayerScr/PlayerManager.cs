using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌƒvƒŒƒnƒu
    public Transform firePoint; // ’e‚ğ”­Ë‚·‚éˆÊ’u
    public float mvVelocity = 0.005f;
    public float fireRate = 0.5f; // ’e‚ğ”­Ë‚·‚éŠÔŠui•bj

    private GameObject player;
    

    PlayerInput playerInput;
    PlayerAction playerAction;
    PlayerAnimation playerAnimation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInput = GetComponent<PlayerInput>();
        playerAction = GetComponent<PlayerAction>();
        playerAnimation = GetComponent<PlayerAnimation>();
        firePoint.position = SetFirePoinst(firePoint);
    }

    Vector3 SetFirePoinst(Transform firePoint) {
        //firePoint‚Ìy‚ğ0‚É•â³‚µ‚Ä‚¨‚­
        Vector3 pos = firePoint.position;
        pos.y = 0;
        return pos;
    }

    // Update is called once per frame
    void Update() {
        player = playerInput.KeyInput(
            player, 
            playerAction, 
            playerAnimation, 
            mvVelocity);
    }

    public GameObject GetPlayer() {
        return player;
    }

    
}
