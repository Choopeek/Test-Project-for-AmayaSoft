using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    delegate void HandleGameObjectAtStart();
    HandleGameObjectAtStart buttonStart;


    Image buttonImage; 
    [SerializeField] ButtonOverseer buttonOverseer;


    private void OnEnable()
    {
        buttonStart += HandleImageComponent;
        buttonStart += HandleButtonOverseer;
        buttonStart += AddToButtonsList;
        if (buttonStart != null)
        {
            buttonStart();
        }
    }

    private void OnDisable()
    {
        buttonStart -= HandleImageComponent;
        buttonStart -= HandleButtonOverseer;
        buttonStart -= AddToButtonsList;
        
    }

    void HandleButtonOverseer()
    {
        buttonOverseer = GameObject.Find("ButtonOverseer").GetComponent<ButtonOverseer>();
    }

    void AddToButtonsList()
    {
        buttonOverseer.AddButtonsToList(this);
    }
    void HandleImageComponent()
    {
        buttonImage = transform.GetChild(0).GetComponent<Image>();
    }
    public void SetSprite(Sprite spriteToSet, bool needToRotate, float rotationValue, float scaleValue)
    {
        if (spriteToSet == null)
        {
            Debug.Log("spriteToSet is null on " + this.gameObject.name);
            return;
        }
        buttonImage.sprite = spriteToSet;
        NulifyRotationChanges();
        if (needToRotate)
        {
            this.gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, rotationValue);
        }
        this.gameObject.transform.GetChild(0).transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    void NulifyRotationChanges()
    {
        this.gameObject.transform.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, 0);
    }
    public void ButtonClicked()
    {
        EventManager.PlayersChoice(GetSpriteName());
    }
    
    string GetSpriteName()
    {
        return buttonImage.sprite.name;
    }
    
}
