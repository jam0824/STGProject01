using UnityEngine;

public class BossSub : MonoBehaviour
{
    [SerializeField] float Hp = 10;
    [SerializeField] GameObject ExplosionPrefab;
    [SerializeField] GameObject SUB_ROOT_PREFAB;
    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {

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
            GameObject.Destroy(SUB_ROOT_PREFAB);

        }
    }
}
