using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private GameObject Enemy;
    public int Stage = 1;
    public GameObject EnemySpawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EnemySpawn();
    }

    public void EnemySpawn()
    {
        List<Dictionary<string, object>> Monster = CSVReader.Read("SampleMonster");

        Enemy = Resources.Load<GameObject>("Prefabs/"+ Monster[Stage-1]["Name"]);
        Instantiate(Enemy, EnemySpawnPoint.transform);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0.0f;
    }
}
