using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEngine;
using UnityEngine.UI;
using System;
public class TimeManager : MonoBehaviour
{
	
	public class OnTickEventArgs : EventArgs {
		public int tick;
	}

	public static event EventHandler<OnTickEventArgs> OnTick;
	
	public float BaseTickTime { get; } = 1;
	public float GameSpeed;// { get; set; } = 1;
	float currentTick;
	int tickCounter;

	private void Start()
	{
		currentTick = 0;
		tickCounter = 0;
	}





	private void Update()
	{

		currentTick += Time.deltaTime * GameSpeed;

		if (currentTick > BaseTickTime)
		{
			currentTick -= BaseTickTime;
			tickCounter++;
			if (OnTick != null) {
				OnTick(this, new OnTickEventArgs { tick = tickCounter });
			}
		}

	}


	public void PauseUnpause() {
		if (GameSpeed != 0)
			GameSpeed = 0;
		else
			GameSpeed = 0;
	}
	
}
