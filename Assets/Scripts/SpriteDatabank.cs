using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteDatabank : MonoBehaviour
{
    [SerializeField] List<SpriteList> listCatalogue = new List<SpriteList>();    
    [Header("Button Sprites")]
    [SerializeField] Sprite homeButtonSprite;
    [SerializeField] Sprite restartButtonSprite;
    [SerializeField] Sprite backButtonSprite;
    [SerializeField] Sprite yesButtonSprite;
    [Space(20)]
    [Header("List that will be sent")]
    
    List<Sprite> listToSend;
    List<bool> spritesToRotate;
    float spriteRotation;
    float spriteScale;



    public List<Sprite> ListToSend
    {
        get { return listToSend; }
    }
    public List<bool> SpritesToRotate
    {
        get { return spritesToRotate; }
    }
    public float SpriteRotation
    {
        get { return spriteRotation; }
    }
    public float SpriteScale
    {
        get { return spriteScale; }
    }

    public void ApplyListsToSend()
    {
        int listNumber = ChooseList();
        listToSend = new List<Sprite>(listCatalogue[listNumber].ListOfSprites);
        spritesToRotate = new List<bool>(listCatalogue[listNumber].SpritesToRotate);
        spriteScale = listCatalogue[listNumber].SpriteScale;
        spriteRotation = listCatalogue[listNumber].RotateValue;        
    }

    int ChooseList()
    {
        int listNumber = Random.Range(0, listCatalogue.Count);
        return listNumber;
    } 
}
