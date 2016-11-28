using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

[Serializable]
public class SudokuField : MonoBehaviour {
    public int x;
    public int y;
    private int sudokuValue=0;
    public Button button;
    public int SudokuValue {
        get { return sudokuValue; }
        set {
            sudokuValue = value;
            
            text.text = value==0?"": "" + sudokuValue;
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
	void Awake () {
       text=gameObject.GetComponentInChildren<Text>();
       // text=gameObject.
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void SetText(string str)
    {
        text.text = str;
    }
}
