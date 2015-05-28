﻿using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float m_fDamage;
	public float m_fDamagePeriod;
	public int BounceCap;
	int BounceCount;
	float DamageTimer;
	public bool DestroyOnContact;
	public float m_oCreator;
	public Projectile(float a_fDamage, float a_fDamagePeriod, bool a_bDestroyOnContact)
	{
		m_fDamage = a_fDamage;
		m_fDamagePeriod = a_fDamagePeriod;
		DestroyOnContact = a_bDestroyOnContact;
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (BounceCount >= BounceCap) {
			Destroy(gameObject.transform.parent.gameObject);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		BounceCount += 1;
		//print ("Player has collided with Trigger");
		if (other.tag == "Player" && other.gameObject.GetComponent<PlayerController>().playerID != m_oCreator)
		{
			print ("Player has collided with Trigger");
			other.gameObject.GetComponent<Balloon>().AlterHealth(m_fDamage);
			if(DestroyOnContact)
			{
				Destroy(gameObject.transform.parent.gameObject);

			}
		}
	}
}
