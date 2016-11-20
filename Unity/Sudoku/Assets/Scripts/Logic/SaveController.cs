using UnityEngine;
using System.Collections;

public static class SaveController  {

 

  public static void GetSavedGame()
    {
        string diffLevel;
        PlayerOptions.PlayerGameType = PlayerPrefs.GetInt("PlayerGameType");
        PlayerOptions.PlayerNick = PlayerPrefs.GetString("PlayerNick");
        diffLevel = PlayerPrefs.GetString("PlayerLevel");
        switch (diffLevel)
        {
            case "easy": PlayerOptions.PlayerLevel = DifficultLevel.easy; break;
            case "medium": PlayerOptions.PlayerLevel = DifficultLevel.medium; break;
            case "hard": PlayerOptions.PlayerLevel = DifficultLevel.hard; break;
            default: PlayerOptions.PlayerLevel = DifficultLevel.easy; break;
        }
        PlayerOptions.PlayerTime = PlayerPrefs.GetFloat("PlayerTime");
        PlayerOptions.PlayerScore = PlayerPrefs.GetInt("PlayerScore");
    }

    public static void SaveGame()
    {      
    
        PlayerPrefs.SetInt("PlayerGameType", PlayerOptions.PlayerGameType);
        PlayerPrefs.SetString("PlayerNick", PlayerOptions.PlayerNick);
        PlayerPrefs.SetString("PlayerLevel", PlayerOptions.PlayerLevel.ToString());
        Debug.Log(PlayerOptions.PlayerLevel.ToString());
        PlayerPrefs.SetFloat("PlayerTime", PlayerOptions.PlayerTime);
         PlayerPrefs.SetInt("PlayerScore", PlayerOptions.PlayerScore);
    }



}
