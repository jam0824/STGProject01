using UnityEngine;

public class EnemyAngleMove : MonoBehaviour,IEnemyMove
{
    Rigidbody rb;
    EnemyAnimation enemyAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed) {
        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        rb.linearVelocity = direction * speed;
        transform.rotation = enemyAnimation.EnemyRotation(direction);
    }

}
