using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class MovementArrow : MonoBehaviour
{

    public static void SubscribeAllToShiftTiles()
    {
        MovementArrow[] arrows = GameObject.FindObjectsOfType<MovementArrow>();
        foreach (MovementArrow arrow in arrows)
        {
            arrow.SubscribeShiftTiles();
        }
    }

    public UnityEvent OnClick;

    public void ShiftTiles()
    {
        Vector2 rayStart, rayEnd;
        float rayLength = 10;

        rayStart = this.transform.position;
        rayEnd = this.transform.up * rayLength;

        int layerMask = 1 << 8;
        List<RaycastHit2D> rayHit = Physics2D.RaycastAll(rayStart, this.transform.up, rayLength, layerMask).ToList();

        foreach (RaycastHit2D rayhit2D in rayHit)
        {
            Transform rayhitTransform = rayhit2D.transform;
            ShiftedPiece shiftedPiece = rayhitTransform.GetComponentInChildren<ShiftedPiece>();
            
            if (shiftedPiece != null)
                shiftedPiece.SubscribeSingleShift(this.transform.up);
        }
    }

    public void SubscribeShiftTiles()
    {
        OnClick.AddListener(ShiftTiles);
    }

    // Use this for initialization
    void Start()
    {
        // ShiftTiles();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
