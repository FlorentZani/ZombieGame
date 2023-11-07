using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<ExplosiveBarrel> explosiveBarrels = null;

    [SerializeField]
    List<Gun> guns = null;

    [SerializeField]
    ZombieSpawner zombieSpawner = null;

    [SerializeField]
    UIController uiController = null;

    [SerializeField]
    WeaponsManager weaponsManager = null;

    [SerializeField]
    PlayerHealth playerHealth = null;

    [SerializeField]
    GameObject bloodSpatter;

    void Awake()
    {
        zombieSpawner.SpawnZombie();

        foreach (Gun gun in guns)
        {
            foreach(ExplosiveBarrel explosiveBarrel in explosiveBarrels)
            {
                gun.hitBarrel += explosiveBarrel.Explode;
            }

            foreach (ZombieController zombieController in zombieSpawner.zombieControllers)
            {
                gun.hitZombie = HandleHitZombie;
            }
        }

        foreach (ZombieController zombieController in zombieSpawner.zombieControllers)
        {
            zombieController.spawnNewZombie += HandleAddListenerForZombieDie;
            zombieController.HitPlayer = HandleZombieHitPlayer;
        }

        uiController.MenuOpen += weaponsManager.HandleMenuOpened;
        uiController.MenuClosed += weaponsManager.HandleMenuClosed;
    }

    void OnDestroy()
    {
        foreach (Gun gun in guns)
        {
            foreach (ExplosiveBarrel explosiveBarrel in explosiveBarrels)
            {
                gun.hitBarrel -= explosiveBarrel.Explode;
            }
        }

        uiController.MenuOpen -= weaponsManager.HandleMenuOpened;
        uiController.MenuClosed -= weaponsManager.HandleMenuClosed;
    }

    void HandleAddListenerForZombieDie()
    {
        foreach (ZombieController zombieController in zombieSpawner.zombieControllers)
        {
            foreach (Gun gun in guns)
            {
                gun.hitZombie = HandleHitZombie;
            }
        }

        foreach (ZombieController zombieController in zombieSpawner.zombieControllers)
        {
            zombieController.spawnNewZombie += HandleAddListenerForZombieDie;
            zombieController.HitPlayer = HandleZombieHitPlayer;
        }
    }

    void HandleZombieHitPlayer()
    {
        playerHealth.DecreaseHealth(0.1f);
        StartCoroutine(ShowBloodSpatter());
    }

    IEnumerator ShowBloodSpatter()
    {
        bloodSpatter.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        bloodSpatter.SetActive(false);
    }  

    void HandleHitZombie(string name)
    {
        for(int i = zombieSpawner.zombieControllers.Count - 1; i >= 0; i--)
        {
            ZombieController zc = zombieSpawner.zombieControllers[i];
            if (zc != null)
            {
                if (zc.gameObject.name.Equals(name))
                {
                    zc.Die(name);
                    zombieSpawner.zombieControllers.Remove(zc);
                }
            }
        }

    }
}
