using UnityEngine;
using UnityEngine.UI;

public class SwitchManager : MonoBehaviour {

	[Header("SWITCH")]
	public bool isOn;
    public Animator switchAnimator;

    private string onTransition = "Switch On";
    private string offTransition = "Switch Off";

    void Start ()
	{
        if (isOn == true)
        {
            switchAnimator.Play(onTransition);
        }

        else
        {
            switchAnimator.Play(offTransition);
        }
    }

	public void AnimateSwitch()
	{
		if (isOn == true) 
		{
            switchAnimator.Play(offTransition);
            isOn = false;
        } 

		else
		{
            switchAnimator.Play(onTransition);
            isOn = true;
        }
	}
}