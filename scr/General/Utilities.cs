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
        // �v���C���[�̕������v�Z
        Vector3 direction = player.position - me.position;
        direction.y = 0; // ���������������l���i�㉺�̉�]�𖳎��j

        // �v���C���[�̕����Ɍ�������]���v�Z
        Quaternion targetRotation = Quaternion.LookRotation(direction);

        // ���݂̉�]����v���C���[�̕����ւ̉�]�����X�ɓK�p
        return Quaternion.Lerp(me.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    
}
