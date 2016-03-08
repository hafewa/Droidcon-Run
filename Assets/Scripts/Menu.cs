using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 30;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if(Application.loadedLevelName=="Menu"){
				Quit();
			}else if(Application.loadedLevelName=="Main"){
				GoMenu();
			}
		}
	}

	public void StartGame(){
		Application.LoadLevel ("Main");
	
	}
	public void GoMenu(){
		Application.LoadLevel ("Menu");
	}
	public void Quit(){
		Application.Quit ();
	}
}
