using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LocationPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public RawImage mapImg;
    public InputField notes;

    public string apiKey;
    public float xCord, yCord;
    public int zoom;
    public int imgSize;
    public string url = "https://maps.googleapis.com/maps/api/staticmap?";

    private void OnEnable()
    {
        caseNumber.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;

        url = $"{url}center={xCord},{yCord}&zoom={zoom}&size={imgSize}x{imgSize}&key={apiKey}";
        //download static map 
        StartCoroutine(GetLocationRoutine());
    
    }

    IEnumerator GetLocationRoutine()
    {
        using (WWW map = new WWW(url))
        {
            yield return map;

            if (map.error != null)
            {
                Debug.LogError("Map error: " + map.error);
            }

            mapImg.texture = map.texture;

        }
    }

    public void ProcessInfo()
    {
    }
}


