using UnityEngine;
using System.Collections;

public class GasAnimation : MonoBehaviour
{
     Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public IEnumerator DestroyObj()
    {
        animator.Play("gas");
        AnimatorStateInfo AnimationState = animator.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(AnimationState.length);
        Destroy(gameObject);
    }
}
