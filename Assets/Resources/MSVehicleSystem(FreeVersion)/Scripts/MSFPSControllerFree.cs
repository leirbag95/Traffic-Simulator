using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class MSFPSControllerFree : MonoBehaviour {

	GameObject cameraFPS;
	Vector3 moveDirection = Vector3.zero;
	CharacterController controller;
	MSSceneControllerFree sceneControllerMS;
	JoystickFree joystickMoveFPS;
	JoystickFree joystickRotateFPS;
	float rotationX = 0.0f;
	float rotationY = 0.0f;

	float moveInputMSForward;
	float moveInputMSSide;
	float rotateInputMSx;
	float rotateInputMSy;

	void Start () {
		transform.tag = "Player";
		cameraFPS = GetComponentInChildren (typeof(Camera)).transform.gameObject;
		cameraFPS.transform.localPosition = new Vector3 (0, 1, 0);
		cameraFPS.transform.localRotation = Quaternion.identity;
		cameraFPS.tag = "MainCamera";
		controller = GetComponent<CharacterController> ();
		joystickMoveFPS = transform.Find("Canvas/JoystickMFPS").GetComponent<JoystickFree>();
		joystickRotateFPS = transform.Find("Canvas/JoystickRFPS").GetComponent<JoystickFree>();
		sceneControllerMS = FindObjectOfType(typeof(MSSceneControllerFree)) as MSSceneControllerFree;
	}

	void OnEnable(){
		EnableControls ();
	}

	void EnableControls(){
		if (sceneControllerMS) {
			if (sceneControllerMS.selectControls == MSSceneControllerFree.ControlTypeFree.mobileButton) {
				joystickMoveFPS.gameObject.SetActive (true);
				joystickRotateFPS.gameObject.SetActive (true);
			} else {
				joystickMoveFPS.gameObject.SetActive (false);
				joystickRotateFPS.gameObject.SetActive (false);
			}
		}
	}

	void Update () {
		#region getInputs
		if (sceneControllerMS.selectControls == MSSceneControllerFree.ControlTypeFree.mobileButton) {
			if(!joystickMoveFPS.isActiveAndEnabled || !joystickRotateFPS.isActiveAndEnabled){
				EnableControls();
			}
			if(joystickMoveFPS){
				moveInputMSForward = joystickMoveFPS.joystickVertical;
				moveInputMSSide = joystickMoveFPS.joystickHorizontal;
			}
			if(joystickRotateFPS){
				rotateInputMSx = joystickRotateFPS.joystickHorizontal;
				rotateInputMSy = joystickRotateFPS.joystickVertical;
			}
		}
		else{
			if(joystickMoveFPS.isActiveAndEnabled || joystickRotateFPS.isActiveAndEnabled){
				EnableControls();
			}
			if(joystickMoveFPS){
				moveInputMSForward = Input.GetAxis("Vertical");
				moveInputMSSide = Input.GetAxis("Horizontal");
			}
			if(joystickRotateFPS){
				rotateInputMSx = Input.GetAxis ("Mouse X");
				rotateInputMSy = Input.GetAxis ("Mouse Y");
			}
		}
		#endregion

		Vector3 forwardDirection = new Vector3 (cameraFPS.transform.forward.x, 0, cameraFPS.transform.forward.z);
		Vector3 sideDirection = new Vector3 (cameraFPS.transform.right.x, 0, cameraFPS.transform.right.z);
		forwardDirection.Normalize ();
		sideDirection.Normalize ();
		forwardDirection = forwardDirection * moveInputMSForward;
		sideDirection = sideDirection * moveInputMSSide;
		Vector3 finalDirection = forwardDirection + sideDirection;

		if (finalDirection.sqrMagnitude > 1) {
			finalDirection.Normalize ();
		}

		if (controller.isGrounded) {
			moveDirection = new Vector3 (finalDirection.x, 0, finalDirection.z);
			moveDirection *= 6.0f;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = 8.0f;
			}
		}

		moveDirection.y -= 20.0f * Time.deltaTime;
		controller.Move (moveDirection * Time.deltaTime);
		FPSCamera ();
	}

	void FPSCamera(){
		rotationX += rotateInputMSx * 5.0f;
		rotationY += rotateInputMSy * 5.0f;
		rotationX = ClampAngleFPS (rotationX, -360, 360);
		rotationY = ClampAngleFPS (rotationY, -80, 80);
		Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, -Vector3.right);
		Quaternion finalRotation = Quaternion.identity * xQuaternion * yQuaternion;
		cameraFPS.transform.localRotation = Quaternion.Lerp (cameraFPS.transform.localRotation, finalRotation, Time.deltaTime * 10.0f);
	}

	float ClampAngleFPS(float angle, float min, float max){
		if (angle < -360) {
			angle += 360;
		}
		if (angle > 360) {
			angle -= 360;
		}
		return Mathf.Clamp (angle, min, max);
	}
}