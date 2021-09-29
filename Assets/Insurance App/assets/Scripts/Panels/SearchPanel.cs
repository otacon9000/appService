using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SearchPanel : MonoBehaviour, IPanel
{
    public InputField caseNumber;

    public void ProcessInfo()
    {
        AWSManager.Instance.GetList(caseNumber.text, () =>
        {
            UIManager.Instance.selectPanel.gameObject.SetActive(true);
        });

    }
}
