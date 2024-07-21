using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �V���O���g���̃C���X�^���X��ێ����邽�߂̕ϐ�
    private static GameManager _instance;

    private int BULLET_NUM = 0; //����ʂɂ���e�̐�

    //��ʃT�C�Y
    public float TOP_BOTTOM = 4.0f;
    public float RIGHT_LEFT = 7.0f;
    
    public int POWERUP_ITEM_NUM = 100;  //�A�C�e�����Ńp���[�A�b�v���邩
    private float ENEMY_X_ROTATION = 60f;   // �G�L��������ʂɑ΂���60�x�X����i���₷������j

    private int playerItemNum = 0;  //�A�C�e����
    private int playerGazeNum = 0;  //�����萔
    private float totalScore = 0;
    


    // �v���p�e�B��ʂ��ăC���X�^���X�ɃA�N�Z�X
    public static GameManager Instance {
        get {
            // �C���X�^���X�����݂��Ȃ��ꍇ�͐V�����C���X�^���X���쐬
            if (_instance == null) {
                // �Q�[���I�u�W�F�N�g��V�K�ɍ쐬
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();

                // �V�[�����ύX����Ă��j������Ȃ��悤�ɂ���
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // �V���O���g���̏�����
    private void Awake() {
        Application.targetFrameRate = 60; //60FPS�ɐݒ�
        // ���łɃC���X�^���X�����݂���ꍇ�́A���݂̃Q�[���I�u�W�F�N�g��j��
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // �Q�[���}�l�[�W���[�̏���������
    void Start() {
        
    }

    // �Q�[���}�l�[�W���[�̍X�V����
    void Update() {

    }

    public int CalcBulletNum(int num) {
        BULLET_NUM += num;
        return BULLET_NUM;
    }
    public int GetBulletNum() {
        return BULLET_NUM; 
    }

    public int CalcItemNum(int num) {
        playerItemNum++;
        return playerItemNum;
    }
    public int GetItemNum() {
        return playerItemNum;
    }
    
    public float GetEnemyXRotation() {
        return ENEMY_X_ROTATION;
    }

    public void AddTotalScore(float score) {
        totalScore += score;
    }
    public float GetTotalScore() { return totalScore; }
    public void AddGaze() {
        playerGazeNum++;
    }
    public int GetGazeNum() {return playerGazeNum;}
}
