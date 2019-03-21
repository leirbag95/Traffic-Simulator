using UnityEngine;

public class AnimatorDisableHelper : MonoBehaviour
{
    private Animator animator;
    private AnimatorDisableHelper script;
    public bool disableScript = false;

    void Start()
    {
        animator = this.GetComponent<Animator>();
        animator.enabled = false;

        if (disableScript == true)
        {
            script = this.GetComponent<AnimatorDisableHelper>();
            script.enabled = false;
        }
    }
}