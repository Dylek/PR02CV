using UnityEngine;
using System.Collections;

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
        startButton.SetActive(true);
        backButton.SetActive(true);

    }


    public void BackButton()
    {
        BringInitMenu();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void ContinueButton()
    {

    }

    public void StartGame()
    {

    }
    public void ViewScoresButton() { }
    public void ViewTutorialButton() { }
    private void BringInitMenu()
    {
        exitButton.SetActive(true);
        newGameButton.SetActive(true);
        scoresButton.SetActive(true);
        tutorialButton.SetActive(true);
        continueButton.SetActive(true);

        backButton.SetActive(false);
        diffSlider.SetActive(false);
        gameTypeStuff.SetActive(false);
        startButton.SetActive(false);
    }
}
