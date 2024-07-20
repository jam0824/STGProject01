using UnityEngine;

public class Item : MonoBehaviour
{
    float startTime = 0;
    float chaseSpeed = 10f;
    Vector3 startPos;
    bool isChase = false;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChase) {
            if(player != null) ChasePlayer(player.transform.position, transform.position);
        }
        else {
            transform.position = Move();
        }
    }

    void ChasePlayer(Vector3 playerPos, Vector3 mePos) {
        Vector3 direction = (playerPos - mePos).normalized;
        Vector3 newPosition = transform.position + direction * chaseSpeed * Time.deltaTime;
        newPosition.y = 0f;
        transform.position = newPosition;
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
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "ItemTrigger") {
            if (!isChase) isChase = true; 
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            SoundManager.Instance.PlaySE(GameConstants.SE_GET_ITEM);
            GetItem();
        }
    }

    void GetItem() {
        GameManager.Instance.CalcItemNum(1);
        GameManager.Instance.AddTotalScore(GameConstants.SCORE_TIMES);
        Destroy(gameObject);
    }
    public void SetPlayer(GameObject player) {
        this.player = player;
    }
}
