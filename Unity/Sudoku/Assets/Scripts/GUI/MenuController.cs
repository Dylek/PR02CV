using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject startButton;
    public GameObject exitButton;
    public GameObject newGameButton;
    public GameObject scoresButton;
    public GameObject tutorialButton;
    public GameObject continueButton;
    public GameObject backButton;
    public GameObject diffSlider;
    public GameObject gameTypeStuff;
    public GameObject nick;
    public GameObject rules;
    public GameObject scores;

    private Text scoreText;
	// Use this for initialization
	void Start () {
        BringInitMenu();
        scoreText = scores.GetComponent<Text>();
        Debug.Log("HighScores text found");
    }
	


    public void NewGame()
    {
        newGameButton.SetActive(false);
        scoresButton.SetActive(false);
        tutorialButton.SetActive(false);
        continueButton.SetActive(false);
        diffSlider.SetActive(true);
        gameTypeStuff.SetActive(true);
        nick.SetActive(true);
        
        startButton.SetActive(true);
        backButton.SetActive(true);

    }


    public void BackButton()
    {
        BringInitMenu();
    }

    public void ExitButton()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    public void ContinueButton()
    {
        if (CheckSave())
        {
            SaveController.GetSavedGame();
        }

    }

    public void StartGame()
    {
        DifficultLevel diff;
        switch ((int)diffSlider.GetComponent<Slider>().value)
        {
            case 1: diff = DifficultLevel.easy;break;
            case 2: diff = DifficultLevel.easy; break;
            case 3: diff = DifficultLevel.easy; break;
            default: diff = DifficultLevel.easy; break;
        }
        Debug.Log("switch ");
        MyPlayerSave.PlayerGameType =(int) gameTypeStuff.GetComponent<Slider>().value;
        Debug.Log("PlayerGameType");
        MyPlayerSave.PlayerNick = nick.GetComponent<InputField>().text;
        Debug.Log("PlayerNick");
        MyPlayerSave.PlayerLevel = diff;
        Debug.Log("PlayerLevel ");
        SceneManager.LoadScene("sudoku");

    }
    public void ViewScoresButton(int a) {
        scores.SetActive(true);
        ChangeMenu(false);

    }
    public void ViewTutorialButton(int a) {
        rules.SetActive(true);
        ChangeMenu(false);
        Debug.Log("how to play");
    }
    private void BringInitMenu()
    {
        exitButton.SetActive(true);
        newGameButton.SetActive(true);
        scoresButton.SetActive(true);
        tutorialButton.SetActive(true);
        continueButton.SetActive(true);
        nick.SetActive(false);
        backButton.SetActive(false);
        diffSlider.SetActive(false);
        gameTypeStuff.SetActive(false);
        startButton.SetActive(false);
        rules.SetActive(false);
        scores.SetActive(false);
        if (!CheckSave())
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
        if (!PlayerPrefs.HasKey("isFirstTime"))
        {
            scoresButton.GetComponent<Button>().interactable = false;
        }else
        {
            string str = PlayerPrefs.GetString("highScores");
            nickScore[,] scoreBoard = JsonUtility.FromJson<nickScore[,]>(str);
            
            scoreText.text = "EASY:";
            for (int i = 0; i < 5; i++)
            {
                scoreText.text = scoreText.text +"\n"+ scoreBoard[0,i].nick+"   :    "+ scoreBoard[0, i].score;
            }
            scoreText.text = scoreText.text+ "\nMEDIUM:";
            for (int i = 0; i < 5; i++)
            {
                scoreText.text = scoreText.text + "\n" + scoreBoard[1, i].nick + "   :    " + scoreBoard[1, i].score;
            }
            scoreText.text = scoreText.text + "\nHARD:";
            for (int i = 0; i < 5; i++)
            {
                scoreText.text = scoreText.text + "\n" + scoreBoard[2, i].nick + "   :    " + scoreBoard[2, i].score;
            }
        }
    }

    private void ChangeMenu(bool state)
    {
        newGameButton.SetActive(state);
        scoresButton.SetActive(state);
        tutorialButton.SetActive(state);
        continueButton.SetActive(state);
        backButton.SetActive(!state);
    }
    //Sprawdzenie czy w player prefabs jest UnfinishedGame
    private bool CheckSave()
    {
        bool unfinishedGame = false;
        unfinishedGame = PlayerPrefs.HasKey("unfinishedGame");       
        return unfinishedGame;
    }

     
}
