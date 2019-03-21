using UnityEngine;
using UnityEngine.UI;

public class ToggleManager : MonoBehaviour
{
	[Header("TOGGLE")]
	public Toggle toggleObject;

	[Header("ANIMATORS")]
	public Animator toggleAnimator;

    // [Header("ANIM NAMES")]
    private string toggleOn = "Toggle On";
    private string toggleOff = "Toggle Off";

	void Start ()
	{
		this.toggleObject.GetComponent<Toggle>();
		toggleObject.onValueChanged.AddListener(TaskOnClick);

        if (toggleObject.isOn)
        {
            toggleAnimator.Play(toggleOn);
        }

        else
        {
            toggleAnimator.Play(toggleOff);
        }
    }

	void TaskOnClick(bool value)
	{
		if (toggleObject.isOn) 
		{
			toggleAnimator.Play(toggleOn);
		} 

		else 
		{
			toggleAnimator.Play(toggleOff);
		}
	}
}