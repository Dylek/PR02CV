using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class SudokuField : MonoBehaviour {
    public int x;
    public int y;
    public int sudokuValue=0;
    public Button button;
    public int SudokuValue {
        get { return sudokuValue; }
        set {
            sudokuValue = value;
            text.text = "" + sudokuValue;
        }
    }
    private Text text;
    private bool generated=false;
    private bool Generated
    {
        set{generated = value;}
        get { return generated;}
    }
    

	// Use this for initialization
	void Start () {
        text=(Text)gameObject.GetComponentInChildren(typeof(Text));
	}
	
	// Update is called once per frame
	void Update () {
        
	}

}
