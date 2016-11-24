using UnityEngine;
using System.Collections;

public static class SaveController  {

 

  public static void GetSavedGame()
    {
        string diffLevel;
        MyPlayerSave.PlayerGameType = PlayerPrefs.GetInt("PlayerGameType");
        MyPlayerSave.PlayerNick = PlayerPrefs.GetString("PlayerNick");
        diffLevel = PlayerPrefs.GetString("PlayerLevel");
        switch (diffLevel)
        {
            case "easy": MyPlayerSave.PlayerLevel = DifficultLevel.easy; break;
            case "medium": MyPlayerSave.PlayerLevel = DifficultLevel.medium; break;
            case "hard": MyPlayerSave.PlayerLevel = DifficultLevel.hard; break;
            default: MyPlayerSave.PlayerLevel = DifficultLevel.easy; break;
        }
        MyPlayerSave.PlayerTime = PlayerPrefs.GetFloat("PlayerTime");
        MyPlayerSave.PlayerScore = PlayerPrefs.GetInt("PlayerScore");
    }

    public static void SaveGame()
    {      
        
        PlayerPrefs.SetInt("PlayerGameType", MyPlayerSave.PlayerGameType);
        PlayerPrefs.SetString("PlayerNick", MyPlayerSave.PlayerNick);
        PlayerPrefs.SetString("PlayerLevel", MyPlayerSave.PlayerLevel.ToString());
        Debug.Log(MyPlayerSave.PlayerLevel.ToString());
        PlayerPrefs.SetFloat("PlayerTime", MyPlayerSave.PlayerTime);
        PlayerPrefs.SetInt("PlayerScore", MyPlayerSave.PlayerScore);
    }



}
