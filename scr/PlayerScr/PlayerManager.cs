using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public Transform firePoint; // 弾を発射する位置
    public float mvVelocity = 0.005f;
    public float fireRate = 0.5f; // 弾を発射する間隔（秒）
    private int numberOfBullet = 1;

    private GameObject player;
    

    PlayerInput playerInput;
    PlayerAction playerAction;
    PlayerAnimation playerAnimation;
    StageManager stageManager;
    GameObject BigGirlPrefab;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInput = GetComponent<PlayerInput>();
        playerAction = GetComponent<PlayerAction>();
        playerAnimation = GetComponent<PlayerAnimation>();
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        BigGirlPrefab = stageManager.BigGirlPrefab;
        //firePoint.position = SetFirePoinst(firePoint);
    }

    Vector3 SetFirePoinst(Transform firePoint) {
        //firePointのyを0に補正しておく
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

    public int GetNumberOfBullet() {return numberOfBullet; }

    public bool GetBossMode() { return stageManager.BOSS_MODE; }
    public GameObject GetBigGirlPrefab() { return BigGirlPrefab; }  

    
}
