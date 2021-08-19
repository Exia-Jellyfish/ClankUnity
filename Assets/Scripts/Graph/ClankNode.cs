using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankNode : Node
{
    public TileState state = TileState.NONE;
    public TileType type = TileType.NONE;
    public List<SecretToken> secrets;
    public Artifact artifact;
    public int monkeys;
    public bool isUnderGround;

    /*    private void Start()
        {
            secrets = new List<SecretToken>();
        }*/

    public void Sheet()
    {
        Debug.Log("cheat");
    }
}
