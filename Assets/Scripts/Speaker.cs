using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(AudioSource))]
public class Speaker : MonoBehaviour
{
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
        StartCoroutine(GetClip(textToSpeech));
    }

    IEnumerator GetClip(string textToSpeech)
    {
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip(ServerConfig.SPEECH_SERVER_URL + "?t=" + textToSpeech, AudioType.MPEG))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log(www.error);
            }
            else
            {
                _clip = DownloadHandlerAudioClip.GetContent(www);
                _source.clip = _clip;
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
}
