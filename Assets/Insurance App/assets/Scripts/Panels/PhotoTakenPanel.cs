using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoTakenPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public RawImage photoTaken;
    public InputField notes;

    public void ProcessInfo()
    {
    }
}
