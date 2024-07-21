using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // 回転速度（角度/秒）
    float rotationSpeed = 0f;
    // 加速度 (秒あたり)
    float accelerationSpeed = 0f;
    Rigidbody rb;
    bool isGaze = false;    //かすり判定したか
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameManager.Instance.CalcBulletNum(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;
        if (rotationSpeed != 0) rb.linearVelocity = Rotate(rb, rotationSpeed);
        if (accelerationSpeed != 0) rb.linearVelocity = Acceleration(rb, accelerationSpeed);
    }
    public float GetRotationSpeed() { return rotationSpeed; }
    public float GetAccelerationSpeed() { return accelerationSpeed; }

    public float SetRotationSpeed(float rSpeed) {
        rotationSpeed = rSpeed;
        return rotationSpeed;
    }
    
    public float SetAccelerationSpeed(float aSpeed) {  
        accelerationSpeed = aSpeed; 
        return accelerationSpeed; 
    }

    //加速させる
    Vector3 Acceleration(Rigidbody rb, float speed) {
        // 前のフレームからの経過時間であげる速度を出す
        float acceleration = 1 + speed * Time.deltaTime;
        return rb.linearVelocity * acceleration;
    }

    //回転させる
    Vector3 Rotate(Rigidbody rb, float rSpeed) {
        // 現在の速度ベクトルを取得
        Vector3 currentVelocity = rb.linearVelocity;
        // 回転角度を計算
        float rotationAngle = rSpeed * Time.deltaTime;
        // Y軸を中心にした回転を表すクォータニオンを作成
        Quaternion rotation = Quaternion.Euler(0, rotationAngle, 0);
        // 現在の速度ベクトルに回転を適用
        return rotation * currentVelocity;
    }

    //かすり判定
    private void OnTriggerEnter(Collider other) {
        if((!isGaze)&&(other.gameObject.tag == "GazeTrigger")) {
            isGaze = true;
            GameManager.Instance.AddGaze();
            GameManager.Instance.AddTotalScore(GameConstants.SCORE_GAZE);
            SoundManager.Instance.PlaySE(GameConstants.SE_GAZE);
        }
    }
}
