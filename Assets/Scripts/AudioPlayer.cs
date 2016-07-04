using UnityEngine;
using System.Collections;

public class AudioPlayer : MonoBehaviour
{

    public static AudioPlayer INSTANCE = null;

    public AudioSource effectsSource;

    void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
        }
        else if (INSTANCE != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Play(AudioClip clip)
    {
        effectsSource.clip = clip;
        effectsSource.Play();
    }
}
