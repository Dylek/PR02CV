using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour {

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
	}
	
	
}
