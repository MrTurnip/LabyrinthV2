using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;




public class ShiftedPiece : MonoBehaviour {

    public Vector3 direction;
    public UnityEvent OnUpdate;

    void SafeTranslate()
    {
        Transform parent = this.transform.parent;
        parent.Translate(direction, Space.World);

        Vector2 parentPos = parent.position;
        if (parentPos.x < -5)
            parentPos.x = 4.5f;
        if (parentPos.x > 5)
            parentPos.x = -4.5f;
        if (parentPos.y > 5)
            parentPos.y = -4.5f;
        if (parentPos.y < -5)
            parentPos.y = 4.5f;

        parent.position = parentPos;
    }

    void RenewOnUpdate()
    {
        this.OnUpdate = new UnityEvent();
    }

    private void ShiftOnce()
    {
        SafeTranslate();
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
