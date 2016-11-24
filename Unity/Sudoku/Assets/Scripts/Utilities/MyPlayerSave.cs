using UnityEngine;
using System.Collections;

public class MyPlayerSave : MonoBehaviour {

    private static string playerNick="";
    private static int playerScore=0;
    private static float playerTime=0;
    private static DifficultLevel playerLevel=DifficultLevel.easy;
    private static int playerGameType=0;
    private static int[] boardValues;


    public static string PlayerNick
    {
        get
        {
            return playerNick;
        }

        set
        {
            playerNick = value;
        }
    }

    public static int PlayerScore
    {
        get
        {
            return playerScore;
        }

        set
        {
            playerScore = value;
        }
    }

    public static float PlayerTime
    {
        get
        {
            return playerTime;
        }

        set
        {
            playerTime = value;
        }
    }

    public static DifficultLevel PlayerLevel
    {
        get
        {
            return playerLevel;
        }

        set
        {
            playerLevel = value;
        }
    }

    public static int PlayerGameType
    {
        get
        {
            return playerGameType;
        }

        set
        {
            playerGameType = value;
        }
    }

   
}
