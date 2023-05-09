using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public Sandie Sandie;
    public MinePlacer MinePlacer;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Sandie.MoveManually(direction: new Vector2(x: 0f, y: 1f));
        }
        if (Input.GetKey(KeyCode.A))
        {
            Sandie.MoveManually(direction: new Vector2(x: -1f, y: 0f));
        }
        if (Input.GetKey(KeyCode.D))
        {
            Sandie.MoveManually(direction: new Vector2(x: 1f, y: 0f));
        }
        if (Input.GetKey(KeyCode.S))
        {
            Sandie.MoveManually(direction: new Vector2(x: 0f, y: -1f));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Sandie.mines > 0)
            {
                MinePlacer.Place(Sandie.transform.position);
                Sandie.mines--;
            }
        }
    }
}
