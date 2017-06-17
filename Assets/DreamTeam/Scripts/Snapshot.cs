using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;

public class Snapshot : MonoBehaviour {

	public Button snapshotButton;
	private HandController handController;
	public Frame snapFrame;

	void Start()
	{
		Button btn = snapshotButton.GetComponent<Button>();
		handController = this.GetComponent<HandController> ();
		btn.onClick.AddListener(TakeSnapshot);
	}

	void TakeSnapshot()
	{
		snapFrame = handController.GetFrame ();
		this.GetComponent<SaveSnapshot> ().AddSnapshot(snapFrame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
