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
            string str = PlayerPrefs.GetString("highScores");
            scoreBoard = JsonUtility.FromJson<nickScore[,]>(str);
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

        string jsonS = JsonUtility.ToJson(scoreBoard);
        PlayerPrefs.SetString("highScores",jsonS);
        Debug.Log(jsonS);
        PlayerPrefs.Save();

    }

    public static void initHighScoreBoard()
    {
        nickScore[,] initB = new nickScore[3, 5];
        String scores = "{\"scores\":[";
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                //initB[j,i] = new nickScore("EMPTY",0);
               // Debug.Log(JsonUtility.ToJson(initB[j, i]));
                scores = scores + "{\"nick\":\"Empty\",\"score\":0},";            
                
            }

        }
       
        scores = scores.Substring(0,scores.Length-1) + "]}";
        Debug.Log(scores);
        JSONObject jsonOb = new JSONObject(scores);

        //Debug.Log(JsonUtility.ToJson(scores));
        string jsonS = JsonUtility.ToJson(initB);
        PlayerPrefs.SetString("highScores", jsonOb.ToString());
        Debug.Log(PlayerPrefs.GetString("highScores"));
       // Debug.Log(initB.ToString());
        PlayerPrefs.Save();
    }



}
