using UnityEngine;
using UnityEngine.UI;

public class EnemyMidBoss : Enemy
{
    public Slider healthBar;
    StageManager stageManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = Hp;
        healthBar.value = Hp;
        StopProgress();
        maxHp = Hp;
        oldPos = transform.position;
        rb = GetComponent<Rigidbody>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyMove = GetComponent<IEnemyMove>();
        enemyMove.EnemyMove(rb, enemyAnimation, MoveDir, MoveSpeed, isMoveWithScroll);
    }

    void StopProgress() {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        bool progressMode = stageManager.StopProgress();
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "PlayerBullet") return;
        Damage(collision.gameObject);
        healthBar.value = Hp;
    }

}
