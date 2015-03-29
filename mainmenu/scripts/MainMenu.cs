using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), backgroundTexture);
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 7f, Screen.width / 5f, Screen.height/ 15f), "Load Game")) 
		{
			Application.LoadLevel(1);
		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3f, Screen.width / 5f, Screen.height/ 10f), "exit Game")) 
		{
			Application.Quit();
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
