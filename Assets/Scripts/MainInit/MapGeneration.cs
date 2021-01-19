using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public GameObject hextile;
    public int numPlayers;

    void Start()
    {
        for (int i = 0; i <= numPlayers; i++)
        {
            string holderName = "Player " + i.ToString() + " Map";
            if (transform.Find(holderName))
            {
                DestroyImmediate(transform.Find(holderName).gameObject);
            }
            Transform mapHolder = new GameObject(holderName).transform;
            mapHolder.parent = transform;
            Planet planet = mapHolder.gameObject.AddComponent<Planet>();

            List<Hextile> hextileList = new List<Hextile>();

            int numRows = 15;
            for (int k = 1; k <= numRows; k++)
            {
                int rowLength = DetermineRowLength(k, numRows);
                float rowCenter = (rowLength / 2);

                string rowName = "Row Holder " + k.ToString();
                Transform rowHolder = new GameObject(rowName).transform;
                rowHolder.parent = mapHolder;

                for (int j = 0; j < rowLength; j++)
                {
                    GameObject newTile = Instantiate(hextile, new Vector3(k, 0, j - rowCenter), Quaternion.identity);
                    newTile.transform.parent = rowHolder;

                    var euler = newTile.transform.eulerAngles; //Rotate the tile randomly so the cities look a little random.
                    euler.y = Random.Range(0, 360);
                    newTile.transform.eulerAngles = euler;

                    Hextile currentTileScript = newTile.GetComponent<Hextile>();
                    currentTileScript.tileLocation = new Vector2(k, j);
                    hextileList.Add(currentTileScript);
                }

                if (k % 2 == 0) // Here we're checking if this row is an odd number, and if it is, shifting its z position by -0.5
                {
                }
                else
                    rowHolder.position += new Vector3(0, 0, -0.5f);
            }

            //Offset the entire player's grid based on the number of players
            int offset = 15;
            mapHolder.transform.position += new Vector3(0, 0, offset * i);

            planet.hextileList = hextileList;
        }
    }

    public int DetermineRowLength (int currentRow, int numRows)
    {
        int rowLength = 0;
        if (currentRow == 1 || currentRow == numRows) 
            rowLength = 3;
        else if (currentRow == 2 || currentRow == numRows - 1)
            rowLength = 6;
        else if (currentRow == 3 || currentRow == numRows - 2)
            rowLength = 9;
        else if (currentRow == 4 || currentRow == numRows - 3)
            rowLength = 10;
        else if (currentRow == 5 || currentRow == numRows - 4)
            rowLength = 11;
        else if (currentRow == 6 || currentRow == numRows - 5)
            rowLength = 12;
        else if (currentRow == 7 || currentRow == numRows - 6)
            rowLength = 13;
        else if (currentRow == 8)
            rowLength = 12;

        if (rowLength == 0)
        {
            Debug.Log("Couldnt determine accurate rowLength!");
        }
        return rowLength;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
