using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ShiftedPiece : MonoBehaviour {

    public Vector3 pointA, pointB;
    public float rate = 0.1f;
    public float progress = 0;
    public Vector3 direction;
    public enum ShiftProgress {not_shifted, shifting, shifted, isBase }
    public ShiftProgress shift;

    public GameObject getGameObject { get { return gameObject; } }
    public void ShiftOver(Vector2 direction)
    {
        this.transform.Translate(direction);
    }

    public UnityEvent OnUpdate;

    public void Shift()
    {
        if (shift == ShiftProgress.not_shifted)
        {
            pointA = this.transform.position;
            pointB = this.transform.position + direction;
            shift = ShiftProgress.shifting;
        }
        
        this.transform.position = Vector2.Lerp(pointA, pointB, progress);
        progress += rate;

        if (progress >= 1)
        {
            shift = ShiftProgress.shifted;
            this.transform.position = pointB;
            OnUpdate = new UnityEvent();
            progress = 0;
        }
    }

    public void SubscribeShift(Vector3 direction)
    {
        this.shift = ShiftProgress.not_shifted;
        this.direction = direction;
        OnUpdate.AddListener(Shift);
    }

	
	// Update is called once per frame
	void Update () {
        OnUpdate.Invoke();
	}

   
}
