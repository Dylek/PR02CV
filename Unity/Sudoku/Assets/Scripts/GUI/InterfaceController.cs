using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class InterfaceController : MonoBehaviour {

    public Text text;
    private GameController gameContoller;
    // Use this for initialization
    void Start() {
        gameContoller = GameController.instance;
    }

    // Update is called once per frame
    void Update() {

    }

    public void ButtonClicked(int xy)
    {
        text.text = "You Clicekd " + xy / 10 + "  " + xy % 10+"\n Value";
    }
    public void ButtonClicked2(Button but)
    {
        

    }

    public void NumberClicked(int a)
    {
        gameContoller.SetButtonNumber(a);
    }

    public void SudokuFieldCliecked(SudokuField su)
    {
        text.text = "You Clicekd [X,Y]: [" + su.x + "," + su.y + "]\n Value: "+su.sudokuValue+"\n Button:"+ su.button.ToString();
        Debug.Log("Sudoku Fields:"+su.GetType());
        GameController.instance.SetClicked(su);
    }

    public void ClearFieldButt(SudokuField suF)
    {
        gameContoller.ClearField(suF);
    }
    public void CheckGameRulesButt()
    {
        gameContoller.CheckGameRules();
    }

}
