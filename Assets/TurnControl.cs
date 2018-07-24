using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnControl : MonoBehaviour {

    public PlayerPiece startingPlayer;

	// Use this for initialization
	void Start () {
        startingPlayer.SubscribeMovement();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
