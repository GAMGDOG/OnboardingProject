using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Arrow : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    private float speed = 10f;

    private void Update()
    {
        if(transform.position.x > 10)
        {
            Pool.Release(gameObject);
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
