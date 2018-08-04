using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TileRotator : MonoBehaviour {

    public TilePiece targetPiece;

    public UnityEvent OnClick;

    private void RotatePiece()
    {
        targetPiece.transform.Rotate(new Vector3(0, 0, -90));
    }

    public void SubscribeClickToRotate()
    {
        OnClick.AddListener(RotatePiece);
    }

    public void Start()
    {
       
    }

    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
