using UnityEngine;

public class LineFormation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject enemy; // 配置するオブジェクト
    public int numberOfObjects = 5; // 配置するオブジェクトの数
    public float distanceBetweenObjects = 2.0f; // オブジェクト間の距離
    public float angle = 90.0f; // 配置する角度（度数法）

    void Start() {
        ArrangeObjectsInLine();
    }

    void ArrangeObjectsInLine() {
        float radian = angle * Mathf.Deg2Rad; // 角度をラジアンに変換
        Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)); // 配置方向の計算

        for (int i = 0; i < numberOfObjects; i++) {
            Vector3 position = transform.position + direction * distanceBetweenObjects * i; // 新しい位置の計算
            Instantiate(enemy, position, Quaternion.identity, transform); // オブジェクトを配置
        }
    }
}
