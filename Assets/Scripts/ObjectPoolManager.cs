using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    private static ObjectPoolManager _instance;
    public static ObjectPoolManager instance
    {
        get
        {
            if(!_instance)
            {
                _instance = GameObject.FindObjectOfType<ObjectPoolManager>();
            }
            return _instance;
        }
    }

    public GameObject ArrowPrefab;

    public IObjectPool<GameObject> Pool { get; private set; }

    private void Awake()
    {
        Init();
    }

    protected void Init()
    {
        Pool = new ObjectPool<GameObject>(CreatePoolArrow, OnTakeFromPool, OnReturnToPool, OnDestroyPoolObject, true, 5, 10);

        for(int i = 0;i<5; i++)
        {
            Arrow arrow = CreatePoolArrow().GetComponent<Arrow>();
            arrow.Pool.Release(arrow.gameObject);
        }
    }

    private GameObject CreatePoolArrow()
    {
        GameObject pool = Instantiate(ArrowPrefab);
        Debug.Log("화살 생성");
        pool.GetComponent<Arrow>().Pool = Pool;
        return pool;
    }

    private void OnTakeFromPool(GameObject pool)
    {
        pool.SetActive(true);
    }

    private void OnReturnToPool(GameObject pool)
    {
        pool.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject pool)
    {
        Destroy(pool);
    }
}
