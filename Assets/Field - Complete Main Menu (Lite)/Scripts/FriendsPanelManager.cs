using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FriendsPanelManager : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator panelAnimator;
    private bool isOpen = false;

    void Start()
    {
        panelAnimator = this.GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panelAnimator.Play("Friends Panel In");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panelAnimator.Play("Friends Panel Out");
    }
}