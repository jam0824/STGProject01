using UnityEngine;

public class RandomFormation : MonoBehaviour,IFormation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int numberOfObjects = 5; // 配置するオブジェクトの数
    public float distanceBetweenObjects = 2.0f; // オブジェクト間の距離
    public float angle = 90.0f; // 配置する角度（度数法）

    float xDist = 5f;
    float zDist = 3f;
    float speedRandom = 0.5f;

    public void StartFormation(
        GameObject prefab, int numberOfObjects, float distanceBetweenObjects, 
        float angle, float moveSpeed, float moveDir) {

        MakeRondomFormation(prefab, numberOfObjects, transform.position, moveDir, moveSpeed);
        
    }

    void MakeRondomFormation(GameObject enemy,int numberOfObject, Vector3 mePos, float moveDir, float moveSpeed) {
        for (int i = 0; i < numberOfObject; i++) {
            float x = Random.value * xDist * 2 - xDist;
            float z = mePos.z + Random.value * zDist;
            moveSpeed += Random.value * speedRandom;
            Vector3 pos = new Vector3(x, 0, z);
            GameObject obj = Instantiate(enemy, pos, Quaternion.identity, transform); // オブジェクトを配置
            Enemy e = obj.GetComponent<Enemy>();
            e.SetMoveDir(moveDir);
            e.SetMoveSpeed(moveSpeed);
            obj.transform.parent = null;
        }

    }

}
