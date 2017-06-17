using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;

public class Snapshot : MonoBehaviour {

	public Button snapshotButton;
	public Button saveButton;
	private HandController handController;
	public Frame snapFrame;

	void Start()
	{
		Button btn = snapshotButton.GetComponent<Button>();
		handController = this.GetComponent<HandController> ();
		btn.onClick.AddListener(TakeSnapshot);

		Button saveBtn = saveButton.GetComponent<Button> ();
		saveBtn.onClick.AddListener (SaveSnaps);
	}

	void SaveSnaps(){
		
		SaveSnapshot saveSnap = this.GetComponent<SaveSnapshot> ();
		saveSnap.SaveToNewFile ();
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
