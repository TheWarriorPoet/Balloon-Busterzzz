using UnityEngine;
using System.Collections;

public class Balloon : MonoBehaviour {

	public float m_fHealth;
	public BalloonPowers Power;
	public GameObject gameObject;

	// Use this for initialization
	void Start () {
		Power = new RedBalloon();
	}
	
	// Update is called once per frame
	void Update () {
	if (m_fHealth <= 0) 
		{
			//Destroy This Balloon
		}
	}

	public void AlterHealth(float a_fAmount) //Will subtract by default, a negative value will increase health
	{
		m_fHealth -= a_fAmount;
	}
}
