using UnityEngine;

public class LineFormation : MonoBehaviour,IFormation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int numberOfObjects = 5; // 配置するオブジェクトの数
    public float distanceBetweenObjects = 2.0f; // オブジェクト間の距離
    public float angle = 90.0f; // 配置する角度（度数法）



    public void StartFormation(GameObject prefab, int numberOfObjects, float distanceBetweenObjects, float angle, float moveSpeed, float moveDir) {
        this.numberOfObjects = numberOfObjects;
        this.distanceBetweenObjects = distanceBetweenObjects;
        this.angle = angle;
        ArrangeObjectsInLine(prefab, moveSpeed, moveDir);
    }

    void ArrangeObjectsInLine(GameObject enemy, float moveSpeed, float moveDir) {
        float radian = angle * Mathf.Deg2Rad; // 角度をラジアンに変換
        Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)); // 配置方向の計算

        for (int i = 0; i < numberOfObjects; i++) {
            Vector3 position = transform.position + direction * distanceBetweenObjects * i; // 新しい位置の計算
            GameObject obj = Instantiate(enemy, position, Quaternion.identity, transform); // オブジェクトを配置
            Enemy e = obj.GetComponent<Enemy>();
            e.SetMoveDir(moveDir);
            e.SetMoveSpeed(moveSpeed);
            obj.transform.parent = null;
        }
        Destroy(gameObject);
    }
}
