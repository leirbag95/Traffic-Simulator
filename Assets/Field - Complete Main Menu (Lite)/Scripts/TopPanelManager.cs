using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopPanelManager : MonoBehaviour
{
    [Header("PANEL LIST")]
    public List<GameObject> panels = new List<GameObject>();

    [Header("BUTTON LIST")]
    public List<GameObject> buttons = new List<GameObject>();

    // [Header("PANEL ANIMS")]
    private string panelFadeIn = "MM Panel In";
    private string panelFadeOut = "MM Panel Out";

    // [Header("BUTTON ANIMS")]
    private string buttonFadeIn = "TB Hover to Pressed";
    private string buttonFadeOut = "TB Pressed to Normal";

    private GameObject currentPanel;
    private GameObject nextPanel;

    private GameObject currentButton;
    private GameObject nextButton;

    [Header("SETTINGS")]
    public int currentPanelIndex = 0;
    private int currentButtonlIndex = 0;
    public bool enableProfileModel = true;

    [Header("RESOURCES")]
    public GameObject profileModel;

    private Animator currentPanelAnimator;
    private Animator nextPanelAnimator;

    private Animator currentButtonAnimator;
    private Animator nextButtonAnimator;

    void Start ()
    {
        currentButton = buttons[currentPanelIndex];
        currentButtonAnimator = currentButton.GetComponent<Animator>();
        currentButtonAnimator.Play(buttonFadeIn);

        currentPanel = panels[currentPanelIndex];
        currentPanelAnimator = currentPanel.GetComponent<Animator>();
        currentPanelAnimator.Play(panelFadeIn);

        if(enableProfileModel == true)
        {
            profileModel.SetActive(true);
        }
        else
        {
            profileModel.SetActive(false);
        }
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
