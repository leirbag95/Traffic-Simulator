using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFence : MonoBehaviour {

    public GameObject Fence;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            Fence.SetActive(true);
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
