
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using SimpleJSON;




public class MapGenerator : MonoBehaviour {

    //MARK: public var
    public int COLNUMBER = 7;
    public int ROWNUMBER = 7;
    public const int ROADSIZE = 4;//taille d'un cube : Route
    public GameObject TB;
    public GameObject LRS;//Left Right Spawner
    public GameObject BT;
    public GameObject RL;
    public GameObject RLS;//Right Left Spawner
    public GameObject LR;
    public GameObject CNO;
    public GameObject CNE;
    public GameObject CSE;
    public GameObject CSO;
    public GameObject WP;//Welcome Panel
    public GameObject GR;//Grass

    public TextMesh WelcomeMessageText;//Welcome message text

    public GameObject[] ENVS;//environment

    public GameObject[,] grid;

    //MARK: private
    const string UPLOAD_PATH = "UPLOAD_PATH";
    private string JSONFileName;

    private void Start()
    {

        JSONFileName = PlayerPrefs.GetString(UPLOAD_PATH);

        grid = GenerateNewMapFromJSON();


        DisplayGrid(grid);
    }

    //MARK: public function
    public int GetColNumber {
        get {
            return COLNUMBER;
        }
    }

    public int GetRowNumber
    {
        get
        {
            return ROWNUMBER;
        }
    }

    public int GetRoadSize
    {
        get
        {
            return ROADSIZE;
        }
    }

    //MARK private function
    /*
     * On affiche la grid sur l'interface
    */
    private void DisplayGrid(GameObject[,] grid)
    {
        for (int i = 0; i < ROWNUMBER; i++)
        {
            for (int j = 0; j < COLNUMBER; j++)
            {
                GameObject tmpRoad = grid[i, j];
                if (grid[i, j] != null)
                {
                    Vector3 posRoad = new Vector3(x: j * ROADSIZE, y: 0, z: -i * ROADSIZE);
                    tmpRoad.transform.position = posRoad;
                    grid[i, j] = Instantiate(tmpRoad);

                } else {
                    //On instantie un block d'environment
                    int rand = UnityEngine.Random.Range(0, ENVS.Length);
                    tmpRoad = ENVS[rand];
                    Vector3 posRoad = new Vector3(x: j * ROADSIZE, y: 0, z: -i * ROADSIZE);
                    tmpRoad.transform.position = posRoad;
                    Instantiate(tmpRoad);
                }
            }
        }
    }

    /*
     * Genere une nouvelle map à partir d'un fichier JSON
     * ⚠︎ ATTENTION ⚠︎   La taille doit être strictement supérieur à 5
     */
    private GameObject[,] GenerateNewMapFromJSON() {
        //DEBUG JSON
        //string filePath = Path.Combine(Application.streamingAssetsPath, JSONFileName);
        string filePath = PlayerPrefs.GetString(UPLOAD_PATH);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            var N = JSON.Parse(dataAsJson);
            var versionString = N["name"];
            WelcomeMessageText.text = "Welcome\nto\n" + versionString;
            ROWNUMBER = N["rows"];
            COLNUMBER = N["cols"];

            GameObject[,] gridTmp = new GameObject[ROWNUMBER,COLNUMBER];
            for (int i = 0; i <ROWNUMBER; i++)
            {
                for (int j = 0; j < COLNUMBER; j++) 
                {
                    var road = N["grid"][i][j];
                    if (road == "TB")
                    {
                        gridTmp[i, j] = TB;
                    } 
                    else if (road == "RLS")
                    {
                        gridTmp[i, j] = RLS;
                    }
                    else if (road == "WP")
                    {
                        gridTmp[i, j] = WP;
                    }
                    else if (road == "BT")
                    {
                        gridTmp[i, j] = BT;
                    }
                    else if (road == "LR")
                    {
                        gridTmp[i, j] = LR;
                    }
                    else if (road == "RL")
                    {
                        gridTmp[i, j] = RL;
                    }
                    else if (road == "LRS")
                    {
                        gridTmp[i, j] = LRS;
                    }
                    else if (road == "CNO")
                    {
                        gridTmp[i, j] = CNO;
                    }
                    else if (road == "CNE")
                    {
                        gridTmp[i, j] = CNE;
                    }
                    else if (road == "CSE")
                    {
                        gridTmp[i, j] = CSE;
                    }
                    else if (road == "CSO")
                    {
                        gridTmp[i, j] = CSO;
                    }

                    else
                    {
                        gridTmp[i, j] = null;
                    }

                }
            }
            return gridTmp;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
        }
        return new GameObject[0,0];
    }


   
}
