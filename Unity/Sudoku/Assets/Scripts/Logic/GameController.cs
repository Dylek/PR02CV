using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {


    public static GameController instance = null;
    protected Button clickedFieldButton=null;
    private int xButton;
    private int yButtom;
    //private Color pressed = new Color();    
    private Color colorBackup=new Color();
    private SudokuField[,] sudokuBoard = new SudokuField[9, 9];

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
        //TODO zbierz buttony
        Debug.Log("sudokuBoard[temp.y][temp.x]|:" + sudokuBoard.GetType());
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        Debug.Log(buttons.Length);
        //TODO powsadzaj je w odpowiednie miejsca
        foreach (GameObject obj in buttons)
        {
            SudokuField ten = obj.GetComponent<SudokuField>();
           // Debug.Log("ten|:"+ten.GetInstanceID());

            //SudokuField temp = GameObject.FindObjectOfType<SudokuField>();
           // Debug.Log("temp|:" + temp.GetInstanceID());
            //SudokuField temp = obj.GetComponent<SudokuField>();
            sudokuBoard[ten.y-1, ten.x-1] = ten;//TU COŚ NIE PYKA
            //Debug.Log("sudokuBoard[ten.y][ten.x]|:" + sudokuBoard.GetType());
            Debug.Log("sudokuBoard["+ (ten.y - 1) + ","+(ten.x - 1) +"|:" + sudokuBoard[ten.y - 1, ten.x - 1].gameObject.GetInstanceID());

        }
        //TODO odpal generowanie sudoku w zależności od poziomu
        SudokuGenerator.GenerateSudokuBoard(DifficultLevel.medium);
        Debug.Log("WTF:"+sudokuBoard[4,7]);       
        foreach(SudokuField sd in sudokuBoard)
        {
            int k;
            k = sd.y;
            k = sd.x;
            // sd.sudokuValue = SudokuGenerator.a[sd.y, sd.x];
            int a=SudokuGenerator.a[sd.y - 1, sd.x - 1];
            sd.SudokuValue = SudokuGenerator.a[sd.y-1,sd.x-1];
        }
        // ColorUtility.TryParseHtmlString("0D17E4FF", out pressed);
    }
	
	public void SetButtonNumber(int a)
    {
        Debug.Log("yButtom-xButton:" + (yButtom ) +":"+ (xButton ));
        sudokuBoard[yButtom-1,xButton-1].SetText(a.ToString());
        sudokuBoard[yButtom-1,xButton-1].sudokuValue = a;
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

    public void ClearField(SudokuField suF)
    {
        suF.sudokuValue = 0;
        suF.SetText(" ");
    }
    public void CheckGameRules()
    {
        //TODO w kij dużo if'ów
    }


    
}
