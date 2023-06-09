using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sandie : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite HatSprite;
    public Sprite BaseSprite;
    public Game Game;
    public int mines = 2;
    public bool isDead = false;

    private bool isInvisible = false;

    private int killshots = 0;

    private bool isPlaying = false;

    public void Update()
    {
        if (HasGameJustEnded())
            ResetSandie();

    }

    public void StartGame()
    {
        isPlaying = true;
    }

    public int getMines()
    {
        return mines;
    }

    private bool HasGameJustEnded()
    {
        if (!Game.IsRunning() && isPlaying)
        {
            isPlaying = false;
            return true;
        }

        return false;
    }

    private void ResetSandie()
    {

        ResetPositionAndDirection();

        RemovePowersAndItems();

        CleanUpMines();
    }

    private void RemovePowersAndItems()
    {
        killshots = 0;
        mines = 0;
        EndPower();
    }

    private void CleanUpMines()
    {
        foreach (GameObject placedObject in GameObject.FindGameObjectsWithTag("Mine"))
        {
            Destroy(placedObject);
        }
    }

    private void ResetPositionAndDirection()
    {
        CorgiSpriteRenderer.transform.position = new Vector3(0f, 0f, 0f);
        CorgiSpriteRenderer.flipX = false;
    }

    public void MoveManually(Vector2 direction)
    {
        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);

        float xAmount = direction.x * GameParameters.CorgiMoveAmount;
        float yAmount = direction.y * GameParameters.CorgiMoveAmount;
        Vector3 moveAmount = new Vector3(xAmount, yAmount, z: 0f);
        CorgiSpriteRenderer.transform.Translate(moveAmount);

        keepOnScreen();
    }

    

    public void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            CorgiSpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            CorgiSpriteRenderer.flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Hat")
        {
            ChangeToHatSprite();
            StartCoroutine(WaitToEndPower());
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Bone")
        {
            killshots++;
            NumbersKeeper.AddToKillshots();
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Apple")
        {
            mines++;
            NumbersKeeper.AddToMines();
            Destroy(col.gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Beer")
        {
            print("Beer");
        }
        if (col.gameObject.tag == "Bone")
        {
            print("Bone");
        }
        if (col.gameObject.tag == "Pill")
        {
            print("Pill");
        }
    }

    private void keepOnScreen()
    {
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    

    IEnumerator WaitToEndPower()
    {
        yield return new WaitForSeconds(7f);

        EndPower();
    }

    private void EndPower()
    {
        isInvisible = false;
        ChangeToBaseSprite();
    }

    private void ChangeToHatSprite()
    {
        CorgiSpriteRenderer.sprite = HatSprite;
        isInvisible = true;
    }

    private void ChangeToBaseSprite()
    {
        CorgiSpriteRenderer.sprite = BaseSprite;
    }


    private void Attack()
    {
        if (killshots > 0)
        {
            killshots--;
            //somehow destroy enemy within range
        }
    }

    
}
