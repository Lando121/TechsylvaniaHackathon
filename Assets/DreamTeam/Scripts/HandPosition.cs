using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Leap;

public class HandPosition : MonoBehaviour {

	private HandController handController;
	private Frame frame;
	private Frame snapFrame;
	private HandList hands;
	private Hand leftHand;
	private Hand rightHand;
	private Timer timer;
	private const float TriggerTime = 1f; 
	private const float distLimit = 15f;
	private bool triggered = false;

	// Use this for initialization
	void Start () {
		handController = gameObject.GetComponent<HandController> ();
		timer = new Timer ();


	}
		
	
	// Update is called once per frame
	void Update () {

		if (!triggered) {
			frame = handController.GetFrame ();
			leftHand = frame.Hands.Leftmost;
			if (snapFrame != null) {
				this.GetComponent<Snapshot> ().snapshotButton.gameObject.SetActive(false);
				if (!timer.isCounting) {
					timer.StartCounting (TriggerTime);
				}
				float avgDistance = CalcAvgDistToSnapshot (snapFrame);
				if (avgDistance < distLimit) {
					timer.Tick (Time.deltaTime);
				} else {
					timer.Reset ();
				}
				if (timer.IsDone ()) {
					SignTriggered ();
				}

			}
		}


	}

	public void UnTrigger(){
		triggered = false;
	}

	public void setSnapshot (Frame snapshot){
		snapFrame = snapshot;
	}

	private float CalcAvgDistToSnapshot(Frame snapshot)
	{
		Hand snapLeftHand = snapshot.Hands.Leftmost;
		//rightHand = frame.Hands.Rightmost;
		float distance = 0f;
	
		FingerList fingers = leftHand.Fingers;
		foreach (Finger finger in fingers) {
			Finger snapFinger = snapshot.Finger (finger.Id);
			Bone bone;
			Bone snapBone;
			foreach (Bone.BoneType boneType in (Bone.BoneType[]) Enum.GetValues(typeof(Bone.BoneType))) {
				bone = finger.Bone (boneType);
				snapBone = snapFinger.Bone (boneType);
				distance += Mathf.Abs (bone.Center.DistanceTo (leftHand.PalmPosition) - snapBone.Center.DistanceTo (snapLeftHand.PalmPosition));

			}
		}
		Debug.Log (distance / fingers.Count);
		return (distance / fingers.Count) - 325;
			//Debug.Log (distance / fingers.Count);
			//Debug.Log (frame.Finger (snapFrame.Fingers [0].Id).TipPosition);
	}



	private void SignTriggered(){
		triggered = true;
		System.Diagnostics.Process.Start("http://google.com");
	}
}
