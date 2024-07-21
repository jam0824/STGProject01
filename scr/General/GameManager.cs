using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // シングルトンのインスタンスを保持するための変数
    private static GameManager _instance;

    private int BULLET_NUM = 0; //今画面にある弾の数

    //画面サイズ
    public float TOP_BOTTOM = 4.0f;
    public float RIGHT_LEFT = 7.0f;
    
    public int POWERUP_ITEM_NUM = 100;  //アイテム何個でパワーアップするか
    private float ENEMY_X_ROTATION = 60f;   // 敵キャラを画面に対して60度傾ける（見やすくする）

    private int playerItemNum = 0;  //アイテム数
    private int playerGazeNum = 0;  //かすり数
    private float totalScore = 0;
    


    // プロパティを通じてインスタンスにアクセス
    public static GameManager Instance {
        get {
            // インスタンスが存在しない場合は新しいインスタンスを作成
            if (_instance == null) {
                // ゲームオブジェクトを新規に作成
                GameObject go = new GameObject("GameManager");
                _instance = go.AddComponent<GameManager>();

                // シーンが変更されても破棄されないようにする
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // シングルトンの初期化
    private void Awake() {
        Application.targetFrameRate = 60; //60FPSに設定
        // すでにインスタンスが存在する場合は、現在のゲームオブジェクトを破棄
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // ゲームマネージャーの初期化処理
    void Start() {
        
    }

    // ゲームマネージャーの更新処理
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
