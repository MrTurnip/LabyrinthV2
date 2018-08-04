using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum PlayerColor {Yellow, White, Pink, Blue }

public class PlayerPiece : MonoBehaviour {

    public UnityEvent OnUpdate;
    public new Rigidbody2D rigidbody2D;
    public List<TreasurePiece> treasure = new List<TreasurePiece>();


    private Vector2 direction = new Vector2();
    public float speed;

    public void KillVelocity()
    {
        rigidbody2D.velocity = Vector2.zero;
    }

    public void UnscubscribeControl()
    {
        KillVelocity();
        OnUpdate = new UnityEvent();
    }

    private void CheckKeyboardPress()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.x *= speed;

        direction.y = Input.GetAxis("Vertical");
        direction.y *= speed;

        bool enterIsDown = Input.GetKeyDown(KeyCode.Return);
        if (enterIsDown)
        {
            PhaseControl phaseControl = Gameboard.FindObjectOfType<PhaseControl>();
            phaseControl.StartTileShiftPhase();
        }
    }

    private void UpdateRigidbody()
    {
        rigidbody2D.velocity = direction;
    }

    private void Control()
    {
        CheckKeyboardPress();
        UpdateRigidbody();
    }

    public void SubscribeControl()
    {
        OnUpdate.AddListener(Control);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate.Invoke();
	}
}
