using UnityEngine;
using System.Collections;

public class SceneManager_Base : MonoBehaviour {


    protected GameManager _myGameManager;

	// Use this for initialization
	void Start () {
        _myGameManager = GameManager.instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
