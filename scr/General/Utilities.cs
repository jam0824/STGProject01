using UnityEngine;

public class Utilities : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Quaternion LookAtPlayer(Transform player, Transform me, float rotationSpeed) {
        // プレイヤーの方向を計算
        Vector3 direction = player.position - me.position;
        direction.y = 0; // 水平方向だけを考慮（上下の回転を無視）

        // プレイヤーの方向に向かう回転を計算
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // 現在の回転からプレイヤーの方向への回転を徐々に適用
        return Quaternion.Lerp(me.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
}
