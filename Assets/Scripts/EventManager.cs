using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void HandleObjectToGuess();
    public static event HandleObjectToGuess buttonsChangedSprite;
    public static event HandleObjectToGuess buttonsWereSpawned;
    public static event HandleObjectToGuess createARiddle;

    public delegate List<Sprite> GetTheListOfSpritesOnScreen();
    public static event GetTheListOfSpritesOnScreen getTheListOfSpritesOnScreen;
    public delegate bool WasPlayerRight(string whatDidPlayerChose);
    public static event WasPlayerRight wasPlayerRight;

    public delegate void PlayerWon();
    public static event PlayerWon playerWon;

    public delegate void LoadNexLevel();
    public static event LoadNexLevel loadNextLevel;
    public static event LoadNexLevel updateUI;

    public static void UpdateUI()
    {
        if (updateUI != null) 
        {
            updateUI();
        }
    }

    public static void LoadNextLevel()
    {
        if (loadNextLevel != null)
        {
            loadNextLevel();
        }
    }

    public static void PlayerGuessedRight()
    {
        if (playerWon != null)
        {
            playerWon();
        }
        LoadNextLevel();
    }

   
    public static void PlayersChoice(string playersChoice)
    {
        if (wasPlayerRight == null)
        {
            return;
        }

        if (wasPlayerRight(playersChoice))
        {
            Debug.Log("PlayerGuessedRight");
            PlayerGuessedRight(); //somewhere here I just gave up and turned EventManager into GameManager. 
        }
        else
        {
            Debug.Log("TryAgain");
        }

    } 
    public static void ButtonsChangedSprites()
    {
        if (buttonsChangedSprite != null)
        {
            buttonsChangedSprite();
        }
    }

    public static void ButtonsWereSpawned()
    {
        if (buttonsWereSpawned != null)
        {
            buttonsWereSpawned();
        }   
        

    }

    public static List<Sprite> GetTheListOfSprites()
    {
        if (getTheListOfSpritesOnScreen == null)
        {
            return null;
        }
        return getTheListOfSpritesOnScreen();
    }

    public static void CreateARiddle()
    {
        if (createARiddle != null)
        {
            createARiddle();
        }
    }

   


}
