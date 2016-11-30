using UnityEngine;
using System.Collections;
using System;

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

        JSONObject obj = new JSONObject(PlayerPrefs.GetString("sudokuBoard"));
        SudokuField[,] sudokuBoard = new SudokuField[9, 9];

        foreach (string key in obj.keys) {
            Debug.Log(obj.GetField(key).ToString());
            int x= Int32.Parse(obj.GetField(key).GetField("x").ToString());
            int y= Int32.Parse(obj.GetField(key).GetField("y").ToString());
            int val= Int32.Parse(obj.GetField(key).GetField("value").ToString());
            bool gen = obj.GetField(key).GetField("y").ToString().Equals("true") ? true : false;
            sudokuBoard[y - 1, x - 1] = new SudokuField(x, y, val, gen);
        }               
        Debug.Log(obj.keys);

            }

    public static void SaveGame()
    {
       
        PlayerPrefs.SetInt("PlayerGameType", MyPlayerSave.PlayerGameType);
        PlayerPrefs.SetString("PlayerNick", MyPlayerSave.PlayerNick);
        PlayerPrefs.SetString("PlayerLevel", MyPlayerSave.PlayerLevel.ToString());
        Debug.Log(MyPlayerSave.PlayerLevel.ToString());
        PlayerPrefs.SetFloat("PlayerTime", MyPlayerSave.PlayerTime);
        PlayerPrefs.SetInt("PlayerScore", MyPlayerSave.PlayerScore);


        JSONObject json = MyPlayerSave.getJSONBoard();

       
        PlayerPrefs.SetString("sudokuBoard", json.ToString());
       
        PlayerPrefs.Save();
    }



}
