using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public float MoveSpeed;
    public float MoveDir;
    public GameObject ExplosionPrefab;
    private IEnemyMove enemyMove;
    Rigidbody rb;
    EnemyAnimation enemyAnimation;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemyAnimation = GetComponent<EnemyAnimation>();
        enemyMove = GetComponent<IEnemyMove>();
        enemyMove.EnemyMove(rb, enemyAnimation, MoveDir, MoveSpeed);
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
            GameObject.Destroy(gameObject);
        }
    }

}
