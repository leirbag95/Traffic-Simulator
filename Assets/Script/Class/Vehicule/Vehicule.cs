using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class Vehicule : MonoBehaviour {


    //MARK: private custom variable(s)
    Vector3 currentPositionHolder;
    private float Timer;
    private int currentNode;
    private float speed = 1f;
    private float speedRotate = 2f;
    //Les vitesse maximum et minimum du véhicule
    private const float MINSPEED = -0.0f;
    //Permet de savoir si le véhicule doit accélerer ou décélerer
    private bool canSpeedUp = true;
    //Permet de savoir si le véhicule doit accélerer ou décélerer même quand la
    // lumiere est verte
    private bool canSpeedUpEvenWithGreenLight = true;
    //Identifiant du véhicule
    private string id = "";

    //MARK: UnityEngine variable
    public float acceleration = 0.02f;
    public float MAXSPEED = 3f;
    public float deceleration = -2f;
    public GameObject SubCamera;
    public GameObject SubCanvas;
    public UnityEngine.UI.Text idText;
    public UnityEngine.UI.Text speedText;
    //Permet d'afficher les informations sur le traffic
    UnityEngine.UI.Text textLog;


    //MARK: public custom variables
    public List<Node> PathNode = new List<Node>();

    public float Speed {
        get 
        {
            return speed;
        } 
        set 
        {
            speed = value;
        }
    }

    public float Acceleration
    {
        get
        {
            return acceleration;
        }
        set
        {
            acceleration = value;
        }
    }

    public string ID
    {
        get
        {
            return id;
        }
        set
        {
            id = value;
        }
    }

    //MARK: Unity func

    private void Start()
    {
        currentPositionHolder = PathNode[0].transform.position;
        id  = DateTime.Now.Hour.ToString() + "_" + DateTime.Now.Minute.ToString() + "_" + DateTime.Now.Second.ToString();

        textLog = GameObject.FindWithTag("TextLog").GetComponent<UnityEngine.UI.Text>();
        textLog.text += "Vehicle " + id + " was created \n";

        speedText.text = "Speed: " + speed.ToString();
        idText.text = "id: " + id;

    }

    private void Update()
    {

        CarMovement();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "carBreak" || other.tag == "Fence") 
        {
            canSpeedUp = false;
            canSpeedUpEvenWithGreenLight = false;
        } else if (other.tag == "Vehicle"){
            textLog.text += "The vehicle "+id+" interacts with another vehicle.";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "carBreak" || other.tag == "Fence")
        {
            canSpeedUp = true;
            canSpeedUpEvenWithGreenLight = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "RedLight")
        {
            Debug.Log("Enter in colision " + ID);
            canSpeedUp = false;
        }
        else if (other.tag == "GreenLight" && canSpeedUpEvenWithGreenLight)
        {
            canSpeedUp = true;
        }
    }


    /*
     * Lorsque l'on clique sur une voiture, on passe en mode passager
    */
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) {
            SubCamera.gameObject.SetActive(true);
            SubCanvas.SetActive(true);
        }
    }


    //MARK: public func


    public void CarMovement() 
    {
        /*
         * Permet de gérer le comportement de la voitures
        */

        AccelerationManagement();

        //Dirige la voiture vers l'avant

        Timer += Time.deltaTime * speed;
        if (transform.position != currentPositionHolder)
        {
            //actualise la position
            this.transform.position = Vector3.MoveTowards(this.transform.position, currentPositionHolder, Time.deltaTime * speed);
            //actualise la rotation


            this.transform.LookAt(currentPositionHolder);
        }
        else
        {
            currentNode++;
            CheckNode();
        }
    }

    public void AccelerationManagement() 
    {
        /*
         * Permet de gérer l'accélération de la voiture
        */
        //Si aucun obstacle n'est sur la route du véhicule
        if (canSpeedUp) 
        {
            if (speed < MAXSPEED)
            {
                speed += acceleration;
            }
        } else 
        {
            if (speed > 0 && (speed - deceleration) > 0)
            {
                speed -= deceleration;
            } else {
                speed = 0;
            }
        }
        speedText.text = "Speed: " + (speed * 17).ToString();
    }

    /*
     * on verifie l'etat du noeud actuelle
    */
    public void CheckNode()
    {
        if (currentNode >= PathNode.Count)
        {
            //Si le véhicule atteint la fin du chemin attribuait il disparait
            Destroy(gameObject);
            textLog.text += "Vehicle " + ID + " was destroyed... \n";
        }
        else
        {
            Timer = 0;
            currentPositionHolder = PathNode[currentNode].transform.position;
        }
    }
}