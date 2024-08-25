using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Collider2D[] PlayerViewZone;
    private Animator playerAni;

    private void Start()
    {
        playerAni = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        PlayerViewZone = Physics2D.OverlapCircleAll(transform.position, 15f);

        EnemyCheck(PlayerViewZone); //���� �þ߿� �ִ��� Ȯ��

    }

    private bool EnemyCheck(Collider2D[] Colliders)
    {
        foreach (var collider in Colliders)
        {
            if (collider.transform.gameObject.tag == "Enemy")
            {
                playerAni.SetBool("EnemyCheck", true);
                Debug.Log("�� Ȯ��");
                return true;
            }
        }
        playerAni.SetBool("EnemyCheck", false);
        return false;
    }

    private void FireArrow()
    {
        Debug.Log("ȭ�� �߻�");
        var ArrowGo = ObjectPoolManager.instance.Pool.Get();

        ArrowGo.transform.position = transform.position + new Vector3(0.7f, 4.95f, 0);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 15f);
    }
}
