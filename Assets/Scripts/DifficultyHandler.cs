using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    private int difficultyLevel;


    private void OnEnable()
    {
        EventManager.playerWon += IncreaseDifficultyLevel;
    }

    private void OnDisable()
    {
        EventManager.playerWon -= IncreaseDifficultyLevel;
    }
    public int DifficultyLevel
    {
        get { return difficultyLevel; }
    }
    private void Start()
    {
        difficultyLevel = 1;
    }

    void IncreaseDifficultyLevel()
    {
        
        if(difficultyLevel == 4)
        {
            Debug.Log("You win");
            return;
        }
        difficultyLevel++;
    }
    
}
