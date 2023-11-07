using System.Collections;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour
{
    [SerializeField]
    GameObject explosion = null;

    [SerializeField]
    GameObject flames = null;

    [SerializeField]
    MeshRenderer meshRenderer = null;

    [SerializeField]
    SphereCollider damageCollider = null;
    
    void Awake()
    {
        ToggleEffects(false);
    }

    public void Explode(GameObject go)
    {
        if (go == this.gameObject)
        {
            ToggleEffects(true);
            meshRenderer.enabled = false;
            StartCoroutine(ToggleDamageCollider());
        }
    }

    void ToggleEffects(bool shouldShow)
    {
        if (flames != null)
        {
            flames.SetActive(shouldShow);
        }

        if (explosion != null)
        {
            explosion.SetActive(shouldShow);
        }
    }

    IEnumerator ToggleDamageCollider()
    {
        damageCollider.gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        damageCollider.gameObject.SetActive(false);
    }
}
