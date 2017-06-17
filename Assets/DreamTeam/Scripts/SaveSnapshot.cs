using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Leap;

public class SaveSnapshot : MonoBehaviour {

	protected byte[] frame_;
	protected float frame_index_;
	protected Frame current_frame_ = new Frame();
	//private string path = "snapshotframes.txt";
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddSnapshot(Frame snapshot){
		frame_ = snapshot.Serialize;
		SaveToNewFile ();
	}

	private void SaveToNewFile() {
		//string path = Application.persistentDataPath + "/Recording_" +
		//	System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".bytes";


		//if (File.Exists(@path)) {
		//	File.Delete(@path);
		//}


		System.IO.File.WriteAllBytes (Application.persistentDataPath + "/frame1.txt", frame_);
		//FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);

		//byte[] frame_size = new byte[4];
		//frame_size = System.BitConverter.GetBytes(frame_.Length);
		//stream.Write(frame_size, 0, frame_size.Length);
		//stream.Write(frame_, 0, frame_.Length);
		//stream.Close();
		//return path;
	}
}
