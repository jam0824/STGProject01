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

    //direction�����Ɍ���
    public Quaternion EnemyRotation(Vector3 direction) {
       return Quaternion.LookRotation(direction);
    }

    //world��x���ɑ΂��ČX����B�G�̊�����₷������B
    public Quaternion WorldRotateX(Transform target, float angle) {
        Quaternion currentRotation = target.rotation;
        // 45�x��]���邽�߂�Quaternion���쐬�i���[���h���W�n��X���ɑ΂��āj
        Quaternion rotationX = Quaternion.Euler(angle, 0, 0);
        // �V������]��K�p
        return rotationX * currentRotation;
    }

    //�U�����[�V�������������Ƃ�
    public void AttackTrigger() {
        if (!TriggerExists("attackTrigger")) return;
        anim.SetTrigger("attackTrigger");
    }

    //�A�j���[�V�����Ɏw�肵���A�j���[�V���������邩�`�F�b�N
    bool TriggerExists(string name) {
        foreach (AnimatorControllerParameter parameter in anim.parameters) {
            if (parameter.type == AnimatorControllerParameterType.Trigger && parameter.name == name) {
                return true;
            }
        }
        return false;
    }

    //�l�^�̏ꍇ�A�i��ł�������ɍ��킹�ă��[�V������ς���
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

    //��̃x�N�g����������������̊p�x���擾����
    public float GetAngleFromVector(Vector3 mePos, Vector3 targetPos) {
        Vector3 direction = mePos - targetPos;  //target�̕������o��
        // �A�[�N�^���W�F���g�Ŋp�x���o��
        float angle = Mathf.Atan2(direction.z, direction.x) * Mathf.Rad2Deg;
        return angle;
    }
}
