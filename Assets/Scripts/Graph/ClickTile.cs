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

    public void LightOn()
    {
        mesh.enabled = true;
    }

    public void LightOff()
    {
        mesh.enabled = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Click on a Tile");
        if (GameManager.GetInstance().PlayerController.Id != GameManager.GetInstance().ActivePlayer) return;
        GameManager.GetInstance().TryToMovePlayerToken(0, GetComponent<ClankNode>());
    }
}
