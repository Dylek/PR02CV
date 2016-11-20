using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameController : MonoBehaviour {


    public static GameController instance = null;
    private Button clickedFieldButton;
    private int xButton;
    private int yButtom;
    private Color pressed = new Color();    
    private Color colorBackup;
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
            Debug.Log("ten|:"+ten.GetInstanceID());

            SudokuField temp = GameObject.FindObjectOfType<SudokuField>();
            Debug.Log("temp|:" + temp.GetInstanceID());
            //SudokuField temp = obj.GetComponent<SudokuField>();
            sudokuBoard[temp.y-1,temp.x-1] = temp;//TU COŚ NIE PYKA
            Debug.Log("sudokuBoard[temp.y][temp.x]|:" + sudokuBoard.GetType());
        }        
        //TODO odpal generowanie sudoku w zależności od poziomu
        ColorUtility.TryParseHtmlString("FF7575FF", out pressed);
    }
	
	public void SetButtonNumber(int a)
    {
        Debug.Log("yButtom-xButton:" + (yButtom ) +":"+ (xButton ));
        sudokuBoard[yButtom-1,xButton-1].SetText(a.ToString());
        sudokuBoard[yButtom-1,xButton-1].sudokuValue = a;
    }

    public void SetClicked(SudokuField sudokuField)
    {
        ColorBlock cb;
        //kiepawo unity kiepawo, 3 linie na głupią zmianę kloloru
        if (!clickedFieldButton.Equals(null) && !colorBackup.Equals(null))
        {           
           cb= clickedFieldButton.colors;
            cb.normalColor = colorBackup;
            clickedFieldButton.colors = cb;           
        }

        xButton = sudokuField.x;
        yButtom = sudokuField.y;
        clickedFieldButton = sudokuField.button;
        colorBackup = clickedFieldButton.colors.normalColor;

        cb = clickedFieldButton.colors;
        cb.normalColor = pressed;
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
