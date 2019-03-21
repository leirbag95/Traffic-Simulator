using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectCarFromGarage : MonoBehaviour {


    // MARK: GameObject
    public GameObject car;
    public GameObject truck;
    public GameObject moto;
    public GameObject taxi;
    public GameObject bus;

    // Use this for initialization
    void Start () {
        truck.SetActive(false);
        moto.SetActive(false);
        //taxi.SetActive(false);
        bus.SetActive(false);
        car.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SelectCar()
    {
        truck.SetActive(false);
        moto.SetActive(false);
        //taxi.SetActive(false);
        bus.SetActive(false);
        car.SetActive(true);
    }

    public void SelectTruck()
    {
        truck.SetActive(true);
        moto.SetActive(false);
        //taxi.SetActive(false);
        bus.SetActive(false);
        car.SetActive(false);
    }

    public void SelectMoto()
    {
        truck.SetActive(false);
        moto.SetActive(true);
        //taxi.SetActive(false);
        bus.SetActive(false);
        car.SetActive(false);
    }

    public void SelectBus()
    {
        truck.SetActive(false);
        moto.SetActive(false);
        //taxi.SetActive(false);
        bus.SetActive(true);
        car.SetActive(false);
    }


}
