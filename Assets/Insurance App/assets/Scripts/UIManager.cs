using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UI Manager is NULL");
            }
            return _instance;
        }
    }
    [Header("Create a Case Panel")]
    public ClientInfoPanel clientInfoPanel;
    public LocationPanel locationPanel; 
    public PhotoTakenPanel photoTakenPanel; 
    public GameObject borderPanel;

    [Header("Overview Panel")]
    public GameObject overViewPanel;

    [Header("Case")]
    public Case activeCase;

    private void Awake()
    {
        _instance = this;
    }

    public void CrateNewCase()
    {
        activeCase = new Case();
        //generate caseID


        activeCase.caseID = Random.Range(0, 1000).ToString();

        clientInfoPanel.gameObject.SetActive(true);
        borderPanel.SetActive(true);
    }


    public void SubmitButton()
    {
        Case awsCase = new Case();
        awsCase.caseID = activeCase.caseID;
        awsCase.name = activeCase.name;
        awsCase.date = activeCase.date;
        awsCase.locationNotes = activeCase.locationNotes;
        awsCase.photoTaken= activeCase.photoTaken;
        awsCase.photoNotes= activeCase.photoNotes;

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/case#" + awsCase.caseID + ".dat");
        bf.Serialize(file, awsCase);
        file.Close();
    }
}