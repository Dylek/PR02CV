using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    public static GameController instance = null;
    private Button clickedFieldButton;
    private int xButton;
    private int yButtom;
    //Robimy singleton
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start () {
	
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

    public void setClicked(int x,int y, Button b)
    {
        xButton = x;
        yButtom = y;
        clickedFieldButton = b;
    }
}
