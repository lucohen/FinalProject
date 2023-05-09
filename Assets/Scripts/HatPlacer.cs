using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatPlacer : MonoBehaviour
{
    public GameObject HatPrefab;

    public void Place(Vector3 enemyPosition)
    {
        //what, where, rotation
        Instantiate(HatPrefab, enemyPosition, Quaternion.identity);
    }
}

