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
        // �L�[�{�[�h���͂��擾
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        playerAction.PlayerMove(movement);
        playerAnimation.MoveAnimation(movement);
        
        //�V���b�g
        if (Input.GetKey(KeyCode.Z)) {
            playerAction.ShootStart();
        }
        else {
            playerAction.SetIsShooting(false);
        }
    }

    
}
