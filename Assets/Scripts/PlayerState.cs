using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    private int skillPoints;
    private int attack;
    private int movements;
    private int clankCubes = 30;
    private int healthMeter;
    private int gold;
    private bool isUnstoppable;
    private bool isPlaying;
    private bool hasArtifact;

    public int SkillPoints { get => skillPoints; private set => skillPoints = value; }
    public int Attack { get => attack; private set => attack = value; }
    public int Movements { get => movements; private set => movements = value; }
    public int ClankCubes { get => clankCubes; set => clankCubes = value; }
    public int HealthMeter { get => healthMeter; set => healthMeter = value; }
    public int Gold { get => gold; private set => gold = value; }
    public bool IsUnstoppable { get => isUnstoppable; private set => isUnstoppable = value; }
    public bool IsPlaying { get => isPlaying; private set => isPlaying = value; }
    public bool HasArtifact { get => hasArtifact; private set => hasArtifact = value; }
}
