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
    private SudokuField[][] sudokuBoard;

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
        //TODO zbierz buttony
        GameObject[] buttons = GameObject.FindGameObjectsWithTag("button");
        //TODO powsadzaj je w odpowiednie miejsca
        foreach (GameObject obj in buttons)
        {
            SudokuField temp = GameObject.FindObjectOfType<SudokuField>();
            sudokuBoard[temp.y][temp.x] = temp;
        }        
        //TODO odpal generowanie sudoku w zależności od poziomu
        ColorUtility.TryParseHtmlString("FF7575FF", out pressed);
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
