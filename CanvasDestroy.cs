using UnityEngine;
using System.Collections;

public class CanvasDestroy : MonoBehaviour {
	
	// Update is called once per frame
	public void Destroy () {
        Destroy(this.gameObject);
	}
}
