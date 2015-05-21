using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float CharacterSpeed = 470.0f;
	public Animator CharacterAnimator;


	private Rigidbody2D myRigidBody;
	private CharacterController characterController;
	private Vector2 velocity = new Vector2(0f,0f);
	private bool isLeft = true;
	private bool running = false;
	public int playerID = 0;


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

		switch (playerID) {
		case 0:
			if (Input.GetKey (KeyCode.D)) {
				MoveLeft();
			}

			if (Input.GetKey (KeyCode.A)) {
				MoveRight();
			}
			break;
		case 1:
			if (Input.GetKey (KeyCode.RightArrow)) {
				MoveLeft();
			}
			
			if (Input.GetKey (KeyCode.LeftArrow)) {
				MoveRight();
			}
			break;
		}

		characterController.SimpleMove (velocity);
	




		CharacterAnimator.SetBool("running",running);


	}
}
