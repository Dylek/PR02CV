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
    public bool Generated
    {
        set{generated = value;}
        get { return generated;}
    }
    
    public SudokuField(int x2,int y2,int val2,bool gen)
    {
        x = x2;
        y = y2;
        sudokuValue = val2;
        generated = gen;
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


    public JSONObject toJSON()
    {
        return new JSONObject("{\"x\":\"" + x+ "\",\"y\":\"" + y+ "\",\"value\":" + sudokuValue+ ",\"generated\":\"" + generated+ "\"}");
    }
}
