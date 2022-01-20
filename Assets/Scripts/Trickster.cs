using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trickster : MonoBehaviour
{
    //responsible for setting up the riddle, overwatching the riddle
    //tirckster may be set up to work with sprites. And compairing them checking for the right answer. But string would be less heavy in resources. Probably.
    [SerializeField]List<string> currentSpritesOnScreen;
    [SerializeField] List<string> rightAnswersList;
    [SerializeField] string rightAnswer;

    private void OnEnable()
    {
        EventManager.createARiddle += CreateARiddle;
        EventManager.wasPlayerRight += PlayerGuessed;
    }

    private void OnDisable()
    {
        EventManager.createARiddle -= CreateARiddle;
        EventManager.wasPlayerRight -= PlayerGuessed;
    }

    public string GetRightAnswer()
    {
        return rightAnswer;
    }
    private void Start()
    {
        HandleRightAnswerList();
    }

    void HandleRightAnswerList()
    {        
        rightAnswersList = new List<string>();
        rightAnswersList.Clear();
    }
   
    void CreateARiddle()
    {
        StartCoroutine(CreateARiddleCoroutine());
    }

    IEnumerator CreateARiddleCoroutine()
    {
        CreateListOfCurrentSprites();
        yield return new WaitForEndOfFrame();
        DefineRightAnswer();
        yield return new WaitForEndOfFrame();
        EventManager.UpdateUI();
    }
    void CreateListOfCurrentSprites()
    {
        currentSpritesOnScreen = ConvertSpriteListToString(EventManager.GetTheListOfSprites());
    }

    List<string> ConvertSpriteListToString(List<Sprite> listToConvert)
    {
        List<string> listOfStrings = new List<string>();
        foreach(Sprite sprite in listToConvert)
        {
            listOfStrings.Add(sprite.name);
        }
        return listOfStrings;
    }

    string ChooseRightAnswer()
    {
        string rightAnswer;
        rightAnswer = currentSpritesOnScreen[Random.Range(0, currentSpritesOnScreen.Count)];
        return rightAnswer;
    }
    void DefineRightAnswer()
    {
        rightAnswer = ChooseRightAnswer();
        if (TheAnswerWasAlreadyUsed())
        {
            DefineRightAnswer();
        }
        
        else
        {
            AddToRightAnswersList();
        }
    }

    void AddToRightAnswersList()
    {
        rightAnswersList.Add(rightAnswer);
    }

    bool TheAnswerWasAlreadyUsed()
    {
        foreach(string rightAnswerUsed in rightAnswersList)
        {
            if (rightAnswerUsed == rightAnswer)
            {
                return true;
            }
        }

        return false;        
    }

    bool PlayerGuessed(string playersChoice)
    {
        if (playersChoice == rightAnswer)
        {
            return true;
        }

        return false;
    }


}
