using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Leap;

public class LoadSnapshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = Application.persistentDataPath + "/frame1.txt";
		byte[] bytes = File.ReadAllBytes (path);
		Frame reconstructedFrame = new Frame ();
		reconstructedFrame.Deserialize (bytes);
		this.GetComponent<HandPosition> ().setSnapshot(reconstructedFrame);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
