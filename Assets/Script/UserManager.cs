using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserManager : MonoBehaviour {


    //MARK: variable
    public float speed = 50.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0,Input.GetAxis("Vertical"));
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
}
