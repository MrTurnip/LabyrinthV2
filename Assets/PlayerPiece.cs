using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum PlayerColor {Yellow, White, Pink, Blue }

public class PlayerPiece : MonoBehaviour {

    public UnityEvent OnUpdate;
    public Rigidbody2D rigidbody2D;
    public List<TreasurePiece> treasure = new List<TreasurePiece>();

    private Vector2 direction = new Vector2();
    public float speed;

    private void CheckKeyboardPress()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.x *= speed;

        direction.y = Input.GetAxis("Vertical");
        direction.y *= speed;
    }

    private void UpdateRigidbody()
    {
        rigidbody2D.velocity = direction;
    }

    private void Movement()
    {
        CheckKeyboardPress();
        UpdateRigidbody();
    }

    public void SubscribeMovement()
    {
        OnUpdate.AddListener(Movement);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OnUpdate.Invoke();
	}
}
