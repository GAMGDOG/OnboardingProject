using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    #region Singleton
    private static GameManager _instance;
    public static GameManager Instance
    { 
        get
        {
            if(!_instance)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
                Init();
            }
            return _instance;
        }
    }

    protected static void Init()
    {
        if(!_instance)
        {
            GameObject gameObject = new GameObject { name = "@GameManager" };
            if(gameObject.GetComponent<GameManager>() == null)
            {
                _instance = gameObject.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion
    #region Fields

    private ObjectPoolManager _pool = new();

    public ObjectPoolManager Pool
    {
        get { return Instance._pool; }
        set { Instance._pool = value; }
    }
    #endregion
}
