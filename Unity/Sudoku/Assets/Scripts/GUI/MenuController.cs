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
    public Slider diffSlider;
    public Slider gameTypeStuff;
    public InputField nick;

	// Use this for initialization
	void Start () {

        BringInitMenu();



    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void NewGame()
    {
        newGameButton.SetActive(false);
        scoresButton.SetActive(false);
        tutorialButton.SetActive(false);
        continueButton.SetActive(false);
        diffSlider.gameObject.SetActive(true);
        gameTypeStuff.gameObject.SetActive(true);
        nick.gameObject.SetActive(true);
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
        //nie robić save Controlla?
        //tu od razu będę robnił

    }

    public void StartGame()
    {
        DifficultLevel diff;
        switch ((int)diffSlider.value)
        {
            case 1: diff = DifficultLevel.easy;break;
            case 2: diff = DifficultLevel.easy; break;
            case 3: diff = DifficultLevel.easy; break;
            default: diff = DifficultLevel.easy; break;
        }
        PlayerOptions.PlayerGameType =(int) gameTypeStuff.value;
        PlayerOptions.PlayerNick = nick.text;
        PlayerOptions.PlayerLevel = diff;
        SceneManager.LoadScene("Sudoku");

    }
    public void ViewScoresButton(int a) {
    }
    public void ViewTutorialButton(int a) {
        Debug.Log("how to play");
    }
    private void BringInitMenu()
    {
        exitButton.SetActive(true);
        newGameButton.SetActive(true);
        scoresButton.SetActive(true);
        tutorialButton.SetActive(true);
        continueButton.SetActive(true);
        nick.gameObject.SetActive(false);
        backButton.SetActive(false);
        diffSlider.gameObject.SetActive(false);
        gameTypeStuff.gameObject.SetActive(false);
        startButton.SetActive(false);
    }

    //Sprawdzenie czy w player prefabs jest UnfinishedGame
    private bool CheckSave()
    {
        bool unfinishedGame = false;
        string diffLevel;
        unfinishedGame = PlayerPrefs.HasKey("unfinishedGame");
        PlayerOptions.PlayerGameType = PlayerPrefs.GetInt("PlayerGameType");
        PlayerOptions.PlayerNick = PlayerPrefs.GetString("PlayerNick");
        diffLevel = PlayerPrefs.GetString("PlayerLevel");
        switch (diffLevel)
        {
            case "easy": PlayerOptions.PlayerLevel = DifficultLevel.easy;break;
            case "medium": PlayerOptions.PlayerLevel = DifficultLevel.medium; break;
            case "hard": PlayerOptions.PlayerLevel = DifficultLevel.hard; break;
            default:   PlayerOptions.PlayerLevel = DifficultLevel.easy; break;
        }
        PlayerOptions.PlayerTime = PlayerPrefs.GetFloat("PlayerTime");
        PlayerOptions.PlayerScore = PlayerPrefs.GetInt("PlayerScore");
        return unfinishedGame;
    }
}
