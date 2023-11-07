using UnityEngine;
using System.Collections.Generic;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject zombie = null;

    [SerializeField]
    List<GameObject> spawnPoints = null;

    [HideInInspector]
    public List<ZombieController> zombieControllers = null;

    public void SpawnZombie()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Count);
        GameObject enemy = Instantiate(zombie, spawnPoints[spawnIndex].transform);
        enemy.transform.localPosition = new Vector3(0, 0, 0);
        zombieControllers.Add(enemy.GetComponent<ZombieController>());
        zombieControllers[zombieControllers.Count - 1].spawnNewZombie = SpawnZombie; 
    }
}
