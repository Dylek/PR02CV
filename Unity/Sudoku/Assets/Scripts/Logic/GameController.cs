using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {


    public static GameController instance = null;
    protected Button clickedFieldButton=null;
    public ScoreController scoreControll;
    public Timer timer;
    public InterfaceController interfaceControll;
    private int xButton;
    private int yButtom;
    //private Color pressed = new Color();    
    private Color colorBackup=new Color();
    private SudokuField[,] sudokuBoard = new SudokuField[9, 9];
    private bool toContinue = false;
    private bool pouse = false;

    //Robimy singleton
    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
        
        clickedFieldButton = null;
      
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");    
       
        foreach (GameObject obj in buttons)
        {
            SudokuField ten = obj.GetComponent<SudokuField>();       
            sudokuBoard[ten.y-1, ten.x-1] = ten;           

        }
        //TODO odpal generowanie sudoku w zależności od poziomu
        SudokuGenerator.GenerateSudokuBoard(DifficultLevel.medium);
        Debug.Log("WTF:"+sudokuBoard[4,7]);       
        foreach(SudokuField sd in sudokuBoard)
        {           
            
            int a=SudokuGenerator.a[sd.y - 1, sd.x - 1];
            sd.SudokuValue = SudokuGenerator.a[sd.y-1,sd.x-1];
            if (a != 0)
            {
                sd.button.interactable = false;                
            }
        }
        
        Debug.Log(MyPlayerSave.PlayerNick);
        interfaceControll.nick.text = MyPlayerSave.PlayerNick;
        interfaceControll.timer.text = "Time: " + MyPlayerSave.PlayerTime;
        interfaceControll.score.text = "Score: " + MyPlayerSave.PlayerScore;
        SoundController.instance.PlayBackground(SoundController.instance.music1);
    }
	
	public void SetButtonNumber(int a)
    {
        
        Debug.Log("yButtom-xButton:" + (yButtom ) +":"+ (xButton ));
        sudokuBoard[yButtom-1,xButton-1].SetText(a.ToString());
        sudokuBoard[yButtom-1,xButton-1].SudokuValue = a;
    }

    public void SetClicked(SudokuField sudokuField)
    {
       
        xButton = sudokuField.x;
        yButtom = sudokuField.y;

        if (!GameObject.ReferenceEquals(clickedFieldButton, null))
        {
            clickedFieldButton.image.color = colorBackup;
        }
        
        colorBackup = sudokuField.button.image.color;       
        clickedFieldButton = sudokuField.button;
        sudokuField.button.image.color = Color.red;
       
    }

    public void ClearField()
    {
        addScore(-10);
        sudokuBoard[yButtom-1,xButton-1].SudokuValue = 0;
        //clickedFieldButton.SetText(" ");
    }

    //False jeśli mamy błędy, true jeśli ok(albo mamy gdzieś puste pola
    public bool CheckGameRules()
    {
        int errors = 0;
        int empty = 0;

        Dictionary<int, int> dictCheck = new Dictionary<int, int>();
        for(int i = 0; i <= 9; i++)
        {
            dictCheck.Add(i, 0);
        }
        int[,] intBoard = getBoardInINT();
        for(int i = 0; i < 9; i++)        {
            for(int j = 0; j < 9; j++)            {
                
               
                dictCheck[intBoard[i, j]] = dictCheck[intBoard[i, j]] + 1;
            }
            if (dictCheck[0] > 0)
            {
                empty += 1;
            }
            for (int j = 1; j <= 9; j++)
            {
                if (dictCheck[j] > 1)
                {
                    // brak zer, ale coś się powtarza, gdyż zbiór nie ma 9 elemntów
                    errors += 1;
                }
            }
            for (int l = 0; l <= 9; l++)
            {
                dictCheck[l] = 0;
            }
        }

        for (int i = 0; i < 9; i++)        {
            for (int j = 0; j < 9; j++)            {
                //lecimy po wierszach
                
               
                dictCheck[intBoard[j, i]]=dictCheck[intBoard[j, i]] +1;
            }
            if (dictCheck[0] > 0)
            {
                empty += 1;
            }
            for (int j = 1; j <= 9; j++)
            {
                if (dictCheck[j] > 1)
                {
                    // brak zer, ale coś się powtarza, gdyż zbiór nie ma 9 elemntów
                    errors += 1;
                }
            }
            for (int l = 0; l <= 9; l++)
            {
                dictCheck[l]=0;
            }
        }

        int iBase = 0;
        int jBase = 0;

        while (iBase<9)        {
            for (int i = 0 + iBase; i < 3 + iBase; i++)            {
                for (int j = 0 + jBase; j < 3 + jBase; j++)                {                                 
                    
                    dictCheck[intBoard[j, i]]=dictCheck[intBoard[j, i]] + 1;
                }

            }
           
            if (dictCheck[0] > 0)
            {
                empty += 1;
            }
            for (int j = 1; j <= 9; j++)
            {
                if (dictCheck[j] > 1)
                {
                    // brak zer, ale coś się powtarza, gdyż zbiór nie ma 9 elemntów
                    errors += 1;
                }
            }
            //dictCheck.Clear();

            for (int l = 0; l <= 9; l++)
            {
                dictCheck[l]=0;
            }
           
            jBase += 3;
            if (jBase > 6){
                jBase = 0;
                iBase += 3;
            }
        }


        if (errors == 0 && empty == 0)
        {
            addScore(400);
            Debug.Log("WIN");
            GameOver();
            return true;//true bo ok i wygrana
        }
        else if (errors == 0) {
            Debug.Log("errors = 0");
            return true;//true bo ok
        }
        else
        {
            addScore(-5 * errors);
            Debug.Log("NOPE minus points");
        }
        Debug.Log("errors = "+errors);
        return false;//domyślnie jest błąd
    }

    private int[,] getBoardInINT()
    {
        int [,] intBoard = new int[9, 9];
        foreach (SudokuField sd in sudokuBoard)
        {
            intBoard[sd.y-1, sd.x-1] = sd.SudokuValue;          
        }
        return intBoard;
    }

    private void addScore(int a)
    {
        interfaceControll.setScoreText(scoreControll.Score);
        scoreControll.addScore(a);
    }

    private void GameOver()
    {

    }


    public void PauseGame()
    {
        if (Time.timeScale != 0) { Time.timeScale = 0; pouse = true; }
        else
        {
            Time.timeScale = 1.0f;
            pouse = false;
        }      
    }

    public SudokuField[,] getSB()
    {
        return sudokuBoard;
    }

    void OnDisable()
    {
        MyPlayerSave.BoardValues = sudokuBoard;
    }

}
