using UnityEngine;
using UnityEngine.UI;

public class EnemyMidBoss : Enemy
{
    public Slider healthBar;
    StageManager stageManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitHealthBar();
        init();
        enemyMove.EnemyMove(rb, enemyAnimation, MoveDir, MoveSpeed, isMoveWithScroll);
    }
    void InitHealthBar() {
        healthBar.maxValue = Hp;
        healthBar.value = Hp;
        StopProgress();
    }

    void StopProgress() {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        bool progressMode = stageManager.StopProgress();
    }
    void StartProgress() {
        if(stageManager == null) stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        bool progressMode = stageManager.StartProgress();
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "PlayerBullet") return;
        Damage(collision.gameObject);
        healthBar.value = Hp;
    }
    void Damage(GameObject playerBullet) {
        float damage = playerBullet.GetComponent<PlayerBulletConfig>().Damage;
        SoundManager.Instance.PlaySE(GameConstants.SE_PLAYER_FIRE_HIT);
        Hp -= damage;
        if (Hp <= 0) {
            MakeEffect(maxHp);
            StartProgress();
            GameManager.Instance.AddTotalScore(score);
            GameObject.Destroy(gameObject);
        }
    }

}
