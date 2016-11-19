using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class SudokuField : MonoBehaviour {
    public int sudokuValue=0;
    public int SudokuValue
    {
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
    public int x;
    public int y;

	// Use this for initialization
	void Start () {
        text=(Text)gameObject.GetComponentInChildren(typeof(Text));
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
