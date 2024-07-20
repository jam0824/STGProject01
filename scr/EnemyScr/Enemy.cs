using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public float MoveSpeed;
    public float MoveDir;
    public GameObject ExplosionPrefab;
    public GameObject ItemPrefab;
    public bool isMoveWithScroll = false;
    private protected IEnemyMove enemyMove;
    protected float maxHp = 10;
    protected Rigidbody rb;
    protected EnemyAnimation enemyAnimation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHp = Hp;
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
        SoundManager.Instance.PlaySE(GameConstants.SE_PLAYER_FIRE_HIT);
        Hp -= damage;
        if (Hp <= 0) {
            MakeEffect(maxHp);
            GameObject.Destroy(gameObject);
        }
    }
    private void MakeEffect(float maxHp) {
        GameObject explosion = Object.Instantiate(ExplosionPrefab, this.transform.position, Quaternion.identity);
        GameObject item = Object.Instantiate(ItemPrefab, this.transform.position, Quaternion.Euler(90, 0, 0));
        string effectName = "";
        if (maxHp < 5) effectName = GameConstants.SE_EXPLOSION_SMALL;
        else if (maxHp < 10) effectName = GameConstants.SE_EXPLOSION_MIDDLE;
        else effectName = GameConstants.SE_EXPLOSION_LARGE;
        SoundManager.Instance.PlaySE(effectName);
    }

    public void SetMoveSpeed(float moveSpeed) {this.MoveSpeed = moveSpeed;}
    public void SetMoveDir(float moveDir) { this.MoveDir = moveDir; }

    public void PlayAttack() {
        enemyAnimation.AttackTrigger();
    }

}
