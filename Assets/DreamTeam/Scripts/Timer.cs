using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer {
	public float duration { get; private set; }
	public float lengthLimit { get; private set; }
	public bool isCounting { get; private set; }



	public Timer() {
	}

	public void StartCounting(float lengthLimit) {
		duration = 0f;
		this.lengthLimit = lengthLimit;
		isCounting = true;
	}

	public void Tick(float tick) {
		duration += tick;
	}

	public bool IsDone() {
		return duration >= lengthLimit;
	}

	public void Reset() {
		duration = 0f;
		isCounting = false;
	}
}