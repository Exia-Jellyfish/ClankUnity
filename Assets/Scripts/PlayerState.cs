using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    private int skillPoints;
    private int attack;
    private int movement;
    private int clankCubes = 30;
    private int healthMeter;
    private int gold;
    private bool isUnstoppable;
    private bool isPlaying;
    private bool hasArtifact;

    public int SkillPoints { get => skillPoints; set => skillPoints = value; }
    public int Attack { get => attack; private set => attack = value; }
    public int Movement { get => movement; set => movement = value; }
    public int ClankCubes { get => clankCubes; set => clankCubes = value; }
    public int HealthMeter { get => healthMeter; set => healthMeter = value; }
    public int Gold { get => gold; private set => gold = value; }
    public bool IsUnstoppable { get => isUnstoppable; set => isUnstoppable = value; }
    public bool IsPlaying { get => isPlaying; private set => isPlaying = value; }
    public bool HasArtifact { get => hasArtifact; private set => hasArtifact = value; }
}
