using UnityEngine;
public class movimento : MonoBehaviour
{
    Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveAnimationLogic(movement);
    }

    void MoveAnimationLogic(Vector2 moveSpeed)
    {
        if (moveSpeed.y < 0)
        {
            animator.Play("idle");
            return;
        }

        if (moveSpeed.y > 0)
        {
            animator.Play("walk right");
            return;
        }

        if (moveSpeed.x < 0)
        {
            animator.Play("walk left");
            return;
        }

        if (moveSpeed.x > 0)
        {
            animator.Play("walk right");
            return;
        }
        animator.Play("idle");
    }
}