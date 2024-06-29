using Unity.VisualScripting;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{
    PlayerAction playerAction;
    PlayerAnimation playerAnimation;
    
    private Vector3 movement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAction = GetComponent<PlayerAction>();
        playerAnimation = GetComponent<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyInput();
    }


    void KeyInput() {
        // キーボード入力を取得
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        playerAction.PlayerMove(movement);
        playerAnimation.MoveAnimation(movement);
        
        //ショット
        if (Input.GetKey(KeyCode.Z)) {
            playerAction.ShootStart();
        }
        else {
            playerAction.SetIsShooting(false);
        }
    }

    
}
