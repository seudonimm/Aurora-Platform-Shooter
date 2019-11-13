using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CharacterSelect
{
    public static int p1Character, p2Character, stage;

    public static int P1CharSelected
    {
        get
        {
            return p1Character;
        }
        set
        {
            p1Character = value;
        }
    }

    public static int P2CharSelected
    {
        get
        {
            return p2Character;
        }
        set
        {
            p2Character = value;
        }
    }

    public static int StageSelected
    {
        get
        {
            return stage;
        }
        set
        {
            stage = value;
        }
    }
}
