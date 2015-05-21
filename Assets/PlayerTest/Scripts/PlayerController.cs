using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float CharacterSpeed = 470.0f;
	public Animator CharacterAnimator;
	public float JumpForce = 10f;
	public float TerminalVelocity = -50f;
	public float Gravity = 9.8f;



	private Rigidbody2D myRigidBody;
	private CharacterController characterController;
	private Vector2 velocity = new Vector2(0f,0f);
	private bool isLeft = true;
	private bool running = false;
	public int playerID = 0;
	private bool jumping = false;


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

	// Update is called once per frame
	void Update () {
		velocity.x = 0;
		running = false;
		jumping = (characterController.collisionFlags == CollisionFlags.None);

		switch (playerID) {
		case 0:
			if (Input.GetAxis ("HorizontalP1") > 0) {
				MoveLeft ();
			}
			if (Input.GetAxis ("HorizontalP1") < 0) {
				MoveRight ();
			}
			if(Input.GetAxis("JumpP1") >0  && !jumping)
			{
				velocity.y =+ JumpForce;
				jumping = true;
			}

			if(Input.GetButtonDown("Fire1P1"))
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
		
			break;
		case 1:
			if (Input.GetAxis ("HorizontalP2") > 0) {
				MoveLeft ();
			}
			if (Input.GetAxis ("HorizontalP2") < 0) {
				MoveRight ();
			}
			if(Input.GetAxis("JumpP2") >0  && !jumping)
			{
				velocity.y =+ JumpForce;
				jumping = true;
			}
			if(Input.GetButtonDown("Fire1P2"))
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
			break;
		}

		velocity.y -= Gravity*Time.deltaTime;
		if (velocity.y < TerminalVelocity) {
			velocity.y = TerminalVelocity;
		}

		characterController.Move(new Vector2(velocity.x * Time.deltaTime,velocity.y*Time.deltaTime));
	




		CharacterAnimator.SetBool("running",running);


	}



}
