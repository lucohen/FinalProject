using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePlacer : MonoBehaviour
{
    public GameObject MinePrefab;

    public void Place(Vector3 sandiePosition)
    {
        //what, where, rotation
        Instantiate(MinePrefab, sandiePosition, Quaternion.identity);
    }
}
