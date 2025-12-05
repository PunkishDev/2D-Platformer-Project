using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)] public float volume;
    public bool randomPitch;
    [Range(0, 1)] public float minPitch, maxPitch;
    public bool loop;
    public AudioSource source;

    public void Play()
    {
        SetVolume(volume);
        if(randomPitch)
        {
            source.pitch = Random.Range(minPitch, maxPitch);
        }else
        {
            source.pitch = minPitch;
        }
        source.loop = loop;
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }
    public void SetVolume(float volume)
    {
        this.volume = volume;
        source.volume = this.volume;
    }
    public void SetSource()
    {
        source.clip = clip;
        source.volume = volume;
        source.playOnAwake = false;
    }
}
