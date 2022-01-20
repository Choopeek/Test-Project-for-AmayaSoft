using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIhandler : MonoBehaviour
{
    [SerializeField] TMP_Text textUI;
    [SerializeField] Trickster trickster;

    private void OnEnable()
    {
        EventManager.updateUI += SetText;
    }

    private void OnDisable()
    {
        EventManager.updateUI -= SetText;
    }

    void SetText()
    {
        string textToSet;
        textToSet = GenerateFindText();
        textUI.text = "Find " + textToSet;
    }

    string GenerateFindText()
    {
        string textToProcess = trickster.GetRightAnswer();
        string processedText = textToProcess.Replace(textToProcess.Remove(textToProcess.IndexOf('_') + 1), string.Empty);
        return processedText;
    }

}
