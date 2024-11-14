using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEditor.PlayerSettings;


public class NewBehaviourScript : MonoBehaviour
{
    public Tilemap myTilemap;
    public Camera myCamera;
    public TileBase setTileBase;
    public TileBase RandomGameofLife;
    public int[,] multidimenionalMap = new int[25, 25];

    // create tilemap variable for next gen.
    void Start()
    {
        myCamera = Camera.main;
        myTilemap.SetTile(new Vector3Int(-6, -4, 0), null);
       // setting initial bounds of array
        for(int x = 0; x < 20; x++)
        {
            for (int y = 0; y < 20; y++)
            {
                multidimenionalMap[x,y] = Random.Range(0, 2);                
            }
        }
        DrawToTileMap();
        //CountNeighbors();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ApplyRules();
            DrawToTileMap();
        }
    }
    void DrawToTileMap()
    { // count X axis to 20
        for (int x = 0; x < 20; x++)
        { // count Y axis to 20
            for (int y = 0; y < 20; y++)
            {
                if (   multidimenionalMap[x, y] == 0 
                    || multidimenionalMap[x, y] > 20 
                    || multidimenionalMap[x, y] < 0)
                {
                    myTilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
                else if (multidimenionalMap[x, y] == 1)
                {
                    myTilemap.SetTile(new Vector3Int(x, y, 0), RandomGameofLife);
                }
            }
        }
    }
    public bool IsCellAliveCheck(int x, int y)
    {
        if(x >= 0 && y >= 0 && 
            x < multidimenionalMap.GetLength(0) && 
            y < multidimenionalMap.GetLength(1))
        {
            return true;
        }
        return false;
    }
    int CountNeighbors(int x, int y)
    {
        int count = 0;
        // make array in a grid ranging from -1 to 1 ( starts from bottom left)
        for (int check_x = -1; check_x < 2; check_x++)
        {
            for (int check_y = -1; check_y < 2; check_y++)
            { // so the loop doesnt count the current cell/ itself
                if (check_y == 0 && check_x == 0)
                {
                    continue;
                }
                bool resultIsAliveCheck = IsCellAliveCheck(x + check_x, y + check_y);
                if (resultIsAliveCheck == true)
                {
                    count++;
                }                
            }
        }
        return count;
    }
    void ApplyRules()
    {
        int[,] multidimenionalMapCHANGES = new int[25, 25];

        for (int mapChanges_x = 0; mapChanges_x < 20; mapChanges_x++)
        { // count Y axis to 20
            for (int mapChanges_y = 0; mapChanges_y < 20; mapChanges_y++)
            {
                multidimenionalMapCHANGES[mapChanges_x, mapChanges_y] = multidimenionalMap[x, y];
                int countWas = CountNeighbors(x, y);
                if (IsCellAliveCheck(x, y))
                {
                    if (countWas < 2 || countWas > 3)
                    {
                        multidimenionalMapCHANGES[mapChanges_x, mapChanges_y] = 0;
                    }
                    else if (countWas == 2 || countWas == 3)
                    {
                        multidimenionalMapCHANGES[mapChanges_y, mapChanges_x] = 1;
                    }
                }
            }
            multidimenionalMap = multidimenionalMapCHANGES;
        }
    }
    void DrawMap()
    {
        // set tile rules (if surrounded by certain number)
        // if CountNeighbors < 2 it becomes null
        // if CountNeighbors == 2 || == 3 it lives to next gen.
        // if CountNeighbors > 3 it becomes null
        // if tile was null && CountNeighbors == 3 it lives
    }

    // make new array for 2nd generation, this array is 1st gen, 2nd gen relies on positions of 1st gen.
    // each successive array is dependent on the last
}
