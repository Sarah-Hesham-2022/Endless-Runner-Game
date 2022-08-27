using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    // Start is called before the first frame update
    void Start()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        try
        {
              PlaySound("MainTheme");
        }
        catch
        {

        }
        try
        {
            PlaySound("DrumBeat");
        }
        catch
        {

        }
    }

    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }

    }
    public void PauseSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Pause();
            }
        }

    }
    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
                s.source.Stop();
            }
        }

    }
    public void PlayCoin(string name,Vector3 pos)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
            {
               AudioSource.PlayClipAtPoint(s.clip,pos);
            }
        }

    }
}
