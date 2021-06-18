using UnityEngine;
using System.Collections;


public class ImgClicked : MonoBehaviour {

	public void Clicked ()
	{
	    GameObject.Find("Master").GetComponent<OpenOptions>().ImageCaller = this.gameObject;
	}
}
