using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public float MoveSpeed;
    public float MoveDir;
    public GameObject ExplosionPrefab;
    public GameObject ItemPrefab;
    public bool isMoveWithScroll = false;
    public bool isProgress = true;
    private IEnemyMove enemyMove;
    Rigidbody rb;
    EnemyAnimation enemyAnimation;
    StageManager stageManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!isProgress) {
            stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
            stageManager.PROGRESS_MODE = false;
        }
        rb = GetComponent<Rigidbody>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyMove = GetComponent<IEnemyMove>();
        enemyMove.EnemyMove(rb, enemyAnimation, MoveDir, MoveSpeed, isMoveWithScroll);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "PlayerBullet") return;
        Damage(collision.gameObject);
    }

    private void Damage(GameObject playerBullet) {
        float damage = playerBullet.GetComponent<PlayerBulletConfig>().Damage;
        Hp -= damage;
        if (Hp <= 0) {
            GameObject explosion = Object.Instantiate(ExplosionPrefab, this.transform.position, Quaternion.identity);
            GameObject item = Object.Instantiate(ItemPrefab, this.transform.position, Quaternion.Euler(90, 0, 0));
            GameObject.Destroy(gameObject);
        }
    }

    public void SetMoveSpeed(float moveSpeed) {this.MoveSpeed = moveSpeed;}
    public void SetMoveDir(float moveDir) { this.MoveDir = moveDir; }

    public void PlayAttack() {
        enemyAnimation.AttackTrigger();
    }

}
