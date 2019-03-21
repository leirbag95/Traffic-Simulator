using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsPanelManager : MonoBehaviour {

    [Header("NEWS LIST")]
    public List<GameObject> panels = new List<GameObject>();

    [Header("RESOURCES")]
    public Slider slider;

    // [Header("PANEL ANIMS")]
    private string panelFadeIn = "NPI In";
    private string panelFadeOut = "NPI Out";

    // [Header("INDICATOR ANIMS")]
    private string buttonFadeIn = "NPIS In";
    private string buttonFadeOut = "NPIS Out";

    private GameObject currentPanel;
    private GameObject nextPanel;

    private GameObject currentButton;
    private GameObject nextButton;

    [Header("SETTINGS")]
    public int currentPanelIndex = 0;
    [Range(1, 25)]public float speed = 3f;
    private int currentButtonlIndex = 0;

    private Animator currentPanelAnimator;
    private Animator nextPanelAnimator;

    private Animator currentButtonAnimator;
    private Animator nextButtonAnimator;

    int newPanel;
    int sizeOfList;
    float sliderValue;

    void Start()
    {
        sizeOfList = panels.Count;
        sizeOfList -= 1;
        InvokeRepeating("ChangeNew", speed, speed);
        slider.maxValue = sizeOfList;
        slider.value = currentPanelIndex;
    }

    void ChangeNew()
    {
        if (newPanel == sizeOfList)
        {
            nextPanelAnimator = nextPanel.GetComponent<Animator>();
            nextPanelAnimator.Play(panelFadeOut);

            newPanel = 0;
            currentPanelIndex = 0;

            nextPanel = panels[currentPanelIndex];

            nextPanelAnimator = nextPanel.GetComponent<Animator>();
            nextPanelAnimator.Play(panelFadeIn);
        }

        else
        {
            currentPanel = panels[currentPanelIndex];
            currentPanelIndex = newPanel;

            currentPanelAnimator = currentPanel.GetComponent<Animator>();

            currentPanelIndex += 1;
            nextPanel = panels[currentPanelIndex];

            nextPanelAnimator = nextPanel.GetComponent<Animator>();

            currentPanelAnimator.Play(panelFadeOut);
            nextPanelAnimator.Play(panelFadeIn);

            newPanel += 1;
        }
        slider.value = currentPanelIndex;
    }

    public void SwitchClick(int newPanel)
    {
        if (newPanel == sizeOfList)
        {
            nextPanelAnimator = nextPanel.GetComponent<Animator>();
            nextPanelAnimator.Play(panelFadeOut);

            newPanel = 0;
            currentPanelIndex = 0;

            nextPanel = panels[currentPanelIndex];

            nextPanelAnimator = nextPanel.GetComponent<Animator>();
            nextPanelAnimator.Play(panelFadeIn);
        }

        else
        {
            currentPanel = panels[currentPanelIndex];
            currentPanelIndex = newPanel;

            currentPanelAnimator = currentPanel.GetComponent<Animator>();

            currentPanelIndex += 1;
            nextPanel = panels[currentPanelIndex];

            nextPanelAnimator = nextPanel.GetComponent<Animator>();

            currentPanelAnimator.Play(panelFadeOut);
            nextPanelAnimator.Play(panelFadeIn);

            newPanel += 1;
        }
    }
}
