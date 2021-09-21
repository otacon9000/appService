using System.Collections;
using System.Collections.Generic;
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
    [Header("Panel")]
    public ClientInfoPanel clientInfoPanel;
    public LocationPanel locationPanel; 
    public GameObject borderPanel;

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
}