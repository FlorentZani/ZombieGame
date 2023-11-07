using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    void Update()
    {
        Vector3 eulerAngles = transform.localEulerAngles;
        eulerAngles.x = 90;
        eulerAngles.y = 0;
        eulerAngles.z = 0;
        transform.localEulerAngles = eulerAngles;
    }
}
