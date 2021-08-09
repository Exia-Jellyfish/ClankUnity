using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{
    
    private void Awake()
    {
        Rigidbody boardRb = transform.root.gameObject.GetComponent<Rigidbody>();
        GetComponent<FixedJoint>().connectedBody = boardRb;
    }
    public void OnMouseDown()
    {
        Debug.Log("Click on a Tile");
    }
}
