using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListTabsManager : MonoBehaviour
{
    [Header("PANEL LIST")]
    public List<GameObject> panels = new List<GameObject>();

    [Header("BUTTON LIST")]
    public List<GameObject> buttons = new List<GameObject>();

    // [Header("PANEL ANIMS")]
    private string panelFadeIn = "PL Panel In";
    private string panelFadeOut = "PL Panel Out";

    // [Header("BUTTON ANIMS")]
    private string buttonFadeIn = "PLB Pressed";
    private string buttonFadeOut = "PLB Pt Normal";

    private GameObject currentPanel;
    private GameObject nextPanel;

    private GameObject currentButton;
    private GameObject nextButton;

    [Header("SETTINGS")]
    public int currentPanelIndex = 0;
    private int currentButtonlIndex = 0;

    private Animator currentPanelAnimator;
    private Animator nextPanelAnimator;

    private Animator currentButtonAnimator;
    private Animator nextButtonAnimator;

    void Start()
    {
        currentButton = buttons[currentPanelIndex];
        currentButtonAnimator = currentButton.GetComponent<Animator>();
        currentButtonAnimator.Play(buttonFadeIn);

        currentPanel = panels[currentPanelIndex];
        currentPanelAnimator = currentPanel.GetComponent<Animator>();
        currentPanelAnimator.Play(panelFadeIn);
    }

    public void PanelAnim(int newPanel)
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
