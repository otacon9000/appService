using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientInfoPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public InputField firstName, lastName;


    private void OnEnable()
    {
        caseNumber.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
    }

    public void ProcessInfo()
    {
        if (string.IsNullOrEmpty(firstName.text) || string.IsNullOrEmpty(lastName.text))
        {
            Debug.LogError("name is null");
            return;
        }
        UIManager.Instance.activeCase.name = firstName.text + " " + lastName.text;
        UIManager.Instance.locationPanel.gameObject.SetActive(true);
            
    }
}
