using UnityEngine;

public class Enemy_ReSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] respawnPoints;
    [SerializeField] private float cooldown = 2f;
    [Space]
    [SerializeField] private float cooldownDecreaseRate = .05f;
    [SerializeField] private float cooldownCap = .7f;
    private float timer;
    private Transform warrior;

    private void Awake()
    {
        warrior = FindFirstObjectByType<Player>().transform;
    }

    private void Update()
    {
        if(warrior==null)
            return;

        timer -= Time.deltaTime;

        if (timer < 0)
        {
            timer = cooldown;
            CreateNewEnemy();
            cooldown = Mathf.Max(cooldownCap, cooldown - cooldownDecreaseRate);
        }
    }
    private void CreateNewEnemy()
    {
        if(warrior==null)
            return;

        int respawnPointIndex = Random.Range(0, respawnPoints.Length);
        Vector3 spawnPoint = respawnPoints[respawnPointIndex].position;
        spawnPoint.z = 0;

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        bool createdOnTheRight = newEnemy.transform.position.x > warrior.transform.position.x;

        if (createdOnTheRight)
            newEnemy.GetComponent<Enemy>().flip();
    }
}