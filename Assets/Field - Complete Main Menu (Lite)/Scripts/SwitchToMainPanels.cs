using UnityEngine;

public class SwitchToMainPanels : MonoBehaviour
{
    [Header("RESOURCES")]
    private Animator loginScreenAnimator;
    public Animator mainPanelAnimator;
    public Animator shadowsAnimator;

    [Header("SETTINGS")]
    public bool isLoginScreen;

    void Start()
    {
        loginScreenAnimator = this.GetComponent<Animator>();

        if (isLoginScreen == false)
        {
            loginScreenAnimator.Play("SS Fade-out");
            mainPanelAnimator.Play("Main Panel Opening");
            shadowsAnimator.Play("CG Fade-in");
        }
    }

    public void Animate()
    {
        loginScreenAnimator = this.GetComponent<Animator>();

        if(isLoginScreen == true)
        {
            loginScreenAnimator.Play("SS w Login Fade-out");
        }

        mainPanelAnimator.Play("Main Panel Opening");
        shadowsAnimator.Play("CG Fade-in");
    }
}