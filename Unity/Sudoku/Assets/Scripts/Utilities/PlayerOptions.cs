using UnityEngine;
using System.Collections;

public class PlayerOptions : MonoBehaviour {
    private static string playerNick;
    private static int playerScore;
    private static float playerTime;
    private static DifficultLevel playerLevel;
    private static int playerGameType;

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

    public static  int PlayerScore
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
