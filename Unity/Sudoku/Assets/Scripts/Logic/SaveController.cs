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
        string str = PlayerPrefs.GetString("PlayerBoad");
        string[] strT = str.Split(',');
        MyPlayerSave.boardValues = new int[81];
        for (int i = 0; i < 81; i++)
        {
            MyPlayerSave.boardValues[i] = int.Parse(strT[i]);
        }
    }

    public static void SaveGame()
    {      
        
        PlayerPrefs.SetInt("PlayerGameType", MyPlayerSave.PlayerGameType);
        PlayerPrefs.SetString("PlayerNick", MyPlayerSave.PlayerNick);
        PlayerPrefs.SetString("PlayerLevel", MyPlayerSave.PlayerLevel.ToString());
        Debug.Log(MyPlayerSave.PlayerLevel.ToString());
        PlayerPrefs.SetFloat("PlayerTime", MyPlayerSave.PlayerTime);
        PlayerPrefs.SetInt("PlayerScore", MyPlayerSave.PlayerScore);
        string str = "";
        //Tu coś nie pyka
        for (int i = 0; i < 81; i++)
        {
            str = str + "," + MyPlayerSave.boardValues[i];
        }
    }



}
