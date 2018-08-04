using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnDisplay : MonoBehaviour {

    public SpriteRenderer spriteRenderer;
    public TurnControl turnControl;

    public void UpdatePlayerSpriteDisplay()
    {
        PlayerPiece activePlayer = turnControl.ActivePlayer;
        SpriteRenderer playerSprite = activePlayer.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = playerSprite.sprite;
    }

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        turnControl.OnPlayerSwitch.AddListener(UpdatePlayerSpriteDisplay);

        UpdatePlayerSpriteDisplay();
    }
}
