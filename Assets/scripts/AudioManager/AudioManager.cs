using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static bool initialized = false;
    static AudioSource audioSource;

    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();


    public static bool Initialized { get => initialized; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    internal static void Initialize(AudioSource Source)
    {
        initialized = true;
        audioSource = Source;
        audioClips.Add(AudioClipName.Eat,
            Resources.Load<AudioClip>(AudioClipName.Eat.ToString()));
        audioClips.Add(AudioClipName.ButtonClick,
            Resources.Load<AudioClip>(AudioClipName.ButtonClick.ToString()));
        audioClips.Add(AudioClipName.MenuLoad,
            Resources.Load<AudioClip>(AudioClipName.MenuLoad.ToString()));
        audioClips.Add(AudioClipName.GameOver,
            Resources.Load<AudioClip>(AudioClipName.GameOver.ToString()));
        audioClips.Add(AudioClipName.FoodPopping,
            Resources.Load<AudioClip>(AudioClipName.FoodPopping.ToString()));
    }

    public static void Play(AudioClipName clipName)
    {
        audioSource.PlayOneShot(audioClips[clipName]);
    }
}
