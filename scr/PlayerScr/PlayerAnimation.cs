using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveAnimation(Vector3 movement) {
        // アニメーションの設定
        if (movement != Vector3.zero) {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.z);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
    }

    
}
