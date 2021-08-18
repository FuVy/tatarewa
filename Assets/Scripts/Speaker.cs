using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class Speaker : MonoBehaviour
{
    [SerializeField]
    private UnityEvent ClipRequestSuccessful;
    [SerializeField]
    private UnityEvent TextIsNull;

    public float ClipLength => _clip.length;

    private AudioSource _source;
    private AudioClip _clip;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    public void Load(string textToSpeech)
    {
        Stop();
        if (textToSpeech != "")
        {
            StartCoroutine(GetClip(textToSpeech));
        }
        else
        {
            TextIsNull.Invoke();
        }
    }

    IEnumerator GetClip(string textToSpeech)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(ServerConfig.SPEECH_SERVER_URL + "?t=" + textToSpeech, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                print(textToSpeech);
                _clip = DownloadHandlerAudioClip.GetContent(www);
                _source.clip = _clip;
                //Play();
                ClipRequestSuccessful.Invoke();
            }
            else if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
        }
    }


    public void Pause()
    {
        _source.Pause();
    }

    public void Unpause()
    {
        _source.UnPause();
    }

    public void Play()
    {
        _source.Play();
    }

    public void Stop()
    {
        _source.Stop();
    }

    public void DeleteClip()
    {
        _source.clip = null;
    }
}
