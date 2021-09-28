using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class OverviewPanel : MonoBehaviour, IPanel
{
    public Text caseNumber, fullName, date, locationData, locationNotes;
    public RawImage photoTakenOP;
    public Text photoNotes;





    private void OnEnable()
    {
        caseNumber.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
        fullName.text = "FULL NAME: \n" + UIManager.Instance.activeCase.name;
        date.text = "DATE: \n" + DateTime.Today.ToString();
        //locationData.text = UIManager.Instance.activeCase.locationLatitude + " " + UIManager.Instance.activeCase.locationLongitude;
        locationNotes.text = "LOCATION NOTES: \n" + UIManager.Instance.activeCase.locationNotes;

        Texture2D recostructedImg = new Texture2D(1, 1);
        recostructedImg.LoadImage(UIManager.Instance.activeCase.photoTaken);
        Texture img = (Texture)recostructedImg;

        photoTakenOP.texture = img;
        photoNotes.text = "PHOTO NOTES: \n" + UIManager.Instance.activeCase.photoNotes;
    }



    public void ProcessInfo()
    {
    }
}
