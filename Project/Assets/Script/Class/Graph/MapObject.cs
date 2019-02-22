using UnityEngine;
using System.Collections;


public class MapObject
{
    public string name;
    public int colNumber;
    public int rowNumber;
    public string[][] grid;
    public string[,] gridFromString;
    public GameObject[,] gridFromGameObject = {};
}
