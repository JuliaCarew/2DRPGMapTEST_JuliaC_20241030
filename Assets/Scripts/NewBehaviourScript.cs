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
    void DrawToTileMap()
    {
        for (int x = 0; x < 20; x++)
        {
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
    void CountNeighbors(int x, int y)
    {
        for (int a = -1; a < 2; a++)
        {// make array in a grid ranging from -1 to 1
            for (int b = -1; b < 2; b++)
            {
                var tile = new Vector3Int(a, b); 
                /*
                // check coordinates = -1,-1
                if(tile == -1,-1)
                pos1(-1, -1);
                pos2(-1, 0);
                pos3(-1, 1);
                pos4(0, -1);
                pos5(0, 0);
                pos6(0, 1);
                pos7(1, -1);
                pos8(1, 0);
                pos9(1, 1);
                */

            }
        }
    }
    // create variables for each direction?

    // set tile rules (if surrounded by certain number)
    // if surrounding tiles < 2 it becomes null
    // if surrounding tiles == 2 || == 3 it lives to next gen.
    // if surrounding tiles > 3 it becomes null
    // if tile was null && has surrounding tiles == 3 it lives

    // make new array for 2nd generation, this array is 1st gen, 2nd gen relies on positions of 1st gen.
    // each successive array is dependent on the last

    // resource Rosetta code
}
