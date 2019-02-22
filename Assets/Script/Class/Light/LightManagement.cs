using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Timers;
using System.Threading;
using UnityEditor;


public class LightManagement : MonoBehaviour {

    //MARK: UnityEngine variable(s)
    public TrafficLight CNOTrafficLight;
    public TrafficLight CNETrafficLight;
    public TrafficLight CSETrafficLight;
    public TrafficLight CSOTrafficLight;

    //MARK: private variable(s)
    int count = 0;

    private void Start()
    {

        StartCoroutine(ChangeLightState(2));
        //StartCoroutine(HorizontalLightCrossroad(1.0f));
    }



    //MARK: private func
    private IEnumerator ChangeLightState(int seconds) {
       
        while (true) {
            yield return new WaitForSeconds(seconds);
            Debug.Log(CNOTrafficLight.RedLight.activeSelf);
            if (CNOTrafficLight.gameObject.activeSelf)
            {
                CNOTrafficLight.gameObject.SetActive(false);
                CSETrafficLight.RedLight.SetActive(false);
                CNOTrafficLight.GreenLight.SetActive(true);
                CSETrafficLight.GreenLight.SetActive(true);
                CSOTrafficLight.RedLight.SetActive(true);
                CNETrafficLight.RedLight.SetActive(true);
                CSOTrafficLight.GreenLight.SetActive(false);
                CNETrafficLight.GreenLight.SetActive(false);
            }
            else
            {
                CNOTrafficLight.gameObject.SetActive(true);
                CSETrafficLight.RedLight.SetActive(true);
                CNOTrafficLight.GreenLight.SetActive(false);
                CSETrafficLight.GreenLight.SetActive(false);
                CSOTrafficLight.RedLight.SetActive(false);
                CNETrafficLight.RedLight.SetActive(false);
                CSOTrafficLight.GreenLight.SetActive(true);
                CNETrafficLight.GreenLight.SetActive(true);
            }
        }
    }

}

