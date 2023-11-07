using UnityEngine;
using System;

public class Gun : MonoBehaviour
{
    [SerializeField]
    protected Animator animator = null;

    public Action<string> hitZombie;
    public Action<GameObject> hitBarrel;

    public bool CanShoot
    {
        get
        {
            return animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0);
        }
    }

    public virtual void Update()
    {
        if (!CanShoot)
        {
            animator.SetBool("shoot", false);
        }

        if (Input.GetMouseButtonDown(0) && CanShoot)
        {
            animator.SetBool("shoot", true);
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            Collider target = hit.collider;
            float distance = hit.distance;
            Vector3 location = hit.point;
            
            if (target.name.ToLower().Contains("zombie"))
            {
                hitZombie?.Invoke(target.name);
            }
            else if (target.tag.Equals("boom"))
            {
                hitBarrel?.Invoke(target.gameObject);
            }
        }
    }
}
