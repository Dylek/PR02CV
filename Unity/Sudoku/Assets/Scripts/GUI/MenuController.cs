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
        nick.SetActive(false);
        backButton.SetActive(false);
        diffSlider.SetActive(false);
        gameTypeStuff.SetActive(false);
        startButton.SetActive(false);
        if (!CheckSave())
        {
            continueButton.GetComponent<Button>().interactable = false;
        }
    }

    //Sprawdzenie czy w player prefabs jest UnfinishedGame
    private bool CheckSave()
    {
        bool unfinishedGame = false;
        unfinishedGame = PlayerPrefs.HasKey("unfinishedGame");
       
        return unfinishedGame;
    }
}
