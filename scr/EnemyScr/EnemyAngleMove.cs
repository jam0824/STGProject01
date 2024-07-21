using Unity.VisualScripting;
using UnityEngine;

public class EnemyAngleMove : MonoBehaviour,IEnemyMove
{
    public bool isLookDirection = true;
    EnemyAnimation enemyAnimation;

    protected Rigidbody rb;
    protected bool isMoveWithScroll = false;
    protected StageManager stageManager;
    protected Utilities utilities;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        utilities = GameObject.Find("GameManager").GetComponent<Utilities>();
    }


    // Update is called once per frame
    void Update()
    {
        //もしスクロールとともに動かしたいなら。もういらない
        if (isMoveWithScroll) MoveWithScroll(stageManager.scrollSpeed);
    }

    public void MoveWithScroll(float scrollSpeed) {
        Vector3 pos = transform.position;
        pos.z -= scrollSpeed;
        transform.position = pos;
    }

    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.isMoveWithScroll = isMoveWithScroll;
        float angleRad = angle * Mathf.Deg2Rad; //角度からラジアンに変換
        //ラジアンを使ってベクトルを出す
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));   
        rb.linearVelocity = direction * speed;
        //移動方向を向かせたいとき
        if(isLookDirection) transform.rotation = enemyAnimation.EnemyRotation(direction);
        //ワールドのX軸に対して傾ける。敵の顔が見やすいようにする
        transform.rotation = enemyAnimation.WorldRotateX(this.transform, GameManager.Instance.GetEnemyXRotation());

    }

}
