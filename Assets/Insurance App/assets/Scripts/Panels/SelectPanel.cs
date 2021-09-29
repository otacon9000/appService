using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectPanel : MonoBehaviour, IPanel
{
    public Text informationText;

    private void OnEnable()
    {
        informationText.text = UIManager.Instance.activeCase.name.ToUpper() +  UIManager.Instance.activeCase.date;
    }

    public void ProcessInfo()
    {
        UIManager.Instance.overViewPanel.SetActive(true);
    }
}
