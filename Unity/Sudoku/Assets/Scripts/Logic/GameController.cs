using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


    public static GameController instance = null;

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


}
