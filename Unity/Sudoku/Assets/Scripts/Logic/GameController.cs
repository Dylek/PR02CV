using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public static GameController instance = null;
    private Button clickedFieldButton;
    private int xButton;
    private int yButtom;
    private Color pressed = new Color();    
    private Color colorBackup;


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
        //TODO powsadzaj je w odpowiednie miejsca
        //TODO odpal generowanie sudoku w zależności od poziomu
        ColorUtility.TryParseHtmlString("FF7575FF", out pressed);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ButtonClicked(int x)
    {
        Debug.Log("Button"+x);
    }
    public void DoSmoething(int a)
    {

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

    }
    public void CheckGameRules()
    {

    }


    
}
