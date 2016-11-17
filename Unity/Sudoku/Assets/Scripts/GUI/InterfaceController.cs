using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class InterfaceController : MonoBehaviour {

    public Text text;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void ButtonClicked(int xy)
    {
        text.text = "You Clicekd " + xy / 10 + "  " + xy % 10;
    }
    public void ButtonClicked2(Button but)
    {
        

    }
}
