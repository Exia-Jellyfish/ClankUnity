using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    private int skillPoints;
    private int attack;
    private int movements;
    private int clankCubes = 30;
    private int clankCounter;
    private int healthBar;
    private int gold;
    private bool isUnstoppable;
    private bool isPlaying;
    private bool hasArtifact;

    public int SkillPoints { get => skillPoints; private set => skillPoints = value; }
    public int Attack { get => attack; private set => attack = value; }
    public int Movements { get => movements; private set => movements = value; }
    public int ClankCubes { get => clankCubes; private set => clankCubes = value; }
    public int ClankCounter { get => clankCounter; private set => clankCounter = value; }
    public int HealthBar { get => healthBar; private set => healthBar = value; }
    public int Gold { get => gold; private set => gold = value; }
    public bool IsUnstoppable { get => isUnstoppable; private set => isUnstoppable = value; }
    public bool IsPlaying { get => isPlaying; private set => isPlaying = value; }
    public bool HasArtifact { get => hasArtifact; private set => hasArtifact = value; }

    public void AddToClankCounter(int value)
    {
        if (value > 0)
        {
            if (ClankCubes >= value)
            {
                ClankCounter += value;
                ClankCubes -= value;
            }
            else
            {
                ClankCounter += ClankCubes;
                ClankCubes = 0;
            }
        }
        else
        {
            value = -value ;
            if (ClankCounter >= value)
            {
                ClankCubes += value;
                ClankCounter -= value;
            }
            else
            {
                ClankCubes += ClankCounter;
                ClankCounter = 0;
            }
        }

    }

    public void AddToHealthBar(int value)
    {
        if (value > 0)
        {
            if (HealthBar < 10 && ClankCubes >= value)
            {
                ClankCubes += value;
                HealthBar += value;
            }
            else
            {
                
            }
        }
    }
    //private bool isActive;



}
