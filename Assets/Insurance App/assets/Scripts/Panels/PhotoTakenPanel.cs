using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotoTakenPanel : MonoBehaviour, IPanel
{
    public Text caseNumber;
    public RawImage photoTaken;
    public InputField notes;

    private bool _isPhotoTaken;
    private string imgPath;

    private void OnEnable()
    {
        caseNumber.text = "CASE NUMBER " + UIManager.Instance.activeCase.caseID;
    }

    public void ProcessInfo()
    {
        if (string.IsNullOrEmpty(notes.text) == false)
        {
            UIManager.Instance.activeCase.photoNotes = notes.text;
        }

        if(_isPhotoTaken == true)
        {
            Texture2D convertedPhoto = NativeCamera.LoadImageAtPath(imgPath, 512, false);
            byte[] imgData = convertedPhoto.EncodeToPNG();

            UIManager.Instance.activeCase.photoTaken = imgData;

            UIManager.Instance.overViewPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("No photo");
        }
       


    }

    public void TakePictureButton()
    {
        TakePicture(512);
    }


    private void TakePicture(int maxSize)
    {
        NativeCamera.Permission permission = NativeCamera.TakePicture((path) =>
        {
            Debug.Log("Image path: " + path);
            if (path != null)
            {
                // Create a Texture2D from the captured image
                Texture2D texture = NativeCamera.LoadImageAtPath(path, maxSize,false);
                if (texture == null)
                {
                    Debug.Log("Couldn't load texture from " + path);
                    return;
                }

                photoTaken.texture = texture;
                photoTaken.gameObject.SetActive(true);
                _isPhotoTaken = true;

                imgPath = path;
                
                
            }
        }, maxSize);

        Debug.Log("Permission result: " + permission);
    }
}
