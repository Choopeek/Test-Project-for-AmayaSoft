using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewListOfSprites", menuName = "New List of Sprites", order = 1)]
public class SpriteList : ScriptableObject
{
    [SerializeField] List<Sprite> listOfSprites = new List<Sprite>();
    [SerializeField] float spritesScale;
    [SerializeField] List<bool> spritesToRotate = new List<bool>();
    [SerializeField] float rotateValue; //here we could write the list\array of float values if different sprites on the same sheet needed different rotate values;

    public List<Sprite> ListOfSprites
    {
        get { return listOfSprites; }
    }

    public List<bool> SpritesToRotate
    {
        get { return spritesToRotate; }
    }

    public float SpriteScale
    {
        get { return spritesScale; }
    }

    public float RotateValue
    {
        get { return rotateValue; }
    }

}
