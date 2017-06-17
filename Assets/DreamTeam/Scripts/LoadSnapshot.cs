using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Leap;
using System.Collections.Generic;

public class LoadSnapshot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string path = Application.persistentDataPath + "/frame1.txt";
		byte[] data = File.ReadAllBytes (path);
		//Debug.Log (testBytes.Length);
		List<byte[]> frameList = new List<byte[]>();

		//byte[] data = textFile.bytes;
		float frame_index_ = 0;

		int i = 0;
		while (i < data.Length) {
			byte[] frame_size = new byte[4];
			Array.Copy(data, i, frame_size, 0, frame_size.Length);
			i += frame_size.Length;
			byte[] frame = new byte[System.BitConverter.ToUInt32(frame_size, 0)];
			Array.Copy(data, i, frame, 0, frame.Length);
			i += frame.Length;
			frameList.Add(frame);
		}
		this.GetComponent<HandPosition> ().setFrameList (frameList);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
