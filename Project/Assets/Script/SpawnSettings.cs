using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSettings : MonoBehaviour {

    //MARK: public
    public GameObject[,] grid;
    public int J, I;
    public GameObject[] cars;

    //MARK: private


    private void Start()
    {
        //On instantie le véhicule avec son chemin
       StartCoroutine(InstantiateFromNSecond(5.0f));
    }

    //MARK private func

    /*
     * Stock tous les noeud à suivre par un véhicule
     * dans une liste de noeuds
    */
    private void getNodesFromMap(Vehicule vehicule, int coordI, int coordJ)
    {


        //On enregistrer les noeuds
        Node[] nodes = grid[coordI, coordJ].GetComponentsInChildren<Node>();
       
        foreach (Node node in nodes)
        {
            vehicule.PathNode.Add(node);
        }

        //On Attribue alors au véhicule une direction
        // Continuer ou tourner
        int rand = Random.Range(0, 10);

        //On parcours ici le tableaux d jusqu'a qu'on rencontre un noeud mort
        // Noeud mort: cul de sac || sans issue
        if (grid[coordI, coordJ].tag == "TB" || grid[coordI, coordJ].tag == "TBS") 
        {
            if (grid[coordI + 1, coordJ] != null)
            {
                getNodesFromMap(vehicule, coordI + 1, coordJ);
            }
        } else if (grid[coordI, coordJ].tag == "BT" || grid[coordI, coordJ].tag == "BTS")
        {
            if (grid[coordI - 1, coordJ] != null)
            {
                getNodesFromMap(vehicule, coordI - 1, coordJ);
            }
        } else if (grid[coordI, coordJ].tag == "LR" || grid[coordI, coordJ].tag == "LRS")
        {
            if (grid[coordI, coordJ + 1] != null)
            {
                getNodesFromMap(vehicule,coordI, coordJ + 1);
            }
        } else if (grid[coordI, coordJ].tag == "RL" || grid[coordI, coordJ].tag == "RLS")
        {
            if (grid[coordI, coordJ - 1] != null)
            {
                getNodesFromMap(vehicule,coordI, coordJ - 1);
            }
        }
        else if (grid[coordI, coordJ].tag == "CNO")
        {
            //Si rand == 0 on continue
            //sinon on tourne
            if (grid[coordI + 2, coordJ] != null && grid[coordI, coordJ - 1] != null)
            {
                if (rand % 2 == 0)
                {
                    getNodesFromMap(vehicule,coordI, coordJ - 1);
                }
                else
                {
                    getNodesFromMap(vehicule, coordI + 2, coordJ);
                }
            }
        }
        else if (grid[coordI, coordJ].tag == "CNE")
        {

            //Si rand == 0 on continue
            //sinon on tourne
            if (grid[coordI - 1, coordJ] != null && grid[coordI, coordJ - 2] != null)
            {
                if (rand % 2 == 0)
                {
                    getNodesFromMap(vehicule, coordI - 1, coordJ);
                }
                else
                {
                    getNodesFromMap(vehicule, coordI, coordJ - 2);
                }
            }
        }
        else if (grid[coordI, coordJ].tag == "CSO")
        {
            //Si rand == 0 on continue
            //sinon on tourne
            if (grid[coordI + 1, coordJ] != null && grid[coordI, coordJ + 2] != null)
            {
                if (rand % 2 == 0)
                {
                    getNodesFromMap(vehicule,coordI + 1, coordJ);
                }
                else
                {
                    getNodesFromMap(vehicule,coordI, coordJ + 2);
                }
            }
        }
        else if (grid[coordI, coordJ].tag == "CSE")
        { 
            //Si rand == 0 on continue
            //sinon on tourne
            if (grid[coordI - 2, coordJ] != null && grid[coordI, coordJ +1] != null)
                if (rand % 2== 0)
                {
                    getNodesFromMap(vehicule,coordI - 2, coordJ);
                }
                else
                {
                    getNodesFromMap(vehicule,coordI, coordJ + 1);
                }
        }
    }

    /*
     * Genère une voiture toutes les N secondes
    */
    private IEnumerator InstantiateFromNSecond(float n)
    {
        while (true)
        {
            GameObject Scripts = GameObject.Find("Scripts");
            MapGenerator mapGenerator = Scripts.GetComponent<MapGenerator>();
            grid = mapGenerator.grid;

            RoadTemplates road = GetComponentInParent<RoadTemplates>();
            J = Mathf.Abs((int)road.transform.position.x) / mapGenerator.GetRoadSize;
            I = Mathf.Abs((int)road.transform.position.z) / mapGenerator.GetRoadSize;

            Vehicule tmpCar = cars[Random.Range(0,cars.Length)].GetComponent<Vehicule>();
            tmpCar.PathNode = new List<Node>();
            getNodesFromMap(tmpCar, I, J);
            Instantiate(tmpCar, gameObject.transform.position, Quaternion.identity);

            yield return new WaitForSeconds(n);
        }
    }
}
