using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField]
    List<AudioClip> audioClips = null;

    [SerializeField]
    AudioSource audioSource = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(string clipName)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip.name == clipName)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
