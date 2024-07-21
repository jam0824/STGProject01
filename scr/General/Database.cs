using UnityEngine;
using System.Collections.Generic;

public class Database : MonoBehaviour
{
    public List<GameObject> formationPrefabs;
    public List<string> formationKeys;
    public List<GameObject> enemyPrefabs;
    public List<string> enemyKeys;
    public List<GameObject> spritePrefabs;
    public List<string> spriteKeys;

    public GameObject GetFormationPrefab(string prefabName) {
        return GetPrefabFromKeys(prefabName, formationPrefabs, formationKeys);
    }

    public GameObject GetEnemyPrefab(string prefabName) {
        return GetPrefabFromKeys(prefabName, enemyPrefabs, enemyKeys);
    }

    public GameObject GetSpritePrefab(string prefabName) {
        return GetPrefabFromKeys(prefabName, spritePrefabs, spriteKeys);
    }

    //key‚É‘Î‰ž‚µ‚½prefab‚ð•Ô‚·
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
