using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float CharacterSpeed = 470.0f;
	public Animator CharacterAnimator;


	private Rigidbody myRigidBody;
	private CharacterController characterController;
	private Vector2 velocity = new Vector2(0f,0f);
	private bool isLeft = true;
	private bool running = false;


	void Start () {
		characterController = this.GetComponent<CharacterController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		velocity.x = 0;
		running = false;

		if (Input.GetKey(KeyCode.D))
		{
			velocity.x = CharacterSpeed * Time.deltaTime;
			if (isLeft)
			{
				transform.Rotate(new Vector3(0f,180f,0f));
				isLeft = false;
				
			}
			running = true;
		}

		if (Input.GetKey(KeyCode.A))
		{
			velocity.x = CharacterSpeed * Time.deltaTime * -1;
			if (!isLeft)
			{
				transform.Rotate(new Vector3(0f,180f,0f));
				isLeft = true;				       
			}
			running = true;
		}

		characterController.SimpleMove (velocity);
	




		CharacterAnimator.SetBool("running",running);


	}
}
