using UnityEngine;
using System.Collections;

public class OpenOptions : MonoBehaviour {

    // Use this for initialization
    public GameObject ImageCaller;
    public Canvas canvasOptionsPref;


    // Update is called once per frame
    public void Open () {
	    Canvas canvasOptions = Instantiate(canvasOptionsPref) as Canvas;
	}
}
