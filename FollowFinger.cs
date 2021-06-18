using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowFinger : MonoBehaviour {

    public int offsetShowColor = 70;

    private GameObject Master;
    private Image img;

    // Use this for initialization
    void Start () {
	    Master = GameObject.Find("Master");
        img = this.GetComponent<Image>();
        img.enabled = false;
    }
	

    public void StartToFollow()
    {
        img.enabled = true;
        Vector2 pos = Input.mousePosition;
        int x = Master.GetComponent<Main>().mouseX;
        int y = Master.GetComponent<Main>().mouseY;
        this.gameObject.transform.position = new Vector3(x, y + offsetShowColor, 0f);
        img.color = Master.GetComponent<Main>().color;
    }
}
