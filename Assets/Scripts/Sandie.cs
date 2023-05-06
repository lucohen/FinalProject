using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sandie : Character
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite HatSprite;
    public Sprite DrunkSprite;
    public Game Game;

    private bool isFast = false;
    private bool isInvisible = false;

    private int killshots = 0;
    private int mines = 0;

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
        if (col.gameObject.tag == "Beer")
        {
            print("Beer");
        }

        if (col.gameObject.tag == "Pill")
        {
        }
        if (col.gameObject.tag == "Moonshine")
        {
        }
        Destroy(col.gameObject);
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
        isFast = false;
    }

    private void ChangeToHatSprite()
    {
        CorgiSpriteRenderer.sprite = HatSprite;
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }

    
}
