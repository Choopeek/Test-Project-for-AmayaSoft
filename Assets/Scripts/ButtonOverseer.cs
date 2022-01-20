using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOverseer : MonoBehaviour
{
    [SerializeField] SpriteDatabank spriteDatabank;
    [SerializeField]List<Button> buttonsOnScreen;

    [SerializeField] List<Sprite> listOfSprites;
    [SerializeField]List<bool> spritesToRotate = new List<bool>();
    float spriteRotation;
    float spriteScale;

    //handles list of buttons on screen; controls their sprites;

    private void OnEnable()
    {
        EventManager.buttonsWereSpawned += SetupSpritesForButtons;
        EventManager.getTheListOfSpritesOnScreen += PassTheListOfSpritesToTrickster;
    }

    private void OnDisable()
    {
        EventManager.buttonsWereSpawned -= SetupSpritesForButtons;
        EventManager.getTheListOfSpritesOnScreen += PassTheListOfSpritesToTrickster;
    }

    void SetupSpritesForButtons()
    {
        StartCoroutine(SetupSpritesForButtonsCoroutine());
    }
    IEnumerator SetupSpritesForButtonsCoroutine()
    {
        
        SetSpritesList();
        yield return new WaitForEndOfFrame();
        AssignSpritesToButton();
    }
    public void AddButtonsToList(Button button)
    {
        buttonsOnScreen.Add(button);
    }
    List<Sprite> PassTheListOfSpritesToTrickster()
    {
        return listOfSprites;
    }
    public int GetButtonsOnScreenCount()
    {
        return buttonsOnScreen.Count;
    }
     
    void SetSpritesList()
    {
        spritesToRotate.Clear();
        listOfSprites = GetSpriteListForCurrentButtons(buttonsOnScreen.Count);
        spriteRotation = spriteDatabank.SpriteRotation;
        spriteScale = spriteDatabank.SpriteScale;
        EventManager.CreateARiddle();
    }

    public List<Sprite> GetSpriteListForCurrentButtons(int howManySpritesToRetrieve)
    {
        List<Sprite> listToRetrieve = new List<Sprite>();
        List<int> donorList = new List<int>();

        for (int i = 0; i < spriteDatabank.ListToSend.Count; i++)
        {   
            donorList.Add(i);
        }
         
        for (int i = 0; i < howManySpritesToRetrieve; i++)
        {
            int donorListIndex = Random.Range(0, donorList.Count);
            int donorListValue = donorList[donorListIndex];            
            listToRetrieve.Add(spriteDatabank.ListToSend[donorListValue]);
            if (spriteDatabank.SpritesToRotate[donorListValue])
            {
                AddSpriteToRotate(true);
            } 
            else
            {
                AddSpriteToRotate(false);
            }
            donorList.Remove(donorList[donorListIndex]);
        }

        donorList.Clear();        
        return listToRetrieve;
    } 

    void AddSpriteToRotate(bool needToRotate)
    {
        spritesToRotate.Add(needToRotate);
    }
    
    void AssignSpritesToButton()
    {
        int i = 0;

        foreach (Button button in buttonsOnScreen)
        {
            buttonsOnScreen[i].SetSprite(listOfSprites[i], spritesToRotate[i], spriteRotation, spriteScale);
            i++;
        }
        ButtonsChangedSprites();
    }

    void ButtonsChangedSprites()
    {
        EventManager.ButtonsChangedSprites();
    }
}
