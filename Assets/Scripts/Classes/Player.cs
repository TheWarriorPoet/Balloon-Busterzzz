using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public GameObject PlayerBalloon = null;
    public Balloon BalloonScript = null;

    public float Speed = 10.0f;
    public float JumpForce = 100.0f;

    private GameManager _myGameManager = null;
    private Rigidbody2D _myRigidBody2D = null;
    private Transform _myTransform = null;
    private Vector2 position = Vector2.zero;

	// Use this for initialization
	void Awake () {
        _myGameManager = GameManager.instance;
        _myRigidBody2D = GetComponent<Rigidbody2D>();
        _myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump") && _myRigidBody2D.velocity.y == 0)
        {
            if (_myRigidBody2D != null) { _myRigidBody2D.AddRelativeForce(new Vector2(0.0f, JumpForce)); } else Debug.Log("_myRigidBody2D is null");
        }
		if(Input.GetButtonDown("Fire1"))
		{
			GameObject tempObj = (GameObject)Instantiate(BalloonScript.Power.Primary,gameObject.transform.position , gameObject.transform.rotation);
		}
        float translation = Input.GetAxis("Horizontal") * Speed;
        translation *= Time.deltaTime;
        _myTransform.Translate(translation, 0, 0);
	}
}
