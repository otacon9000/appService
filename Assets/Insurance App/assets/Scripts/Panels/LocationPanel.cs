using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

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

    private bool _geoDataFailed = false;

    private void OnEnable()
    {
        caseNumber.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;    
    }

    public IEnumerator Start()
    {
        yield return null;
        //fetch GEO data
        if(Input.location.isEnabledByUser == true)
        {
            Input.location.Start();

            int maxWait = 20;
            while(Input.location.status == LocationServiceStatus.Initializing && maxWait> 0)
            {
                yield return new WaitForSeconds(1.0f);
                maxWait--;
            }

            if(maxWait < 1)
            {
                Debug.Log("Timed Out");
                yield break;
            }

            if(Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to determinate device location...");
                _geoDataFailed = true;
            }
            else
            {
                xCord = Input.location.lastData.latitude;
                yCord = Input.location.lastData.longitude;

            }

            Input.location.Stop();
        }
        else
        {
            Debug.Log("location service are not Enabled");
        }
        StartCoroutine(GetLocationRoutine());
    }

    IEnumerator GetLocationRoutine()
    {
        url = $"{url}center={xCord},{yCord}&zoom={zoom}&size={imgSize}x{imgSize}&key={apiKey}";

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
        if (string.IsNullOrEmpty(notes.text) == false)
        {
            UIManager.Instance.activeCase.locationNotes = notes.text;
        }
        if(_geoDataFailed == true)
        {
            UIManager.Instance.activeCase.locationLatitude = xCord;
            UIManager.Instance.activeCase.locationLongitude = yCord;
        }
        UIManager.Instance.photoTakenPanel.gameObject.SetActive(true);
    }

}


