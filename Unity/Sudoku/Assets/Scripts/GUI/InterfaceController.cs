using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class InterfaceController : MonoBehaviour {

    public Text timer;
    public Text score;
    public Text nick;
    private GameController gameContoller;
    // Use this for initialization
    void Start() {
        gameContoller = GameController.instance;
    }

    // Update is called once per frame
    public void setScoreText(int points)
    {
        score.text = "Score: " + points;
    }
    
    public void NumberClicked(int a)
    {
        gameContoller.SetButtonNumber(a);
    }

    public void SudokuFieldCliecked(SudokuField su)
    {
        
        Debug.Log("Sudoku Fields:"+su.GetType());
        GameController.instance.SetClicked(su);
    }

    public void ClearFieldButt()
    {
        gameContoller.ClearField();
    }
    public void CheckGameRulesButt()
    {
        gameContoller.CheckGameRules();
    }

}
