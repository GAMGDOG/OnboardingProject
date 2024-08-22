using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D[] PlayerViewZone;
    private Vector3 EnemyPosition;

    private void Start()
    {
        EnemyPosition = transform.position;
    }
    private void FixedUpdate()
    {
        PlayerViewZone = Physics2D.OverlapCircleAll(transform.position, 15f);

        if(EnemyCheck(PlayerViewZone)) //���� �þ߿� �ִ��� Ȯ��
        {
            FireArrow(EnemyPosition); //���� ����
        }
    }

    private bool EnemyCheck(Collider2D[] Colliders)
    {
        foreach (var collider in Colliders)
        {
            if (collider.transform.gameObject.tag == "Enemy")
            {
                EnemyPosition = collider.transform.position;
                return true;
            }
        }
        return false;
    }

    private void FireArrow(Vector3 EnmeyPosition)
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
}
