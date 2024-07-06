using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

public class JsonLoader : MonoBehaviour
{
    // �f�R�[�h����f�[�^�̌^���`���܂�
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

    // JSON�t�@�C����ǂݍ��݁A�f�R�[�h���ĕԂ����\�b�h
    public StageData LoadJsonFile(string fileName) {
        TextAsset jsonTextAsset = Resources.Load<TextAsset>(fileName);
        if (jsonTextAsset == null) {
            Debug.LogError("�t�@�C����������܂���: " + fileName);
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

        //null�̃G���[�����Ȃ��B�~�X���G���[�ŋC�Â��悤�ɂ���
        GameObject prefab = databese.GetFormationPrefab(objData.prefab);
        Vector3 position = new Vector3(objData.x, 0, objData.z);

        if (objData.type == "formation") {
            GameObject formationPrefab = Instantiate(prefab, position, Quaternion.identity);
            GameObject enemyPrefab = databese.GetEnemyPrefab(objData.enemy);
            formationPrefab.GetComponent<IFormation>().StartFormation(enemyPrefab);
        }
        
        Debug.Log("����: " + objData.time);
        Debug.Log("�^�C�v: " + objData.type);
        Debug.Log("�v���n�u: " + objData.prefab);
        Debug.Log("X���W: " + objData.x);
        Debug.Log("Z���W: " + objData.z);
        Debug.Log("�G: " + objData.enemy);

        return isExec;
    }

}
