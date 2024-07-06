using UnityEngine;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public List<GameObject> formationPrefabs;
    public List<string> formationKeys;
    public List<GameObject> enemyPrefabs;
    public List<string> enemyKeys;

    public GameObject GetFormationPrefab(string prefabName) {
        return GetPrefabFromKeys(prefabName, formationPrefabs, formationKeys);
    }

    public GameObject GetEnemyPrefab(string prefabName) {
        return GetPrefabFromKeys(prefabName, enemyPrefabs, enemyKeys);
    }


    GameObject GetPrefabFromKeys(string prefabName, List<GameObject> prefabs, List<string> keys) {
        int index = -1;
        for (int i = 0; i < keys.Count; i++) {
            if (keys[i] == prefabName) {
                index = i; break;
            }
        }
        if (index == -1) return null;
        return prefabs[index];
    }


}
