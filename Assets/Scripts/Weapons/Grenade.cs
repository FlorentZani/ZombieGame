using System.Collections;
using UnityEngine;

public class Grenade :MonoBehaviour
{
    [SerializeField]
    GameObject grenade = null;

    [SerializeField]
    GameObject spawnPoint = null;

    GameObject currentGrenade;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowGrenade();
            StartCoroutine(SpawnAnotherGrenade());
        }
    }

    public void ToggleGrenade()
    {
        if (currentGrenade == null)
        {
            currentGrenade = Instantiate(grenade, spawnPoint.transform);
        }
    }

    public void DestroyGrenade()
    {
        if (currentGrenade != null)
        {
            Destroy(currentGrenade);
        }
    }

    void ThrowGrenade()
    {
        if (currentGrenade != null)
        {
            Rigidbody rigidbody = currentGrenade.GetComponent<Rigidbody>();
            rigidbody.isKinematic = false;
            currentGrenade.transform.parent = null;
            rigidbody.AddForce(new Vector3(10f, 40f, 20f));
            currentGrenade = null;
        }
    }
    
    IEnumerator SpawnAnotherGrenade()
    {
        yield return new WaitForSeconds(1f);
        ToggleGrenade();
    }
}
