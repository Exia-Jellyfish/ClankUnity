using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClankNode : Node
{
/*    public ClankNode(int id) : base(id)
    {

    }*/
    public enum TileState
    {
        NONE,
        HEAL,
        SECRET,
        ARTIFACT,
        MONKEY,
    }

    public enum TileType
    {
        NONE,
        SHOP,
        CRYSTAL_CAVERNS,
    }
    public TileState state = TileState.NONE;
    public TileType type = TileType.NONE;
    public SecretToken[] secrets;
    public Artifact artifact;
    public int monkeys;
    public bool isUnderGround;


    public void Sheet()
    {
        Debug.Log("cheat");
    }
}
