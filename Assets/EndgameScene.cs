using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class EndgameScene : MonoBehaviour {

    public UnityEvent OnTreasureCollection;
    public Canvas canvas;
    public bool CanvasRevealed { get { return canvas.enabled; } }
    public float timeUntilGameResets = 5.0f;
    public bool TimerRunning = false;

    private void SetTimerRunningToTrue()
    {
        TimerRunning = true;
    }

    private void StartEndgameSceneTimer()
    {
        SetTimerRunningToTrue();
    }

    private void EnableCanvas()
    {
        canvas.enabled = true;
    }

    private void RevealEndgameScene()
    {
        EnableCanvas();
    }

    private void DisableTurns()
    {
        
    }

    private void EndGame()
    {
        RevealEndgameScene();
        StartEndgameSceneTimer();
    }

    private void ClearOnTreasureCollection()
    {
        OnTreasureCollection = new UnityEvent();
    }

    private void CheckGameComplete()
    {
        int collectedTreasure = TreasurePiece.CollectedTreasure;
        int totalTreasurePieces = TreasurePiece.TotalTreasurePieces;
        if (collectedTreasure == totalTreasurePieces)
        {
            EndGame();
            ClearOnTreasureCollection();
        }
    }

	// Use this for initialization
	void Start () {
        OnTreasureCollection.AddListener(CheckGameComplete);		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
