using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Gameboard : MonoBehaviour {

    private List<TilePiece> tiles;

    private void InitializeTiles()
    {
        tiles = new List<TilePiece>(Gameboard.FindObjectsOfType<TilePiece>());
        for (int i = 0; i < tiles.Count; i++)
            if (tiles[i].isBasePiece)
                tiles.Remove(tiles[i]);
    }

    /*
     *  Random rnd=new Random();
     *  string[] MyRandomArray = MyArray.OrderBy(x => rnd.Next()).ToArray();   
     */

    public void ShuffleBoard()
    {
        Random randomVal = new Random();
        List<TilePiece> listCopy = tiles;
        List<TilePiece> randomizedPieces = new List<TilePiece>();
        for (; listCopy.Count!=0;)
        {
            int ranRange = Random.Range(0, listCopy.Count - 1);
            TilePiece foundTile = listCopy[ranRange];
            randomizedPieces.Add(foundTile);
            listCopy.Remove(foundTile);
        }
        
        tiles = randomizedPieces;

        const int TABLEWIDTH = 10;
        const int TABLEHEIGHT = 10;
        const int HALFWIDTH = TABLEWIDTH / 2;
        const int HALFHEIGHT = TABLEHEIGHT / 2;
        for (int y = 0; y < TABLEHEIGHT; y++)
        {
            for (int x = 0; x < TABLEWIDTH; x++)
            {
                TilePiece tilePiece = tiles[(y * TABLEHEIGHT) + x];
                Vector2 newPosition = new Vector2(x-HALFWIDTH+0.5f, y-HALFHEIGHT+0.5f);
                tilePiece.transform.position = newPosition;
            }
        }

        foreach (TilePiece tilePiece in tiles)
        {
            tilePiece.transform.Rotate(new Vector3(0, 0, Random.Range(0, 4) * 90));
        }


    }

	// Use this for initialization
	void Start () {
        InitializeTiles();
        ShuffleBoard();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
