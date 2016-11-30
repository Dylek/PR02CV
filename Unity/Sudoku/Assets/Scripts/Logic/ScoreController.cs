using UnityEngine;
using System.Collections;
using System;

[Serializable]
public struct nickScore
{
    public string nick;
    public int score;
   public nickScore(String nick2, int score2)
    {
        nick = nick2;
        score = score2;
    }
}

[Serializable]
public class ScoreController : MonoBehaviour {

    public nickScore[,] scoreBoard = new nickScore[3,5];

    private int score = 0;
    public int Score
    {
        get { return score; }
        set { score = (int)value ; }
    }
    public void addScore(int a)
    {
        Score = score + a;
    }
	// Use this for initialization
	void Start () {
        // wynik po powrocie do gry
        score = MyPlayerSave.PlayerScore;
        //utwórz zwykła tablicę z empty 0
        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            initHighScoreBoard();
            PlayerPrefs.SetInt("isFirstTime", 0);
            PlayerPrefs.Save();
        }else
        {
            int j = 0;
            JSONObject json = new JSONObject(PlayerPrefs.GetString("highScores"));
            foreach(String key in json.keys)
            {
                for(int i = 0; i < 5; i++)
                {
                    Debug.Log(json.GetField(key).ToString());
                    scoreBoard[j, i] = new nickScore(json.GetField(key)[i].GetField("nick").ToString(), Int32.Parse((json.GetField(key)[i].GetField("score").ToString())));
                }
            }
        }
        
        
	}
	
    void OnDestroy()
    {
        int k=-1;
        switch (MyPlayerSave.PlayerLevel)
        {
           case DifficultLevel.easy: k = 0;break;
            case DifficultLevel.medium: k = 1; break;
            case DifficultLevel.hard: k = 0; break;
            default : k = 0; break;
        }
        for(int i = 0; i < 5; i++)
        {
            if (scoreBoard[k, i].score < score)
            {
                for(int j = 0; j < i; j++)
                {
                    scoreBoard[k, j] = scoreBoard[k, j + 1];
                }
                scoreBoard[k, i] = new nickScore(MyPlayerSave.PlayerNick,score);
            }
        }
        JSONObject jsonS = new JSONObject();
        JSONObject arr = new JSONObject();
        JSONObject temp = new JSONObject();

        for(int i = 0; i < 5; i++)
        {
            temp.Clear();
            temp.AddField("nick", scoreBoard[0, i].nick);
            temp.AddField("score", scoreBoard[0, i].score);
            arr.Add(temp);
        }
        jsonS.AddField("easy", arr);

        for (int i = 0; i < 5; i++)
        {
            temp.Clear();
            temp.AddField("nick", scoreBoard[1, i].nick);
            temp.AddField("score", scoreBoard[1, i].score);
            arr.Add(temp);
        }
        jsonS.AddField("medium", arr);

        for (int i = 0; i < 5; i++)
        {
            temp.Clear();
            temp.AddField("nick", scoreBoard[2, i].nick);
            temp.AddField("score", scoreBoard[2, i].score);
            arr.Add(temp);
        }
        jsonS.AddField("hard", arr);

        PlayerPrefs.SetString("highScores",jsonS.ToString());
        Debug.Log(jsonS);
        PlayerPrefs.Save();

    }

    public static void initHighScoreBoard()
    {

        JSONObject arr = new JSONObject();
        JSONObject empty = new JSONObject();
        empty.AddField("nick", "empty");
        empty.AddField("score", 0);
        arr.Add(empty);
        arr.Add(empty);
        arr.Add(empty);
        arr.Add(empty);
        arr.Add(empty);
        JSONObject jsonOb = new JSONObject();
        jsonOb.AddField("easy", arr);
        jsonOb.AddField("medium", arr);
        jsonOb.AddField("hard", arr);
        
        PlayerPrefs.SetString("highScores", jsonOb.ToString());
        Debug.Log(PlayerPrefs.GetString("highScores"));
       // Debug.Log(initB.ToString());
        PlayerPrefs.Save();
    }



}
