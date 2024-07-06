using UnityEngine;

public class LineFormation : MonoBehaviour,IFormation
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int numberOfObjects = 5; // �z�u����I�u�W�F�N�g�̐�
    public float distanceBetweenObjects = 2.0f; // �I�u�W�F�N�g�Ԃ̋���
    public float angle = 90.0f; // �z�u����p�x�i�x���@�j



    public void StartFormation(GameObject prefab) {
        ArrangeObjectsInLine(prefab);
    }

    void ArrangeObjectsInLine(GameObject enemy) {
        float radian = angle * Mathf.Deg2Rad; // �p�x�����W�A���ɕϊ�
        Vector3 direction = new Vector3(Mathf.Cos(radian), 0, Mathf.Sin(radian)); // �z�u�����̌v�Z

        for (int i = 0; i < numberOfObjects; i++) {
            Vector3 position = transform.position + direction * distanceBetweenObjects * i; // �V�����ʒu�̌v�Z
            Instantiate(enemy, position, Quaternion.identity, transform); // �I�u�W�F�N�g��z�u
        }
        
    }
}
