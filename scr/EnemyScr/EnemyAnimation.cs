using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Quaternion EnemyRotation(Vector3 direction) {
       return Quaternion.LookRotation(direction);
    }

    public Quaternion WorldRotateX(Transform target, float angle) {
        Quaternion currentRotation = target.rotation;
        // 45度回転するためのQuaternionを作成（ワールド座標系のX軸に対して）
        Quaternion rotationX = Quaternion.Euler(angle, 0, 0);
        // 新しい回転を適用
        return rotationX * currentRotation;
    }

    public void AttackTrigger() {
        if (!TriggerExists("attackTrigger")) return;
        anim.SetTrigger("attackTrigger");
    }

    bool TriggerExists(string name) {
        foreach (AnimatorControllerParameter parameter in anim.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Trigger && parameter.name == name) {
                return true;
            }
        }
        return false;
    }
}
