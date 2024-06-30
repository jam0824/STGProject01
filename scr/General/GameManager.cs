using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // シングルトンのインスタンスを保持するための変数
    private static GameManager _instance;

    private int BULLET_NUM = 0;
    

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
        // 更新コードをここに追加
    }

    public int CalcBulletNum(int num) {
        BULLET_NUM += num;
        return BULLET_NUM;
    }
    public int GetBulletNum() {
        return BULLET_NUM; 
    }

    


}
