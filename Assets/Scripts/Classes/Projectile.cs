using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public float m_fDamage;
	public float m_fDamagePeriod;
	float DamageTimer;
	public bool DestroyOnContact;
	GameObject m_oCreator;

	public Projectile(float a_fDamage, float a_fDamagePeriod, bool a_bDestroyOnContact, GameObject a_oCreator)
	{
		m_fDamage = a_fDamage;
		m_fDamagePeriod = a_fDamagePeriod;
		DestroyOnContact = a_bDestroyOnContact;
		m_oCreator = a_oCreator;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player" && other.gameObject != m_oCreator) //Will need to introduce a way to ensure it doesn't collide with its creator
		{
			print ("Player has collided with Trigger");
			// other.GetComponent<Player>().BalloonScript.AlterHealth(m_fDamage); //Must change value!!!!!
			if(DestroyOnContact)
			{
				// Destroy(gameObject);

			}
		}
	}
}
