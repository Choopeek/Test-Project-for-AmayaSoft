using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spriteDatabankGObj;     
    [SerializeField]List<GameObject> level1Buttons;
    [SerializeField]List<GameObject> level2Buttons;
    [SerializeField]List<GameObject> level3Buttons;
     
   public void SpawnLevel(int difficulty)
    {
        switch(difficulty)
        {
            case 1:                
                MakeButtonsActive(level1Buttons);
                break;

            case 2:
                MakeButtonsActive(level2Buttons);
                break;

            case 3:
                MakeButtonsActive(level3Buttons);
                break;
        }
    }

    void MakeButtonsActive(List<GameObject> buttonsToMakeActive)
    {
        foreach (GameObject button in buttonsToMakeActive)
        {
            button.SetActive(true);
        }

        EventManager.ButtonsWereSpawned();
    }

}
