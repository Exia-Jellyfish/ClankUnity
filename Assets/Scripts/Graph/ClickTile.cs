using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTile : MonoBehaviour
{
    private MeshRenderer mesh;
    private void Awake()
    {
        Rigidbody boardRb = transform.root.gameObject.GetComponent<Rigidbody>();
        GetComponent<FixedJoint>().connectedBody = boardRb;
        mesh = GetComponent<MeshRenderer>();
    }
    public void OnMouseDown()
    {
        Debug.Log("Click on a Tile");
    }

    private void OnMouseOver()
    {
        mesh.enabled = true;
    }

    private void OnMouseExit()
    {
        mesh.enabled = false;
    }
}
