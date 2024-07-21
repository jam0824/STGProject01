using UnityEngine;

//�^����ꂽ�������G��z�u����
public class RandomFormation : MonoBehaviour,IFormation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int numberOfObjects = 5; // �z�u����I�u�W�F�N�g�̐�
    public float distanceBetweenObjects = 2.0f; // �I�u�W�F�N�g�Ԃ̋���
    public float angle = 90.0f; // �z�u����p�x�i�x���@�j

    float xDist = 5f;   //X�����ɋ��e����͈�
    float zDist = 3f;   //z�����ɋ��e����͈�
    float speedRandom = 0.5f;   //������X�s�[�h�͈̔�

    public void StartFormation(
        GameObject prefab, int numberOfObjects, float distanceBetweenObjects, 
        float angle, float moveSpeed, float moveDir) {

        MakeRondomFormation(prefab, numberOfObjects, transform.position, moveDir, moveSpeed);
        
    }

    void MakeRondomFormation(GameObject enemy,int numberOfObject, Vector3 mePos, float moveDir, float moveSpeed) {
        for (int i = 0; i < numberOfObject; i++) {
            // x��-5����5�܂�
            float x = Random.value * xDist * 2 - xDist;
            // z�͗^����ꂽ�n�_����0~3�̊�
            float z = mePos.z + Random.value * zDist;
            moveSpeed += Random.value * speedRandom;
            Vector3 pos = new Vector3(x, 0, z);
            GameObject obj = Instantiate(enemy, pos, Quaternion.identity, transform); // �I�u�W�F�N�g��z�u
            Enemy e = obj.GetComponent<Enemy>();
            e.SetMoveDir(moveDir);
            e.SetMoveSpeed(moveSpeed);
            obj.transform.parent = null;
        }

    }

}
