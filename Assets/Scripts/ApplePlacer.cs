using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplePlacer : MonoBehaviour
{
    public GameObject ApplePrefab;

    public void Place(Vector3 enemyPosition)
    {
        //what, where, rotation
        Instantiate(ApplePrefab, enemyPosition, Quaternion.identity);
    }
}
