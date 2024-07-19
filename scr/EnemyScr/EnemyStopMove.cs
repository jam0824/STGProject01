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
        // 現在位置を更新
        transform.position = SmoothMovement(this.journeyLength, this.startPosition, this.targetPosition);
    }

    Vector3 SmoothMovement(float journeyLength, Vector3 startPosition, Vector3 targetPosition) {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        // SmoothStepを使用して滑らかに減速させる
        float smoothStep = Mathf.SmoothStep(0, 1, fractionOfJourney);
        return Vector3.Lerp(startPosition, targetPosition, smoothStep);
    }


    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.speed = speed;
        float angleRad = angle * Mathf.Deg2Rad;
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        transform.rotation = enemyAnimation.EnemyRotation(direction);
        transform.rotation = enemyAnimation.WorldRotateX(this.transform, GameManager.Instance.GetEnemyXRotation());
    }
}
