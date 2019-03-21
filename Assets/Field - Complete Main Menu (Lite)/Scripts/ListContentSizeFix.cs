using UnityEngine;
using UnityEngine.UI;

public class ListContentSizeFix : MonoBehaviour {

    public Scrollbar scrollbar;
    public bool isReversed;

	void Start ()
    {
        if(isReversed == true)
        {
            scrollbar.value = 1;
        }

        else
        {
            scrollbar.value = 0;
        }
    }

    public void FixListSize()
    {
        if (isReversed == true)
        {
            scrollbar.value = 1;
        }

        else
        {
            scrollbar.value = 0;
        }
    }
}
