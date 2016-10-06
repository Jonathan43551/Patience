using UnityEngine;
using System.Collections;

public class exitButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
        //docs.unity3d.com/ScriptReference/Application.Quit.html
    }

    public void quitPatience()
    {
        Application.Quit();
    }
    
}
