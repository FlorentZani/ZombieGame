using UnityEngine;

public class ZombieCollider : MonoBehaviour
{
    public bool IsPlayerInRange;

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            IsPlayerInRange = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            IsPlayerInRange = false;
        }
    }
}
