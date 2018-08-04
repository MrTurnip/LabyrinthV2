using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhaseControl : MonoBehaviour
{

    public enum Phase { PlaceTile, MovePlayer }
    public Phase phase = Phase.PlaceTile;
    public bool phaseInitialized = false;

    public void StartTilePlacement()
    {
        TileRotator tileRotator = GameObject.FindObjectOfType<TileRotator>();
        tileRotator.SubscribeClickToRotate();

        MovementArrow.SubscribeAllToShiftTiles();
    }

    public void ClearPhaseInitializer()
    {
        InitializePhase = new UnityEvent();
    }

    public UnityEvent InitializePhase;

    public void Start()
    {
        InitializePhase.AddListener(StartTilePlacement);
        InitializePhase.AddListener(ClearPhaseInitializer);

        InitializePhase.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
