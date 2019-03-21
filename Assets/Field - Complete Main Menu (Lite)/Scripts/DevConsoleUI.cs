using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevConsoleUI : MonoBehaviour {

	public GameObject consoleObject;

	bool isOn = false;
	bool isReady = false;

	void Start()
	{
		consoleObject.SetActive(false);
		isReady = true;
	}

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.F12))
		{
			Show();
		}
	}

	public void Show()
	{
		if(Input.GetKeyDown(KeyCode.F12) && isOn == false)
		{
			consoleObject.SetActive(true);
			isOn = true;
		}
		else
		{
			consoleObject.SetActive(false);
			isOn = false;
		}
	}
}
