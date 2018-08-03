using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndgameScene : MonoBehaviour {

    public UnityEvent OnTreasureCollection;
    public Canvas canvas;
    public bool CanvasRevealed { get { return canvas.enabled; } }
    public float timeUntilGameResets = 5.0f;
    public bool timerRunning = false;
    public bool timerFinished = false;

    public UnityEvent OnUpdate, OnGameCompete;
    
    private void SetTimerRunningToTrue()
    {
        timerRunning = true;
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    private void CountdownAndRestart()
    {
        timeUntilGameResets -= Time.deltaTime;

        if (timeUntilGameResets <= 0)
        {
            timerFinished = true;
        }

        if (timerFinished == true)
        {
            ReloadScene();
        }
    }

    private void SubscribeSceneCountdown()
    {
        OnUpdate.AddListener(CountdownAndRestart);
    }

    private void StartEndgameSceneTimer()
    {
        SetTimerRunningToTrue();
        SubscribeSceneCountdown();
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
        OnGameCompete.Invoke();
    }

    private void ClearTreasureCollectionEvent()
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
            ClearTreasureCollectionEvent();
        }
    }

	// Use this for initialization
	void Start () {
        OnTreasureCollection.AddListener(CheckGameComplete);		
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate.Invoke();
	}
}
