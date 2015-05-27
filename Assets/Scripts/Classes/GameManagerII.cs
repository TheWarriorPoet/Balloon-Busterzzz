using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class GameManagerII : MonoBehaviour {
	
	public Text startText;
	public Text timerText;

	private float countDown = 90f;
	private float timeElapsed = 90f;
	private float blinkTime = 0f;
	private bool blink;
	private bool gameStarted;
	private TimeManager timeManager;
	private Spawner spawner;

	
	void Awake(){
		spawner = GameObject.Find ("Spawner").GetComponent<Spawner> ();
		timeManager = GetComponent<TimeManager> ();
	}
	
	// Use this for initialization
	void Start () {
		
		spawner.active = false;
		Time.timeScale = 0;
		startText.text = "PRESS ANY BUTTON TO START";
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && Time.timeScale == 0) {
			
			if(Input.anyKeyDown){
				
				timeManager.ManipulateTime(1, 1f);
				ResetGame();
			}
		}
		
		if (!gameStarted) {
			blinkTime ++;
			
			if (blinkTime % 40 == 0) {
				blink = !blink;
			}
			
			startText.canvasRenderer.SetAlpha (blink ? 0 : 1);

			timerText.text = "TIME: " + FormatTime (timeElapsed);
		} else {
			countDown -= Time.deltaTime;
			timerText.text = "TIME: " + FormatTime(countDown);

			if(countDown <= 0) {
				TimeOver();
			}
		}
	}
	
	void TimeOver(){

		spawner.active = false;

		timeManager.ManipulateTime (0, 5.5f);
		gameStarted = false;
		
		startText.text = "PRESS ANY BUTTON TO RESTART";

	}
	
	void ResetGame(){

		spawner.active = true;
		gameStarted = true;
		startText.canvasRenderer.SetAlpha(0);
		timeElapsed = 0;

	}
	
	string FormatTime(float value){
		TimeSpan t = TimeSpan.FromSeconds (value);
		
		return string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
	}
	
}
