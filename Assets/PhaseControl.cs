using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhaseControl : MonoBehaviour
{

    public enum Phase { PlaceTile, MovePlayer }
    public Phase phase = Phase.PlaceTile;
    public bool phaseInitialized = false;

    public void StartTileShiftPhase()
    {
       // TurnControl turnControl = Gameboard.FindObjectOfType<TurnControl>();
       // turnControl.EndTurn();

        MovementArrow.SubscribeAllToShiftTiles();
      //  turnControl.OnPlayerSwitch.Invoke();
    }

    public void StartMovementPhase()
    {
        MovementArrow.UnsubscribeAllToShiftTiles();

        TurnControl turnControl = Gameboard.FindObjectOfType<TurnControl>();
        turnControl.EnableActivePlayerMovement();
    }

    public void ClearPhaseInitializer()
    {
        InitializePhase = new UnityEvent();
    }

    public UnityEvent InitializePhase;

    public void Start()
    {
        InitializePhase.AddListener(StartTileShiftPhase);
        InitializePhase.AddListener(ClearPhaseInitializer);

        InitializePhase.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
