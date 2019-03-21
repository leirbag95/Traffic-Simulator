using UnityEngine;
using System.Collections;

public class ExitToSystem : MonoBehaviour
{
    public void ExitGame()
    {
        Debug.Log("It's working :)");
        Application.Quit();
    }
}
