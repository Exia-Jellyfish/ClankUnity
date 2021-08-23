using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    private int skillpoints;
    private int attack;
    private int movement;
    private int clankCubes = 30;
    private int healthMeter;
    private int gold;
    private bool isStuck = false;
    private bool isUnstoppable;
    private bool isPlaying;
    private bool hasArtifact;
    private int victoryPoints;

    public int Skillpoints { get => skillpoints; set => skillpoints = value; }
    public int Attack { get => attack; set => attack = value; }
    public int Movement { get => movement; set => movement = value; }
    public int ClankCubes { get => clankCubes; set => clankCubes = value; }
    public int HealthMeter { get => healthMeter; set => healthMeter = value; }
    public int Gold { get => gold; set => gold = value; }
    public bool IsUnstoppable { get => isUnstoppable; set => isUnstoppable = value; }
    public bool IsPlaying { get => isPlaying; private set => isPlaying = value; }
    public bool HasArtifact { get => hasArtifact; set => hasArtifact = value; }
    public bool IsStuck { get => isStuck; set => isStuck = value; }
    public int VictoryPoints { get => victoryPoints; set => victoryPoints = value; }
}
