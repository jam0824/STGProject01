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
        // 45度回転するためのQuaternionを作成（ワールド座標系のX軸に対して）
        Quaternion rotationX = Quaternion.Euler(angle, 0, 0);
        // 新しい回転を適用
        return rotationX * currentRotation;
    }
}
