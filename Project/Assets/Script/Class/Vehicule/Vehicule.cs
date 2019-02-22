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
    private float acceleration = 0.01f;
    private float deceleration = -0.05f;
    //Les vitesse maximum et minimum du véhicule
    private const float MAXSPEED  = 3f;
    private const float MINSPEED = -0.0f;
    //Permet de savoir si le véhicule doit accélerer ou décélerer
    private bool canSpeedUp = true;
    //Identifiant du véhicule
    private string id = "";

    //MARK: UnityEngine variable
    public GameObject SubCamera;
    public GameObject SubCanvas;
    public UnityEngine.UI.Text idText;
    public UnityEngine.UI.Text speedText;


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


        speedText.text = "Speed: " + speed.ToString();
        idText.text = "id: " + id;

    }

    private void Update()
    {

        CarMovement();

    }



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "RedLight" || other.tag == "Vehicle")
        {
            canSpeedUp = false;
        }
        else if (other.tag == "GreenLight")
        {
            canSpeedUp = true;
        }
    }


    /*
     * Lorsque l'on clique sur une voiture
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
                deceleration -= (0.01f * acceleration);
            }
        } else 
        {
            if (speed > MINSPEED) 
            {
                speed += deceleration;
            } else 
            {
                deceleration = -0.05f;
                speed = 0;
            }
        }
        speedText.text = "Speed: " + speed.ToString();
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
        }
        else
        {
            Timer = 0;
            currentPositionHolder = PathNode[currentNode].transform.position;
        }
    }
}