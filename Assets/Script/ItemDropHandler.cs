using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    // MARK: public GameObject
    public GameObject character;

    // MARK: variables
    Vector3 position;

	// Use this for initialization
	void Start () {
        position = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
	}

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector3 position = GameObject.FindWithTag("SpawnPoint").gameObject.transform.position;
        Instantiate(character, position, Quaternion.identity);
        transform.localPosition = position;
    }

    // MARK: Button Add fence

    public void AddFence() {

        var fences = GameObject.FindGameObjectsWithTag("ShowFence");
        if (GameObject.FindGameObjectWithTag("ShowFence").GetComponent<MeshRenderer>().enabled) 
        {
            for (int i = 0; i < fences.Length; i++)
            {
                GameObject.FindGameObjectsWithTag("ShowFence")[i].GetComponent<MeshRenderer>().enabled = false;
            }
        } else {
            for (int i = 0; i < fences.Length; i++)
            {
                GameObject.FindGameObjectsWithTag("ShowFence")[i].GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }


}
