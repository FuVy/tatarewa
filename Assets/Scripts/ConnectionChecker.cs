using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ConnectionChecker : MonoBehaviour
{ 
    [SerializeField]
    private float _checkTime = 2f;
    [SerializeField]
    private Image _image;

    private IEnumerator CheckInternetConnection(Action<bool> action)
    {
        WWW www = new WWW("http://google.com");
        yield return www;
        if (www.error != null)
        {
            action(false);
        }
        else
        {
            action(true);
        }
    }

    private void Start()
    {
        CheckConnection();
    }

    private void CheckConnection()
    {
        StartCoroutine(CheckInternetConnection((isConnected) =>
        {
            if(!isConnected)
            {
                _image.enabled = true;
            }
            else
            {
                _image.enabled = false;
            }
        }));
        Invoke("CheckConnection", _checkTime);
    }
}