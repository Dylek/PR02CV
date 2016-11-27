using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour {

    public Text timer;
    public Text score;
    public Text nick;
    public Text infoText;
    private GameController gameContoller;
    public GameObject pauseMenu;
    public Text muteButt;
    private bool muted;
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
        SoundController.instance.ButtonClicked();
        Debug.Log("Sudoku Fields:"+su.GetType());
        GameController.instance.SetClicked(su);
    }

    public void ClearFieldButt()
    {
        gameContoller.ClearField();
    }
    public void CheckGameRulesButt()
    {
        bool what;
        what=gameContoller.CheckGameRules();
        Debug.Log("Rules: "+what);
        string strWhat = what ? "You dont have errors": "You have errors" ;
        infoText.text=strWhat;
    }

    public void PouseMenu()
    {
        GameController.instance.PauseGame();
        pauseMenu.SetActive(true);
    }
    public void BackToGame()
    {
        GameController.instance.PauseGame();
        pauseMenu.SetActive(false);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("game");
    }
    public void ExitGame()
    {
        SaveController.SaveGame();
        Debug.Log("Exit Game");
        Application.Quit();
    }
    public void MuteSound()
    {
        if (muted)
        {
            SoundController.instance.SetSound(1);
            muteButt.text = "Mute Sound";
            muted = false;
        }
        else
        {
            SoundController.instance.SetSound(0);
            muteButt.text = "UnMute Sound";
            muted = true;
        }
       
        
    }
}
