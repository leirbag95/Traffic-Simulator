using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TooltipManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("SETTINGS")]
    public Text tooltipTxtObj;
    public string tooltipText;

    private Animator tooltipAnimator;

    void Start()
    {
        tooltipAnimator = GetComponent<Animator>();
        tooltipTxtObj.text = tooltipText;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipAnimator.Play("Tooltip In");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipAnimator.Play("Tooltip Out");
    }
}
