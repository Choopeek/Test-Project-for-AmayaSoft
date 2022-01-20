using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] SpriteDatabank spriteDatabank;
    [SerializeField] SpawnManager spawnManager;
    [SerializeField] DifficultyHandler difficultyHandler;

    private void OnEnable()
    {
        EventManager.loadNextLevel += LoadNextLevel;
    }

    private void OnDisable()
    {
        EventManager.loadNextLevel -= LoadNextLevel;
    }

    private void Start()
    {
        StartCoroutine(SettingGameData());
    }
    
    IEnumerator SettingGameData()
    {
        spriteDatabank.ApplyListsToSend();
        yield return new WaitForEndOfFrame();
        LoadNextLevel();
        //I do think that setting all the data via a coroutine is easier then making all those checks. Still, big chunks of data (that may load longer then the frame duration) will need those.
    }

    void LoadNextLevel()
    {
        StartCoroutine(StartGameCoroutine());
    }

    IEnumerator StartGameCoroutine()
    {
        yield return new WaitForEndOfFrame();
        spawnManager.SpawnLevel(difficultyHandler.DifficultyLevel);
        yield return new WaitForEndOfFrame();
    }
    
}
