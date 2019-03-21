using UnityEngine;
using SimpleJSON;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class LoadScene : MonoBehaviour
{

    public GameObject errorPanel;
    // MARK: public function(s)

    public void LoadMainMenu()
    {
        Application.LoadLevel(0);
    }

    public void LoadRandomMapScene()
    {
        string UPLOAD_PATH = "UPLOAD_PATH";
        var path = Path.Combine(Application.streamingAssetsPath, "grid1.json");
        PlayerPrefs.SetString(UPLOAD_PATH, path);
        Application.LoadLevel(1);
    }

    public void LoadGarage()
    {
        Application.LoadLevel(2);
    }

    public void LoadMapChoice()
    {
        Application.LoadLevel(3);
    }

    public void LoadLargeMap()
    {
        string UPLOAD_PATH = "UPLOAD_PATH";
        var path = Path.Combine(Application.streamingAssetsPath, "grid1.json");
        PlayerPrefs.SetString(UPLOAD_PATH, path);
        Application.LoadLevel(1);
    }


    /*
     * Permet charger une map personnalisée
    */
    public void ShowExplorer()
    {
#if UNITY_EDITOR 
        bool isWinEditor = Application.platform == RuntimePlatform.WindowsEditor;
        string[] filter = { "json", "JSON" };

        string path = EditorUtility.OpenFilePanelWithFilters("", "", filter);
        Debug.Log(path);
        if (path.Length > 0)
        {
            if (CheckFormatForUpload(path))
            {
                string UPLOAD_PATH = "UPLOAD_PATH";
                PlayerPrefs.SetString(UPLOAD_PATH, path);
                Application.LoadLevel(1);
            }
            else
            {
                errorPanel.SetActive(true);
            }
        }
#endif
    }

    public void CloseErrorPanel() 
    {
        errorPanel.SetActive(false);
    }



    // MARK : private function

    // On verifie si le fichier JSON respect le bon format
    private bool CheckFormatForUpload(string path)
    {
        string filePath = path;

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            var N = JSON.Parse(dataAsJson);
            int ROWNUMBER = N["rows"];
            int COLNUMBER = N["cols"];
            if (ROWNUMBER < 4 || COLNUMBER < 4)
            {
                return false;
            }
            GameObject[,] gridTmp = new GameObject[ROWNUMBER, COLNUMBER];
            for (int i = 0; i < COLNUMBER; i++)
            {
                var road = N["grid"][0][i];
                if (road != "")
                {
                    return false;
                }
            }

            for (int i = 0; i < COLNUMBER; i++)
            {
                var road = N["grid"][ROWNUMBER - 1][i];
                if (road != "")
                {
                    return false;
                }
            }
            return true;
        }
        return false;
    }

}
