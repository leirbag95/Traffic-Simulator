using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExampleSceneFree : MonoBehaviour {
	public GameObject DirectionalLight;
	public bool UIVisualizer = true;

	bool controllsIsNull;
	bool playerIsNull;
	MSSceneControllerFree controls;

	Image backGround;
	Text controlsText;
	Text enterAndExitText;
	Text startVehicleText;
	Text reloadText;
	Text handBrakeText;
	Text switchCamerasText;
	Text pauseText;
	GameObject player;

	void Awake(){
		controllsIsNull = false;
		controls = GameObject.FindObjectOfType (typeof(MSSceneControllerFree))as MSSceneControllerFree;
		backGround = transform.Find ("Canvas/Background").GetComponent<Image> ();
		controlsText = transform.Find ("Canvas/Background/ControlText").GetComponent<Text> ();
		enterAndExitText = transform.Find ("Canvas/Background/Enter_ExitVehicle").GetComponent<Text> ();
		startVehicleText = transform.Find ("Canvas/Background/StartTheVehicle").GetComponent<Text> ();
		reloadText = transform.Find ("Canvas/Background/ReloadScene").GetComponent<Text> ();
		handBrakeText = transform.Find ("Canvas/Background/HandBrake").GetComponent<Text> ();
		switchCamerasText = transform.Find ("Canvas/Background/SwitchCameras").GetComponent<Text> ();
		pauseText = transform.Find ("Canvas/Background/Pause").GetComponent<Text> ();
		//
		if (!controls) {
			UIVisualizer = false;
			controllsIsNull = true;
			EnableUI (false);
			return;
		}
		playerIsNull = false;
		player = controls.player;
		if (!player) {
			playerIsNull = true;
		}
		//
		enterAndExitText.text = "Enter/Exit Vehicle: " + controls.controls.enterEndExit.ToString ();
		startVehicleText.text = "Start the vehicle: " + controls.controls.startTheVehicle.ToString ();
		reloadText.text = "Reload Scene: " + controls.controls.reloadScene.ToString ();
		handBrakeText.text = "Hand Brake: " + controls.controls.handBrakeInput.ToString ();
		switchCamerasText.text = "Switch Cameras: " + controls.controls.switchingCameras.ToString ();
		pauseText.text = "Pause: " + controls.controls.pause.ToString ();
	}

	void Start(){
		DirectionalLight.GetComponent<Light> ().intensity = 1;
		RenderSettings.reflectionIntensity = 1;
		RenderSettings.ambientSkyColor = new Color(1,1,1);
		DirectionalLight.SetActive (true);
		RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Flat;
	}

	void Update(){
		if (!controllsIsNull && !playerIsNull) {
			if (player.gameObject.activeInHierarchy) {
				EnableUI (false);
			} else {
				EnableUI (UIVisualizer);
			}
		}
	}

	void EnableUI(bool enable){
		if (backGround.gameObject.activeSelf != enable) {
			backGround.gameObject.SetActive(enable);
			controlsText.gameObject.SetActive (enable);
			enterAndExitText.gameObject.SetActive (enable);
			startVehicleText.gameObject.SetActive (enable);
			reloadText.gameObject.SetActive (enable);
			handBrakeText.gameObject.SetActive (enable);
			switchCamerasText.gameObject.SetActive (enable);
			pauseText.gameObject.SetActive (enable);
		}
	}
}
