using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnControl : MonoBehaviour {

    public PlayerPiece startingPlayer;

    public List<PlayerPiece> players = new List<PlayerPiece>();
    public int activePlayer = 1;
    public PlayerPiece ActivePlayer { get { return players[activePlayer]; } }

    public UnityEvent OnPlayerSwitch;

    public void DisableActivePlayerControl()
    {
        ActivePlayer.UnscubscribeControl();
    }

    public void NextPlayer()
    {
        activePlayer++;
        if (activePlayer > 3)
            activePlayer = 0;

        OnPlayerSwitch.Invoke();
    }

    void SetPlayerColliders()
    {
        PlayerPiece[] playerPieces = GameObject.FindObjectsOfType<PlayerPiece>();
        foreach(PlayerPiece playerPiece in playerPieces)
        {
            if (playerPiece != ActivePlayer)
            {
                Collider2D collider = playerPiece.GetComponent<Collider2D>();
                collider.enabled = false;
            }
            else
            {
                Collider2D collider = playerPiece.GetComponent<Collider2D>();
                collider.enabled = true;
            }
        }

    }
    
    public void EnableActivePlayerMovement()
    {
        ActivePlayer.SubscribeControl();
        SetPlayerColliders();
    }

    public void NextTurn()
    {
        DisableActivePlayerControl();
        NextPlayer();
        EnableActivePlayerMovement();
    }

    public void EndTurn()
    {
        DisableActivePlayerControl();

     
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
