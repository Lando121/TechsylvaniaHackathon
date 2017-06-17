using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {
	public HandController controller; 
	public Canvas canvas; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void startButton() {
		Debug.Log ("Den triggas");
		controller.GetComponent<HandPosition> ().activate();
		canvas.gameObject.SetActive (false);
	}
}
