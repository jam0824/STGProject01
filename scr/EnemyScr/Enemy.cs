using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public float MoveSpeed;
    public float MoveDir;
    public GameObject ExplosionPrefab;
    public GameObject ItemPrefab;
    public bool isHuman = false;
    public bool isMoveWithScroll = false;
    private protected IEnemyMove enemyMove;
    protected GameObject player;
    protected float maxHp = 10;
    protected Rigidbody rb;
    protected EnemyAnimation enemyAnimation;
    protected Vector3 oldPos;
    protected float score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init();
        enemyMove.EnemyMove(rb, enemyAnimation, MoveDir, MoveSpeed, isMoveWithScroll);
    }
    protected void init() {
        maxHp = Hp;
        score = maxHp * GameConstants.SCORE_TIMES;
        oldPos = transform.position;
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyMove = GetComponent<IEnemyMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //人型の時は移動方向に合わせてアニメーションさせる
        if((isHuman)&&(oldPos != transform.position)) {
            enemyAnimation.ChangeAnimationForHuman(oldPos, transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "PlayerBullet") return;
        Damage(collision.gameObject);
    }

    void Damage(GameObject playerBullet) {
        float damage = playerBullet.GetComponent<PlayerBulletConfig>().Damage;
        SoundManager.Instance.PlaySE(GameConstants.SE_PLAYER_FIRE_HIT);
        Hp -= damage;
        if (Hp <= 0) {
            MakeEffect(maxHp);
            GameManager.Instance.AddTotalScore(score);
            GameObject.Destroy(gameObject);
        }
    }
    protected void MakeEffect(float maxHp) {
        GameObject explosion = Object.Instantiate(ExplosionPrefab, this.transform.position, Quaternion.identity);
        GameObject item = Object.Instantiate(ItemPrefab, this.transform.position, Quaternion.Euler(90, 0, 0));
        item.GetComponent<Item>().SetPlayer(player);    //Item側でもFindをさせたくないためここでplayerを渡す
        string effectName = "";
        //HPで音の大きさを変える
        if (maxHp < 5) effectName = GameConstants.SE_EXPLOSION_SMALL;
        else if (maxHp < 10) effectName = GameConstants.SE_EXPLOSION_MIDDLE;
        else effectName = GameConstants.SE_EXPLOSION_LARGE;
        SoundManager.Instance.PlaySE(effectName);
    }

    public void SetMoveSpeed(float moveSpeed) {this.MoveSpeed = moveSpeed;}
    public void SetMoveDir(float moveDir) { this.MoveDir = moveDir; }
    public float GetScore() { return this.score;}

    //敵に攻撃モーションをつけたいならこれを呼ぶ
    public void PlayAttack() {
        enemyAnimation.AttackTrigger();
    }

}
