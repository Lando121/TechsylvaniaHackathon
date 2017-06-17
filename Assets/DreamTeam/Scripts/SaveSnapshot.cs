using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using Leap;

public class SaveSnapshot : MonoBehaviour {

	public TextAsset frameFile;
	protected List<byte[]> frameList = new List<byte[]>();
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
		this.GetComponent<HandPosition> ().ids.Add (snapshot.Id);
		frameList.Add(snapshot.Serialize);
		//SaveToNewFile ();
	}
	

	public void SaveToNewFile() {
		//string path = Application.persistentDataPath + "/Recording_" +
		//	System.DateTime.Now.ToString("yyyyMMdd_hhmmss") + ".bytes";
		string path = Application.persistentDataPath + "/frame1.txt";

		if (File.Exists(@path)) {
			File.Delete(@path);
		}

		FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);
		for (int i = 0; i < frameList.Count; ++i) {
			byte[] frame_size = new byte[4];
			frame_size = System.BitConverter.GetBytes(frameList[i].Length);
			stream.Write(frame_size, 0, frame_size.Length);
			stream.Write(frameList[i], 0, frameList[i].Length);
		}

		stream.Close();
		return;     //STOP


		//if (File.Exists(@path)) {
		//	File.Delete(@path);
		//}

		//byte[] bytes = File.ReadAllBytes (path);
		//Frame reconstructedFrame = new Frame ();
		//reconstructedFrame.Deserialize (bytes);

		//System.IO.File.WriteAllBytes (Application.persistentDataPath + "/frame1.txt", frame_);
		//FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write);


	}
}
