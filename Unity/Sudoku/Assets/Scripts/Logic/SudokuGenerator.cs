using UnityEngine;
using System.Collections;

public enum DifficultLevel
{
    easy,
    medium,
    hard
}
public class SudokuGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //na podstawie poziomu trundości zwraca nam odpowiednio wygenerowaną planszę
    public static int[][] GenerateSudokuBoard(DifficultLevel diff) {
        int[][] board=new int[9][];



        return board;
    }
}
