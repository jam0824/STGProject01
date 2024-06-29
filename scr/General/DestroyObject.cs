using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float BulletLife;

    private float deadTime;

    private void Start() {
        deadTime = Time.time + BulletLife;
    }

    private void Update() {
        if (Time.time > deadTime) {
            GameObject.Destroy(gameObject);
        }
    }
}
