using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    public static SoundManager instance
    {
        get
        {
            if (_instance == null)
                _instance = FindAnyObjectByType<SoundManager>();
            if (_instance == null)
                Debug.LogError("GameManager not found, can't create singleton object");
            return _instance;
        }
    }

    public AudioSource source;
    public AudioClip level, menu;

    public void menutheme()
    {
        if (source.clip != menu)
        {
            source.clip = menu;
            source.volume = 0.3F;
            source.Play();
        }
    }
    public void leveltheme()
    {
        if (source.clip != level)
        {
            source.clip = level;
            source.Play();
        }
        source.volume = 0.3F;
    }
    public void pausetheme()
    {
        source.volume = 0.15F;
    }
}