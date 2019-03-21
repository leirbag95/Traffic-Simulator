using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDataCanvas : MonoBehaviour {



    //MARK: Unity Button
    public void DisableCamera() {
        var car = this.GetComponent<Vehicule>();
        car.SubCamera.SetActive(false);
        car.SubCanvas.SetActive(false);
    }

    public void RemoveVehicle()
    {
        Destroy(this.gameObject);
    } 
}
