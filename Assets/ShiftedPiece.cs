using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class ShiftedPiece : MonoBehaviour {

    public Vector3 direction;
    public UnityEvent OnUpdate;

    void Translate()
    {
        Transform parent = this.transform.parent;
        parent.Translate(direction, Space.World);
    }

    void RenewOnUpdate()
    {
        this.OnUpdate = new UnityEvent();
    }

    private void ShiftOnce()
    {
        Translate();
        RenewOnUpdate();
    }

    public void SubscribeSingleShift(Vector3 direction)
    {
        this.direction = direction;
        OnUpdate.AddListener(ShiftOnce);
    }

	
	// Update is called once per frame
	void Update () {
        OnUpdate.Invoke();
	}

   
}
