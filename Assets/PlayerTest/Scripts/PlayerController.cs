using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float CharacterSpeed = 470.0f;
	public float JumpForce = 100.0f;
	public float FlightForce = 100.0f;
	public Animator CharacterAnimator;


	private Rigidbody2D myRigidBody;
	private CharacterController characterController;
	private Vector3 velocity = new Vector3();
	private bool isLeft = true;
	private bool running = false;
	public int playerID = 0;
	public bool CanFly = true;
	public float gravity;


	void Start () {
		characterController = this.GetComponent<CharacterController> ();
	
	}

	void MoveLeft()
	{
		velocity.x = CharacterSpeed * Time.deltaTime;
		if (isLeft) {
			transform.Rotate (new Vector3 (0f, 180f, 0f));
			isLeft = false;
			
		}
		running = true;
	}

	void MoveRight()
	{
		velocity.x = CharacterSpeed * Time.deltaTime * -1;
		if (!isLeft) {
			transform.Rotate (new Vector3 (0f, 180f, 0f));
			isLeft = true;
		}
		running = true;
	}

	void Jump()
	{
		if (!CanFly && myRigidBody.velocity.y == 0)
		{
			velocity.y = JumpForce * Time.deltaTime;
		}
		else if (CanFly)
		{
			velocity.y = FlightForce * Time.deltaTime;
		}
	}

	void Fire1()
	{
		if(isLeft)
		{
			Vector2 tempPos = gameObject.transform.position;
			tempPos.x -= 1;
			GameObject tempObj = (GameObject)Instantiate(GetComponent<Balloon>().Power.Primary, tempPos, gameObject.transform.rotation);
			tempObj.transform.GetChild (0).GetComponent<Projectile>().m_oCreator = playerID;
			Vector2 tempVec = characterController.velocity;
			tempVec.x += -1000;
			tempObj.GetComponent<Rigidbody2D>().AddForce(tempVec);
		}else{
			GameObject tempObj = (GameObject)Instantiate(GetComponent<Balloon>().Power.Primary, gameObject.transform.position , gameObject.transform.rotation);
			tempObj.transform.GetChild (0).GetComponent<Projectile>().m_oCreator = playerID;
			Vector2 tempVec = characterController.velocity;
			tempVec.x += 1000;
			tempObj.GetComponent<Rigidbody2D>().AddForce(tempVec);
		}
	}

	// Update is called once per frame
	void Update () {
		velocity = new Vector3();
		velocity.y -= gravity;
		velocity.TransformDirection (velocity);
		running = false;

		switch (playerID) {
		case 0:
			if (Input.GetAxis ("HorizontalP1") > 0) {
				MoveLeft ();
			}
			if (Input.GetAxis ("HorizontalP1") < 0) {
				MoveRight ();
			}
			if (Input.GetButtonDown("JumpP1") && myRigidBody != null)
			{
				Jump();
			}
			if(Input.GetButtonDown("Fire1P1"))
			{
				Fire1();
			}
			break;
		case 1:
			if (Input.GetAxis ("HorizontalP2") > 0) {
				MoveLeft ();
			}
			if (Input.GetAxis ("HorizontalP2") < 0) {
				MoveRight ();
			}
			if (Input.GetButtonDown("JumpP2") && myRigidBody != null)
			{
				Jump();
			}
			if(Input.GetButtonDown("Fire1P2"))
			{
				Fire1();
			}
			break;
		}

		//characterController.SimpleMove (velocity);
		characterController.Move(velocity);
		
		CharacterAnimator.SetBool("running",running);
	}
}
