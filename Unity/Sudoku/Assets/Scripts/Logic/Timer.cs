using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timer;
    private float timeFromStart=0;
    public float TimeFromStart
    {
        get { return timeFromStart; }
        set { timeFromStart = value; }
    }
	// Use this for initialization
	
	
	// Update is called once per frame
	void FixedUpdate () {
        timeFromStart += Time.fixedDeltaTime;
        timer.text ="Time: "+((int) timeFromStart).ToString();
    }
}
