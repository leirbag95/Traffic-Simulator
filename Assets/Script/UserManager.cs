using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Utility;

public class UserManager : MonoBehaviour {


    // MARK: Panel
    public GameObject Panel;

    // MARK: public GameObject : LIGHT
    public Light directionalLight;
    public Slider sliderLight;
    public Toggle toggleLight;
    public AutoMoveAndRotate lightMotion;

    // MARK: public GameObject : Vehicle
    public Slider sliderInstantiateFlow;
    public Text textInstantiateFlow;
    public Button btnInstantiateFlow;

    // MARK: Information
    public Text vehicleNumber;

    // MARK: TimeScaler
    public Slider sliderTimeScale;

    // MARK: private variable(s)
    private float speed = 25.0f;

	// Use this for initialization
	void Start () {
        lightMotion.enabled = toggleLight.isOn;
    }
	
	// Update is called once per frame
	void Update () {
        CameraMovement();
        GetAndDisplayVehicleNumber();
    }

    // MARK: public function


    /*
     * Gestion du deplacement de la camera par l'utilisateur
    */
    public void CameraMovement() 
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.position += movement * speed * Time.deltaTime;

        //Zoom de la camera
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                                  1.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            transform.position += new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed,
                                                1.0f, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed);
        }
    }

    /*
     * Compte et affiche le nombre de vehicle actuel sur la route
    */

    public void GetAndDisplayVehicleNumber() {
        vehicleNumber.text = GameObject.FindGameObjectsWithTag("Vehicle").Length.ToString();
    }

    /*
     * Gestion du TimeScale par l'utilisateur
    */

    public void TimeScaleManagement()
    {
        Time.timeScale = sliderTimeScale.value;
    }

    public void StopTimeScale(Toggle toggle)
    {
        if (!toggle.isOn)
        {
            Time.timeScale = 0;
        } else {
            Time.timeScale = sliderTimeScale.value;
        }
    }

    /*
     * Detruit tous les véhicles
    */

    public void ClearTheMap()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Vehicle").Length;i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("Vehicle")[i]);
        }

        int j = GameObject.FindGameObjectsWithTag("Fence").Length - 1;
        while ( j >= 0) 
        {
            GameObject.FindGameObjectsWithTag("Fence")[j].SetActive(false);
            j--;
        }

    }

    /*
     * Gestion du temps et de la temperature par l'utilisateur
     */

    public void WeatherManagement() 
    {
        float degree = (sliderLight.value * 360);
        //int hour = (int)(degree * 23);
        //labelLight.text = hour.ToString() + "H00";
        directionalLight.transform.localEulerAngles = new Vector3(degree, 0, 0);
    }

    public void ToggleSetLoop()
    {
        lightMotion.enabled = toggleLight.isOn;
    }


    /*
     * Gestion du flow de création de vehicle par seconde
    */
    public void InstantiateFlowManagement()
    {
        var value = ((int) sliderInstantiateFlow.value).ToString();
        textInstantiateFlow.text = value + " Sec.";
        btnInstantiateFlow.GetComponentInChildren<Text>().text = "Apply";
    }

    public void InstantiateFlowButton(Button button)
    {
        var SpawnSettings = GameObject.FindGameObjectsWithTag("SpawnPoint");
        if (button.GetComponentInChildren<Text>().text == "Apply") {
            for (int i = 0; i < SpawnSettings.Length; i++)
            {
                var components = GameObject.FindGameObjectsWithTag("SpawnPoint")[i].GetComponent<SpawnSettings>();
                Debug.Log(sliderInstantiateFlow.value);
                components.StartCoroutineOfVehicle(sliderInstantiateFlow.value);
            }
            button.GetComponentInChildren<Text>().text = "Stop";
        } else {
            for (int i = 0; i < SpawnSettings.Length; i++)
            {
                var components = GameObject.FindGameObjectsWithTag("SpawnPoint")[i].GetComponent<SpawnSettings>();
                components.StopCoroutineOfVehicle();
            }
            button.GetComponentInChildren<Text>().text = "Apply";
        }
    }
    // MARK : public function Button

    public void HidePanel()
    {
        Panel.SetActive(false);
    }

    public void ShowePanel()
    {
        Panel.SetActive(true);
    }

}
