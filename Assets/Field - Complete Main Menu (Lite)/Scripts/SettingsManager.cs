using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour 
{
	[Header("TITLE")]
	public Text currentTitle;
	public Text newTitle;
	public Animator titleAnimator;

	[Header("PANEL LIST")]
    public List<GameObject> panels = new List<GameObject>();

    [Header("BUTTON LIST")]
    public List<GameObject> buttons = new List<GameObject>();

    // [Header("PANEL ANIMS")]
    private string panelFadeIn = "SC Panel In";
    private string panelFadeOut = "SC Panel Out";

    // [Header("BUTTON ANIMS")]
    private string buttonFadeIn = "TB Hover to Pressed";
    private string buttonFadeOut = "TB Pressed to Normal";

    private GameObject currentPanel;
    private GameObject nextPanel;

    private GameObject currentButton;
    private GameObject nextButton;

    // [Header("SETTINGS")]
    private int currentPanelIndex = 0;
    private int currentButtonlIndex = 0;

    private Animator currentPanelAnimator;
    private Animator nextPanelAnimator;

    private Animator currentButtonAnimator;
    private Animator nextButtonAnimator;

	bool isNew = false;
	
	public void ChangeTitle (string newTxt) 
	{	
		if(isNew == false)
		{
			titleAnimator.Play("Show New Title");
			isNew = true;
		}

		else
		{
			titleAnimator.Play("Show Current Title");
			isNew = false;
		}

		if (titleAnimator.GetCurrentAnimatorStateInfo(0).IsName("Show New Title"))
        {
			currentTitle.text = newTxt;
		}

		else
		{		
			newTitle.text = newTxt;
		}
	}

    void Start ()
    {
        currentButton = buttons[currentPanelIndex];
        currentButtonAnimator = currentButton.GetComponent<Animator>();
        currentButtonAnimator.Play(buttonFadeIn);

        currentPanel = panels[currentPanelIndex];
        currentPanelAnimator = currentPanel.GetComponent<Animator>();
        currentPanelAnimator.Play(panelFadeIn);
    }

    public void PanelAnim (int newPanel)
    {
        if (newPanel != currentPanelIndex)
        {
            currentPanel = panels[currentPanelIndex];

            currentPanelIndex = newPanel;
            nextPanel = panels[currentPanelIndex];

            currentPanelAnimator = currentPanel.GetComponent<Animator>();
            nextPanelAnimator = nextPanel.GetComponent<Animator>();

            currentPanelAnimator.Play(panelFadeOut);
            nextPanelAnimator.Play(panelFadeIn);

            currentButton = buttons[currentButtonlIndex];

            currentButtonlIndex = newPanel;
            nextButton = buttons[currentButtonlIndex];

            currentButtonAnimator = currentButton.GetComponent<Animator>();
            nextButtonAnimator = nextButton.GetComponent<Animator>();

            currentButtonAnimator.Play(buttonFadeOut);
            nextButtonAnimator.Play(buttonFadeIn);
        }
    }
}
