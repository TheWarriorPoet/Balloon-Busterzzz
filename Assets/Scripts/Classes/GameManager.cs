using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


    // Singleton Instance to provide simple access through other scripts
    private static GameManager _instance = null;
    public static GameManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = (GameManager)FindObjectOfType(typeof(GameManager));
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
