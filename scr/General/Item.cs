using UnityEngine;

public class Item : MonoBehaviour
{
    float startTime = 0;
    Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Move();
    }

    Vector3 Move() {
        float x = Time.time - startTime;
        float z = GetHeight(x);
        return new Vector3(startPos.x, 0, startPos.z + z);
    }

    // (2,2)Çí∏ì_Ç∆Ç∑ÇÈìÒéüä÷êî
    float GetHeight(float t) {
        float z = -0.5f * t * t + 2f * t;
        return z;

    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            SoundManager.Instance.PlaySE(GameConstants.SE_GET_ITEM);
            GetItem();
        }
    }

    void GetItem() {
        GameManager.Instance.CalcItemNum(1);
        Destroy(gameObject);
    }
}
