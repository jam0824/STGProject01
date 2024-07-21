using UnityEngine;

public class EnemyStopMove : MonoBehaviour,IEnemyMove
{
    public Vector3 targetPosition;  // �ړ���̃^�[�Q�b�g�ʒu
    private float speed = 2f;  // �ړ����x
    private Vector3 startPosition;  // �ړ��J�n�ʒu
    private float journeyLength;  // �ړ�����
    private float startTime;  // �ړ��J�n����
    EnemyAnimation enemyAnimation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
        startPosition = transform.position;
        journeyLength = Vector3.Distance(startPosition, targetPosition);
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = SmoothMovement(this.journeyLength, this.startPosition, this.targetPosition);
    }

    //���X�ɒx���Ȃ�ړ�
    Vector3 SmoothMovement(float journeyLength, Vector3 startPosition, Vector3 targetPosition) {
        //�o�ߎ��Ԃɂ��ړ���
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;

        // SmoothStep���g�p���Ċ��炩�Ɍ���������
        float smoothStep = Mathf.SmoothStep(0, 1, fractionOfJourney);
        return Vector3.Lerp(startPosition, targetPosition, smoothStep);
    }


    public void EnemyMove(Rigidbody rb, EnemyAnimation enemyAnimation, float angle, float speed, bool isMoveWithScroll) {
        this.speed = speed;
        float angleRad = angle * Mathf.Deg2Rad; //�p�x�����W�A���ɕϊ�
        //�������o��
        Vector3 direction = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad));
        //�������ړ���������Ɍ�����
        transform.rotation = enemyAnimation.EnemyRotation(direction);
        // world�ɑ΂���x�ŌX����B������₷�����邽��
        transform.rotation = enemyAnimation.WorldRotateX(this.transform, GameManager.Instance.GetEnemyXRotation());
    }
}
