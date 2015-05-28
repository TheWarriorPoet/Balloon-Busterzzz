using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public GameObject[] prefabs;


	public float delay = 5.0f;
	public bool active = true;
	public Vector2 delayRange = new Vector2(15, 25);
	
	// Use this for initialization
	void Start () {
		ResetDelay ();
		StartCoroutine (BalloonGenerator ());
	}
	
	IEnumerator BalloonGenerator(){
		
		yield return new WaitForSeconds (delay);
		
		if (active) {
			var newTransform = transform;
			GameObject BalloonObj =(GameObject)Resources.Load("BalloonObj");
			GameObjectUtil.Instantiate(BalloonObj, newTransform.position);
			ResetDelay();
		}
		
		StartCoroutine (BalloonGenerator ());
		
	}
	
	void ResetDelay(){
		delay = Random.Range (delayRange.x, delayRange.y);
	}
	
}
