using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class JsonLoader : MonoBehaviour
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
        public string enemy;
    }

    [System.Serializable]
    public class StageData
    {
        public List<ObjectData> stage;
    }

    Database databese;
    StageData stageData;
    float startTime = 0;

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

    void Start() {
        startTime = Time.time;
        databese = GetComponent<Database>();
        stageData = LoadJsonFile("stage1");


    }
    void Update() {
        if (stageData == null) return;
        for (int i = 0; i < stageData.stage.Count; i++) {
            bool isExec = MakeObject(stageData.stage[i]);
            if (isExec) stageData.stage.RemoveAt(i);
        }
    }

    bool MakeObject(ObjectData objData) {
        bool isExec = false;
        float exeTime = startTime + objData.time;
        if (Time.time < exeTime) return isExec;
        isExec = true;

        //nullのエラー処理なし。ミスをエラーで気づくようにする
        GameObject prefab = databese.GetFormationPrefab(objData.prefab);
        Vector3 position = new Vector3(objData.x, 0, objData.z);

        if (objData.type == "formation") {
            GameObject formationPrefab = Instantiate(prefab, position, Quaternion.identity);
            GameObject enemyPrefab = databese.GetEnemyPrefab(objData.enemy);
            formationPrefab.GetComponent<IFormation>().StartFormation(enemyPrefab);
        }
        
        Debug.Log("時間: " + objData.time);
        Debug.Log("タイプ: " + objData.type);
        Debug.Log("プレハブ: " + objData.prefab);
        Debug.Log("X座標: " + objData.x);
        Debug.Log("Z座標: " + objData.z);
        Debug.Log("敵: " + objData.enemy);

        return isExec;
    }

}
