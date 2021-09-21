using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Case 
{
    public string caseID;
    public string name;
    public string date;
    public double locationLatitude;
    public double locationLongitude;
    public string locationNotes;
    public RawImage photoTaken;
    public string photoNotes;
}
