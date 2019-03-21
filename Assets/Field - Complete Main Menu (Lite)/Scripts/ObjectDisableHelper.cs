using UnityEngine;

public class ObjectDisableHelper : MonoBehaviour
{
    private GameObject thisObject;
    private ObjectDisableHelper script;
    public bool disableScript = false;

    void Start()
    {
        script = this.GetComponent<ObjectDisableHelper>();

        if (disableScript == true)
        {
            script.enabled = false;
        }
    }
}