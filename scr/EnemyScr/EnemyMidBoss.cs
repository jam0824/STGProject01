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
    }
    private void Damage(GameObject playerBullet) {
        float damage = playerBullet.GetComponent<PlayerBulletConfig>().Damage;
        SoundManager.Instance.PlaySE("HitBullet01");
        Hp -= damage;
        healthBar.value = Hp;
        if (Hp <= 0) {
            stageManager.StartProgress();
            GameObject explosion = Object.Instantiate(ExplosionPrefab, this.transform.position, Quaternion.identity);
            GameObject item = Object.Instantiate(ItemPrefab, this.transform.position, Quaternion.Euler(90, 0, 0));
            GameObject.Destroy(gameObject);
        }
    }

}
