using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasurePiece : MonoBehaviour
{
    public static int CollectedTreasure = 0;
    public static int TotalTreasurePieces = 9;

    public bool isAcquired;

    private void DisableSpriteRenderer()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void DisableCollider2D()
    {
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false;
    }

    private void AddToAcquirer(PlayerPiece acquirer)
    {
        acquirer.treasure.Add(this);
    }

    private void SetToAcquired()
    {
        isAcquired = true;
    }

    private void IncreasecollectedTreasureCount() { CollectedTreasure++; }


    public void Acquire(PlayerPiece acquirer)
    {
        DisableSpriteRenderer();

        DisableCollider2D();

        AddToAcquirer(acquirer);

        SetToAcquired();

        IncreasecollectedTreasureCount();

        CheckGameOver();
    }

    private void CheckGameOver()
    {
        EndgameScene endgameScene = GameObject.FindObjectOfType<EndgameScene>();
        endgameScene.OnTreasureCollection.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject gameObject = collision.gameObject;
        string objectTag = gameObject.tag;

        if (objectTag == "Player")
        {
            PlayerPiece playerPiece = gameObject.GetComponent<PlayerPiece>();
            Acquire(playerPiece);
        }
    }
}