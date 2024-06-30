using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Hp = 10;
    public GameObject ExplosionPrefab;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "PlayerBullet") return;
        float damage = collision.gameObject.GetComponent<PlayerBulletConfig>().Damage;
        Hp -= damage;
        if(Hp <= 0) {
            GameObject explosion = Object.Instantiate(ExplosionPrefab,this.transform.position, Quaternion.identity);
            GameObject.Destroy(gameObject);
        }
    }

}
