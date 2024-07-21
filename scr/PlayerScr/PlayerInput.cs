using Unity.VisualScripting;
using UnityEngine;


public class PlayerInput : MonoBehaviour
{    
    private Vector3 movement;

    public GameObject KeyInput(GameObject player, PlayerAction playerAction, PlayerAnimation playerAnimation, float velocity) {
        // キーボード入力を取得
        movement.x = Input.GetAxis("Horizontal");
        movement.z = Input.GetAxis("Vertical");
        player.transform.position = playerAction.PlayerMove(player, movement, velocity);
        playerAnimation.MoveAnimation(movement);

        playerAction.BigGirlMove(player.transform.position, movement, velocity);
        
        //ショット。zキーまたはゲームパッドのボタン1
        if ((Input.GetKey(KeyCode.Z))||(Input.GetButton("Fire1"))) {
            playerAction.ShootStart();
        }
        else {
            playerAction.SetIsShooting(false);
        }
        return player;
    }

    
}
