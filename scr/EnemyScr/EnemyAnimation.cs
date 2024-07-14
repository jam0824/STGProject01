using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        // 45�x��]���邽�߂�Quaternion���쐬�i���[���h���W�n��X���ɑ΂��āj
        Quaternion rotationX = Quaternion.Euler(angle, 0, 0);
        // �V������]��K�p
        return rotationX * currentRotation;
    }
}
