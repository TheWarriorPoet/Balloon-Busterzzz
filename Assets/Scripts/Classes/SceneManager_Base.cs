using UnityEngine;
using System.Collections;

public class SceneManager_Base : MonoBehaviour {


    protected GameManager _myGameManager;

	// Use this for initialization
	void Awake () {
        _myGameManager = GameManager.instance;
	}
}
