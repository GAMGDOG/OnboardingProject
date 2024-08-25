using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject EnemyInfoUI;
    private GameObject StageUI;

    private string _name;
    private string _grade;
    private float _speed;
    private int _health;

    private bool _isLive;

    private Animator _ani;
    private Collider2D _collider;

    private void Start()
    {
        List<Dictionary<string, object>> Monster = CSVReader.Read("SampleMonster");

        _name = (string)Monster[GameManager.Instance.Stage - 1]["Name"];
        _grade = (string)Monster[GameManager.Instance.Stage - 1]["Grade"];
        _speed = (float)Monster[GameManager.Instance.Stage - 1]["Speed"];
        _health = (int)Monster[GameManager.Instance.Stage - 1]["Health"];
        _isLive = true;

        _ani = GetComponent<Animator>();
        _collider = GetComponent<Collider2D>();

        EnemyInfoUI = GameObject.Find("Canvas").transform.GetChild(1).transform.gameObject;
        StageUI = GameObject.Find("Canvas").transform.GetChild(0).transform.gameObject;
        StageUI.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = GameManager.Instance.Stage.ToString();
    }

    private void FixedUpdate()
    {
        transform.position += Vector3.left * _speed * Time.deltaTime;

        if(transform.position.x <= -6)
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Arrow") || !_isLive) return;
        if(other.CompareTag("Arrow"))
        { 
            _health -= 100;
        }

        if(_health <= 0)
        {
            _isLive = false;
            _health = 0;
            _speed = 0;
            _ani.SetBool("GetDead", true);
            GameManager.Instance.Stage++;
            GameManager.Instance.EnemySpawn();
            Invoke("EnemyDead", 1f);
        }
    }

    private void OnMouseDown()
    {
        EnemyInfoUI.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _name;
        EnemyInfoUI.transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _grade;
        EnemyInfoUI.transform.GetChild(2).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _speed.ToString();
        EnemyInfoUI.transform.GetChild(3).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = _health.ToString();

        EnemyInfoUI.SetActive(true);
    }

    private void EnemyDead()
    {
        if (GameManager.Instance.Stage > 5)
        {
            Debug.Log("Game Clear");
            Time.timeScale = 0.0f;
        }
        Destroy(gameObject);
    }
}
