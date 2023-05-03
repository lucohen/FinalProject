using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Sandie : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public Sprite SoberSprite;
    public Sprite DrunkSprite;
    public Game Game;

    private bool isDrunk = false;
    private bool isPlastered = false;

    private int lastRandomDirection = 1;
    private int randomMoveCountdown = 0;

    private bool isPlaying = false;

    public void Update()
    {
        if (HasGameJustEnded())
            ResetCorgi();

        if (isPlastered)
            MoveRandomly();
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

        SoberUp();

        CleanUpPoop();
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
        CorgiSpriteRenderer.transform.position = new Vector3(0f, 0f, 0f);
        CorgiSpriteRenderer.flipX = false;
    }

    public void MoveManually(Vector2 direction)
    {
        if (isPlastered)
            return;
        Move(direction);
    }

    public void Move(Vector2 direction)
    {
        direction = ApplyDrunkenness(direction);
        FaceCorrectDirection(direction);

        float xAmount = direction.x * GameParameters.CorgiMoveAmount;
        float yAmount = direction.y * GameParameters.CorgiMoveAmount;
        Vector3 moveAmount = new Vector3(xAmount, yAmount, z: 0f);
        CorgiSpriteRenderer.transform.Translate(moveAmount);

        keepOnScreen();
    }

    public void MoveRandomly()
    {
        int newDirection = lastRandomDirection;

        if (randomMoveCountdown == 0)
        {
            newDirection = Random.Range(1, 5);
            randomMoveCountdown = Random.Range(40, 80);
            lastRandomDirection = newDirection;
        }

        switch (newDirection)
        {
            case 1:
                Move(new Vector2(1, 0));
                break;
            case 2:
                Move(new Vector2(-1, 0));
                break;
            case 3:
                Move(new Vector2(0, 1));
                break;
            case 4:
                Move(new Vector2(0, -1));
                break;
        }

        randomMoveCountdown = randomMoveCountdown - 1;
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
            GetDrunk();
            print("Beer");
        }
        if (col.gameObject.tag == "Bone")
        {
            ScoreKeeper.AddToScore(1);
            print("Score = " + ScoreKeeper.GetScore());
        }
        if (col.gameObject.tag == "Pill")
        {
            SoberUp();
        }
        if (col.gameObject.tag == "Moonshine")
        {
            GetPlastered();
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

    private void GetPlastered()
    {
        isPlastered = true;
        Inebriate();
    }

    private void Inebriate()
    {
        ChangeToDrunkSprite();
        StartCoroutine(WaitToSoberUp());
    }

    private void GetDrunk()
    {
        isDrunk = true;
        Inebriate();

    }

    IEnumerator WaitToSoberUp()
    {
        yield return new WaitForSeconds(7f);
        SoberUp();
    }

    private void SoberUp()
    {
        ChangeToSoberSprite();
        isDrunk = false;
        isPlastered = false;
    }

    private void ChangeToSoberSprite()
    {
        CorgiSpriteRenderer.sprite = SoberSprite;
    }

    private void ChangeToDrunkSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkSprite;
    }

    private Vector2 ApplyDrunkenness(Vector2 direction)
    {
        if (isDrunk)
        {
            direction.x = direction.x * -1;
            direction.y = direction.y * -1;
        }

        return direction;
    }
}
