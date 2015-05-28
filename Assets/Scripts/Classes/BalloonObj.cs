using UnityEngine;
using System.Collections;

public class BalloonObj : MonoBehaviour {

	BalloonPowers BalloonType;
	// Use this for initialization
	void Start () {

		//Add some RNG here, generate a number between 0 and num of Ballons, then change BalloonType to said balloon based on number generated
		//Maybe change the color of the balloon object based on which one it picks
		BalloonType = new RedBalloon ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "Player")
		{
			other.gameObject.GetComponent<Balloon>().Power = BalloonType;
			print ("Player Balloon has changed to " + BalloonType);
			GameObject.Destroy(gameObject);
		}
	}
}
