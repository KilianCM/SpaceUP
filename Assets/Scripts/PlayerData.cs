using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerData
{
    private static int failsScore = 0;
    private static int moonMissionScore=0;

    public static int FailsScore
    {
        get
        {
            return failsScore;
        }
        set
        {
            failsScore = value;
        }
    }
    public static int MoonMissionScore
    {
        get
        {
            return moonMissionScore;
        }
        set
        {
            moonMissionScore = value;
        }
    }

    public static int TotalScore()
    {
        return moonMissionScore + failsScore;
    }
}
