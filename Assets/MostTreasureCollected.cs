using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class MostTreasureCollected : MonoBehaviour
{

    // These scripts need heavy refactoring.

    public EndgameScene endgameScene;
    private PlayerPiece highestScoreSprite;
    List<PlayerPiece> playerPieces;

    public void SetToHighestScore()
    {
        playerPieces = new List<PlayerPiece>(GameObject.FindObjectsOfType<PlayerPiece>());

        List<PlayerPiece> sortedPlayerPieces = new List<PlayerPiece>(playerPieces);
        IEnumerable<PlayerPiece> sorted = sortedPlayerPieces.OrderBy(playerPiece => playerPiece.treasure.Count);

        sortedPlayerPieces = new List<PlayerPiece>(sorted);
        playerPieces = sortedPlayerPieces;

        highestScoreSprite = sortedPlayerPieces[3];

        MostTreasureCollected mostTreasureCollected = GameObject.FindObjectOfType<MostTreasureCollected>();
        GameObject spriteObject = mostTreasureCollected.gameObject;
        Image spriteImage = spriteObject.GetComponent<Image>();

        SpriteRenderer highScoreSprite = highestScoreSprite.GetComponent<SpriteRenderer>();
        spriteImage.sprite = highScoreSprite.sprite;


    }

    // Use this for initialization
    void Start()
    {
        endgameScene = GameObject.FindObjectOfType<EndgameScene>();
        endgameScene.OnGameCompete.AddListener(SetToHighestScore);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
