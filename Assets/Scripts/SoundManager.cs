using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //List of special sound class gameObjects
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.SetSource();
        }
    }

    public void PlaySound(string name)
    {
        Sound soundToPlay = null;
        foreach (Sound sound in sounds)
        {
            if (sound.name == name)
            {
                soundToPlay = sound;
                break;
            }
        }
        if(soundToPlay != null)
        {
            soundToPlay.Play();
        }
    }
}
