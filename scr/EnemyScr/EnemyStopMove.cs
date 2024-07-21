using UnityEngine;

public class EnemyStopMove : MonoBehaviour,IEnemyMove
{
    public Vector3 targetPosition;  // 移動先のターゲット位置
    private float speed = 2f;  // 移動速度
    private Vector3 startPosition;  // 移動開始位置
    private float journeyLength;  // 移動距離
    private float startTime;  // 移動開始時間
    EnemyAnimation enemyAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SmoothMovement(this.journeyLength, this.startPosition, this.targetPosition);
    }

    //徐々に遅くなる移動
    Vector3 SmoothMovement(float journeyLength, Vector3 startPosition, Vector3 targetPosition) {
        //経過時間による移動分
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        // SmoothStepを使用して滑らかに減速させる
        float smoothStep = Mathf.SmoothStep(0, 1, fractionOfJourney);
        return Vector3.Lerp(startPosition, targetPosition, smoothStep);
    }


    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.speed = speed;
        float angleRad = angle * Mathf.Deg2Rad; //角度をラジアンに変換
        //方向を出す
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        //向きを移動する方向に向ける
        transform.rotation = enemyAnimation.EnemyRotation(direction);
        // worldに対してxで傾ける。顔を見やすくするため
        transform.rotation = enemyAnimation.WorldRotateX(this.transform, GameManager.Instance.GetEnemyXRotation());
    }
}
