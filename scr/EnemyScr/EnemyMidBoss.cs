using UnityEngine;
using UnityEngine.UI;

//Enemyを継承させる
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

    //ヘルスバーを初期化する
    void InitHealthBar() {
        healthBar.maxValue = Hp;
        healthBar.value = Hp;
        StopProgress(); //オブジェクト読み込みを進めないために計測を止める
    }

    //時間計測停止
    void StopProgress() {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        bool progressMode = stageManager.StopProgress();
    }

    //時間計測再開
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
            StartProgress();    //時間計測を再開する
            GameManager.Instance.AddTotalScore(score);
            GameObject.Destroy(gameObject);
        }
    }

}
