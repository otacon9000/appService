using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverviewPanel : MonoBehaviour, IPanel
{
    public Text caseNumber, fullName, date, locationData, locationNotes;
    public RawImage photoTaken;
    public Text photoNotes;

    public void ProcessInfo()
    {
    }
}
