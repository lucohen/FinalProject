using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer EnemySpriteRenderer;
    public Sprite EnemySprite;
    public Sprite AlertedEnemySprite;
    public Game Game;

    private bool isAlerted = false;
    private bool movingUp = false;
    private bool movingRight = false;

    public float moveDistance = 3.0f;
    private int randomMoveCountdown = 0;

    private bool isPlaying = false;

    public void Update()
    {
        //Move();
        moveUpAndDown();
        if (HasGameJustEnded())
            ResetEnemy();
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

    private void ResetEnemy()
    {

        ResetPositionAndDirection();

        
    }



    private void CleanUpPoop()
    {
        foreach (GameObject placedObject in GameObject.FindGameObjectsWithTag("Poop"))
        {
            Destroy(placedObject);
        }
    }

    private void ResetPositionAndDirection()
    {
        //Need to customize their individual starting points
        EnemySpriteRenderer.transform.position = new Vector3(0f, 0f, 0f);
        EnemySpriteRenderer.flipX = false;
    }


    //No idea how to move the enemy yet
    public void Move(Vector2 direction)
    {
        FaceCorrectDirection(direction);

        float xAmount = direction.x * GameParameters.EnemyMoveAmount;
        float yAmount = direction.y * GameParameters.EnemyMoveAmount;
        Vector3 moveAmount = new Vector3(xAmount, yAmount, z: 0f);
        EnemySpriteRenderer.transform.Translate(moveAmount);

        keepOnScreen();
    }

    

    public void FaceCorrectDirection(Vector2 direction)
    {
        if (direction.x > 0)
        {
            EnemySpriteRenderer.flipX = false;
        }
        else if (direction.x < 0)
        {
            EnemySpriteRenderer.flipX = true;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Mine")
        {
            Die();
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

    public void becomeAlerted()
    {
        ChangeToAlertedSprite();
        isAlerted = true;
    }

    public void moveUpAndDown()
    {

        // Check if the object has reached its maximum distance and needs to start moving down
        if (transform.position.y >= moveDistance && movingUp)
        {
            movingUp = false;
        }

        // Check if the object has reached its minimum distance and needs to start moving up
        if (transform.position.y <= 0 && !movingUp)
        {
            movingUp = true;
        }

        // Should add a small wait time before turning around
        if (movingUp)
        {
            moveUp();
        }
        else
        {
            moveDown();
        }
    
    }

    private void moveUp()
    {
        transform.Translate(Vector3.up * GameParameters.EnemyMoveAmount);
    }

    private void moveDown()
    {
        transform.Translate(Vector3.down * GameParameters.EnemyMoveAmount);
    }


    private void keepOnScreen()
    {
        EnemySpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(EnemySpriteRenderer);
    }


    private void ChangeToAlertedSprite()
    {
        EnemySpriteRenderer.sprite = AlertedEnemySprite;
    }

    

    


private void Die()
    {
        Destroy(gameObject);
        //chance to randomly drop an item
    }
}

