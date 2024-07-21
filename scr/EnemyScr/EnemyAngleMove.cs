using Unity.VisualScripting;
using UnityEngine;

public class EnemyAngleMove : MonoBehaviour,IEnemyMove
{
    public bool isLookDirection = true;
    EnemyAnimation enemyAnimation;

    protected Rigidbody rb;
    protected bool isMoveWithScroll = false;
    protected StageManager stageManager;
    protected Utilities utilities;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stageManager = GameObject.Find("StageManager").GetComponent<StageManager>();
        utilities = GameObject.Find("GameManager").GetComponent<Utilities>();
    }


    // Update is called once per frame
    void Update()
    {
        //�����X�N���[���ƂƂ��ɓ����������Ȃ�B��������Ȃ�
        if (isMoveWithScroll) MoveWithScroll(stageManager.scrollSpeed);
    }

    public void MoveWithScroll(float scrollSpeed) {
        Vector3 pos = transform.position;
        pos.z -= scrollSpeed;
        transform.position = pos;
    }

    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.isMoveWithScroll = isMoveWithScroll;
        float angleRad = angle * Mathf.Deg2Rad; //�p�x���烉�W�A���ɕϊ�
        //���W�A�����g���ăx�N�g�����o��
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));   
        rb.linearVelocity = direction * speed;
        //�ړ������������������Ƃ�
        if(isLookDirection) transform.rotation = enemyAnimation.EnemyRotation(direction);
        //���[���h��X���ɑ΂��ČX����B�G�̊炪���₷���悤�ɂ���
        transform.rotation = enemyAnimation.WorldRotateX(this.transform, GameManager.Instance.GetEnemyXRotation());

    }

}
