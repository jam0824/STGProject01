using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using System.IO;

public class StageManager : MonoBehaviour
{
    // デコードするデータの型を定義します
    [System.Serializable]
    public class ObjectData
    {
        public float time;
        public string type;
        public string prefab;
        public float x;
        public float z;
        public float angle;
        public int numberOfObjects;
        public float DistanceBetweenObjects;
        public string enemy;
        public float moveSpeed;
        public float moveDir;
    }

    [System.Serializable]
    public class StageData
    {
        public List<ObjectData> stage;
    }

    public float scrollSpeed = 0.01f;
    public bool BOSS_MODE = true;
    bool progressMode = true;
    public GameObject BigGirlPrefab;
    Database databese;
    StageData stageData;
    float startTime = 0;
    float stopTime = 0;
    float minusTime = 0;

    string jsonFile = "StripOff/stage1.json";

    public GameObject GetBigGirlPrefab() { return BigGirlPrefab; }

    /* ビルドするときはこっちが必要。stage1.jsonをResourcesに移す
    // JSONファイルを読み込み、デコードして返すメソッド
    public StageData LoadJsonFile(string fileName) {
        TextAsset jsonTextAsset = Resources.Load<TextAsset>(fileName);
        if (jsonTextAsset == null) {
            Debug.LogError("ファイルが見つかりません: " + fileName);
            return null;
        }
        StageData data = JsonUtility.FromJson<StageData>(jsonTextAsset.text);
        return data;
    }
    */
    public StageData LoadJsonFile(string fileName) {
        string filePath = Path.Combine(Application.dataPath, fileName);

        if (!File.Exists(filePath)) {
            Debug.LogError("ファイルが見つかりません: " + filePath);
            return null;
        }

        string jsonText = File.ReadAllText(filePath);
        StageData data = JsonUtility.FromJson<StageData>(jsonText);
        return data;
    }

    void Start() {
        startTime = Time.time;
        databese = GetComponent<Database>();
        stageData = LoadJsonFile(jsonFile);


    }
    void Update() {
        if (stageData == null) return;
        for (int i = 0; i < stageData.stage.Count; i++) {
            if (progressMode) {
                bool isExec = MakeObject(stageData.stage[i]);
                if (isExec)stageData.stage.RemoveAt(i);
            }
        }
    }

    bool MakeObject(ObjectData objData) {
        bool isExec = false;
        float exeTime = startTime + objData.time;
        // minusTimeは止めていた時間分。中ボスなど
        if (Time.time - minusTime < exeTime) return isExec;
        isExec = true;

        Vector3 position = new Vector3(objData.x, 0, objData.z);

        if (objData.type == "formation") {
            MakeFormation(objData, position);
        }
        else if (objData.type == "sprite") {
            MakeSprite(objData, position);
        }


        Debug.Log("時間: " + objData.time + 
            "タイプ: " + objData.type + 
            "プレハブ: " + objData.prefab + 
            "X座標: " + objData.x + 
            "Z座標: " + objData.z + 
            "敵: " + objData.enemy);


        return isExec;
    }

    GameObject MakeFormation(ObjectData objData, Vector3 position) {
        //nullのエラー処理なし。ミスをエラーで気づくようにする
        GameObject prefab = databese.GetFormationPrefab(objData.prefab);

        GameObject formationPrefab = Instantiate(prefab, position, Quaternion.identity);
        GameObject enemyPrefab = databese.GetEnemyPrefab(objData.enemy);
        formationPrefab.GetComponent<IFormation>().StartFormation(
            enemyPrefab,
            objData.numberOfObjects,
            objData.DistanceBetweenObjects,
            objData.angle,
            objData.moveSpeed,
            objData.moveDir);
        return formationPrefab;
    }

    GameObject MakeSprite(ObjectData objData, Vector3 position) {
        GameObject prefab = databese.GetSpritePrefab(objData.prefab);
        GameObject spritePrefab = Instantiate(prefab, position, Quaternion.identity);
        return spritePrefab;
    }

    public bool StopProgress() {
        this.progressMode = false;
        stopTime = Time.time;
        return this.progressMode;
    }

    // ボスを倒した後はまた1秒からスタートになる
    // よってステージファイルも以降1秒から。
    // 実行したデータは消しているので前の1秒に戻ることはない
    public bool StartProgress() {
        this.progressMode = true;
        minusTime = Time.time - stopTime;
        return this.progressMode;
    }

}
