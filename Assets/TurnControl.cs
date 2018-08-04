using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TurnControl : MonoBehaviour {

    public PlayerPiece startingPlayer;

    public List<PlayerPiece> players = new List<PlayerPiece>();
    public int activePlayer = 0;
    public PlayerPiece ActivePlayer { get { return players[activePlayer]; } }

    public UnityEvent OnPlayerSwitch;

    private void DisableActivePlayerControl()
    {
        ActivePlayer.UnscubscribeControl();
    }

    private void PushActivePlayer()
    {
        activePlayer++;
        if (activePlayer > 3)
            activePlayer = 0;

        OnPlayerSwitch.Invoke();
    }

    private void EnableActivePlayerMovement()
    {
        ActivePlayer.SubscribeControl();
    }

    public void NextTurn()
    {
        DisableActivePlayerControl();
        PushActivePlayer();
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
