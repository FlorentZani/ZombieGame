using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeObject : MonoBehaviour
{
    [SerializeField]
    GameObject explosionEffect = null;

    [SerializeField]
    GameObject damageCollider = null;

    void OnCollisionEnter(Collision col)
    {
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        yield return new WaitForSeconds(2f);
        explosionEffect.SetActive(true);
        damageCollider.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        damageCollider.SetActive(false);
        Destroy(this);
    }
}
