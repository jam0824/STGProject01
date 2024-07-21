using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    string currentMove = "";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //direction方向に向く
    public Quaternion EnemyRotation(Vector3 direction) {
       return Quaternion.LookRotation(direction);
    }

    //worldのx軸に対して傾ける。敵の顔を見やすくする。
    public Quaternion WorldRotateX(Transform target, float angle) {
        Quaternion currentRotation = target.rotation;
        // 45度回転するためのQuaternionを作成（ワールド座標系のX軸に対して）
        Quaternion rotationX = Quaternion.Euler(angle, 0, 0);
        // 新しい回転を適用
        return rotationX * currentRotation;
    }

    //攻撃モーションをつけたいとき
    public void AttackTrigger() {
        if (!TriggerExists("attackTrigger")) return;
        anim.SetTrigger("attackTrigger");
    }

    //アニメーションに指定したアニメーションがあるかチェック
    bool TriggerExists(string name) {
        foreach (AnimatorControllerParameter parameter in anim.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Trigger && parameter.name == name) {
                return true;
            }
        }
        return false;
    }

    //人型の場合、進んでいる方向に合わせてモーションを変える
    public void ChangeAnimationForHuman(Vector3 mePos, Vector3 targetPos) {
        float angle = GetAngleFromVector(mePos, targetPos);
        // Debug.Log("angle=" + angle);
        if ((angle >= 0) && (angle < 45) && currentMove != "MoveRight") {
            currentMove = "MoveRight";
            anim.SetTrigger("MoveRight");
            return;
        }
        if ((angle >= 45) && (angle < 135) && currentMove != "MoveFwd") {
            currentMove = "MoveFwd";
            anim.SetTrigger("MoveFwd");
            return;
        }
        if ((angle >= 135) && (angle < 225) && currentMove != "MoveLeft") {
            currentMove = "MoveLeft";
            anim.SetTrigger("MoveLeft");
            return;
        }
        if ((angle >= 225) && (angle < 315) && currentMove != "MoveBack") {
            currentMove = "MoveBack";
            anim.SetTrigger("MoveBack");
            return;
        }
        if ((angle >= 315) && (angle < 360) && currentMove != "MoveRight") {
            currentMove = "MoveRight";
            anim.SetTrigger("MoveRight");
            return;
        }
    }

    //二つのベクトルから向かう方向の角度を取得する
    public float GetAngleFromVector(Vector3 mePos, Vector3 targetPos) {
        Vector3 direction = mePos - targetPos;  //targetの方向を出す
        // アークタンジェントで角度を出す
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
