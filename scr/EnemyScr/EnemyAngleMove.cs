using UnityEngine;

public class EnemyAngleMove : MonoBehaviour,IEnemyMove
{
    Rigidbody rb;
    EnemyAnimation enemyAnimation;
    bool isMoveWithScroll = false;
    StageManager stageManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isMoveWithScroll) MoveWithScroll(stageManager.scrollSpeed);
    }

    public void MoveWithScroll(float scrollSpeed) {
        Vector3 pos = transform.position;
        pos.z -= scrollSpeed;
        transform.position = pos;
    }

    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.isMoveWithScroll = isMoveWithScroll;
        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        rb.linearVelocity = direction * speed;
        transform.rotation = enemyAnimation.EnemyRotation(direction);
    }

}
