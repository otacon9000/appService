using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System.IO;
using System;
using Amazon.S3.Util;
using System.Collections.Generic;
using Amazon.CognitoIdentity;
using Amazon;

public class AWSManager : MonoBehaviour
{
    private static AWSManager _instance;
    public static AWSManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("AWS Manager is NULL");
            }
            return _instance;
        }
    }


    public string S3Region = RegionEndpoint.USEast2.SystemName;
    private RegionEndpoint _S3Region
    {
        get { return RegionEndpoint.GetBySystemName(S3Region); }
    }

    private AmazonS3Client _s3Client;
    public AmazonS3Client S3Client
    {
        get
        {
            if(_s3Client == null)
            {
                _s3Client = new AmazonS3Client(new CognitoAWSCredentials(
            "us-east-2:c0eef1ff-2164-429b-b3b3-df40cb717822", // Identity pool ID
            RegionEndpoint.USEast2 //region
            ), _S3Region);
            }
            return _s3Client;
        }
    }

    public string bucketName;


    private void Awake()
    {
        _instance = this;
        
        UnityInitializer.AttachToGameObject(this.gameObject);

        AWSConfigs.HttpClient = AWSConfigs.HttpClientOption.UnityWebRequest;

        S3Client.ListBucketsAsync(new ListBucketsRequest(), (responsObject) =>
        {
            if(responsObject.Exception == null)
            {
                responsObject.Response.Buckets.ForEach((s3b) =>
                {
                    Debug.Log("BucketName: " + s3b.BucketName);
                });
                
            }else
            {
                Debug.Log("AWS ERROR: " + responsObject.Exception);
            }
        }); 
    }


    public void UploadToS3(string path, string caseID)
    {
        FileStream stream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

        PostObjectRequest request = new PostObjectRequest()
        {
            Bucket = bucketName,
            Key = "case#" + caseID,
            InputStream = stream,
            CannedACL = S3CannedACL.Private,
            Region = _S3Region
        };

        S3Client.PostObjectAsync(request, (responseObj) =>
        {
            if (responseObj.Exception == null)
            {
                Debug.Log("Successfully posted to bucket");
            }
            else
            {
                Debug.Log("Exception occur during uploading: " + responseObj.Exception);
            }
        });
        



    }
}
