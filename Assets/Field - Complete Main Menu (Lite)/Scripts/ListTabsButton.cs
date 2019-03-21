using UnityEngine;

public class ListTabsButton : MonoBehaviour
{
    private Animator buttonAnimator;

    void Start()
    {
        buttonAnimator = this.GetComponent<Animator>();
    }

    public void HoverButton()
    {
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("PLB Pressed"))
        {
            // do nothing because it's clicked
        }

        else
        {
            buttonAnimator.Play("PLB Hover");
        }
    }

    public void NormalizeButton()
    {
        if (buttonAnimator.GetCurrentAnimatorStateInfo(0).IsName("PLB Pressed"))
        {
            // do nothing because it's clicked
        }

        else
        {
            buttonAnimator.Play("PLB Normal");
        }
    }
}
