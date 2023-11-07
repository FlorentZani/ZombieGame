using UnityEngine;
using System;
using System.Collections.Generic;

public class ZombieController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.0f;
    [SerializeField] Animator animator = null;
    [SerializeField] List<GameObject> bloodSpatterObjects = null;
    GameObject player;
    int movementType;
    bool moveZombie = true;
    public Action spawnNewZombie;
    public Action HitPlayer;
    List<string> zombieGrowls = new List<string>() { "ZombieGrowl1", "ZombieGrowl2", "ZombieGrowl3", "ZombieGrowl4" };

    void Start()
    {
        int growlIndex = UnityEngine.Random.Range(0, zombieGrowls.Count);
        SoundManager.Instance.PlaySound(zombieGrowls[growlIndex]);
        player = GameObject.FindGameObjectWithTag("Player");
        movementType = Move();
        if (movementType == 1)
        {
            moveSpeed = 1.5f;
            Walk();
        }
        else if (movementType == 2)
        {
            moveSpeed = 2f;
            Run();
        }
    }

    void Update()
    {
        if (moveZombie)
        {
            MoveTowardsPlayer();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player" || col.gameObject.tag == "weapon")
        {
            HitPlayer?.Invoke();
            DestroyZombie();
        }
        else if(col.gameObject.tag == "explosion")
        {
            DestroyZombie();
        }
    }

    void DestroyZombie()
    {
        spawnNewZombie?.Invoke();
        Bleed();
        Destroy(gameObject);
    }

    int Move()
    {
        int random = UnityEngine.Random.Range(1, 3);
        return random;
    }

    void Walk()
    {
        animator.SetBool("walk", true);
    }

    void Run()
    {
        animator.SetBool("run", true);
    }

    void Attack()
    {
        animator.SetBool("attack", true);
    }

    void MoveTowardsPlayer()
    {
       transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), moveSpeed * Time.deltaTime);
       transform.LookAt(new Vector3(player.transform.position.x, 0, player.transform.position.z));
    }

    public void Die(string name)
    {
        if (animator != null)
        {
            animator.SetBool("die", true);
            SoundManager.Instance.PlaySound("ZombieDie");
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            moveZombie = false;
        }
    }

    public void StopDying()
    {
        animator.SetBool("die", false);
        spawnNewZombie?.Invoke();
        spawnNewZombie = delegate { };
        animator.StopPlayback();
        Destroy(gameObject);
    }

    public void Bleed()
    {
        GameObject blood = Instantiate(bloodSpatterObjects[UnityEngine.Random.Range(0, bloodSpatterObjects.Count)], null);
        blood.transform.localPosition = this.gameObject.transform.position;
    }
}
