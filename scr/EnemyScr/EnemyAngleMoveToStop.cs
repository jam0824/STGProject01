using UnityEngine;

public class EnemyAngleMoveToStop : EnemyAngleMove
{
    public float stopTime = 0;
    public bool isLookAtPlayer = true;
    float startTime;
    GameObject player;
    Rigidbody rb;
    Utilities utilities;
    float rotationSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startTime = Time.time;
        rb = GetComponent<Rigidbody>();
        utilities = new Utilities();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((stopTime != 0)&&(Time.time - startTime >= stopTime)) 
            StopMove();
        if ((isLookAtPlayer)&&(rb.linearVelocity == Vector3.zero))
            this.transform.rotation = utilities.LookAtPlayer(player.transform, this.transform, rotationSpeed);
    }

    void StopMove() {
        rb.linearVelocity = Vector3.zero;
    }

}
