using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnControl : MonoBehaviour {

    public PlayerPiece startingPlayer;

    public List<PlayerPiece> players = new List<PlayerPiece>();
    public int activePlayer = 0;
    public PlayerPiece ActivePlayer{get{ return players[activePlayer]; }}
    
    private void DisableActivePlayerMovement()
    {
        ActivePlayer.UnscubscribeControl();
    }

    private void PushActivePlayer()
    {
        activePlayer++;
        if (activePlayer > 3)
            activePlayer = 0;
    }

    private void EnableActivePlayerMovement()
    {
        ActivePlayer.SubscribeControl();
    }

    public void NextTurn()
    {
        DisableActivePlayerMovement();
        PushActivePlayer();
        EnableActivePlayerMovement();
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
