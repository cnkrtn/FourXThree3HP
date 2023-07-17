using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource1,audioSource2,audioSource3;

    public void PlaySound(AudioClip clip)
    {
        audioSource1.PlayOneShot(clip);
    }
    
    public void StopSound()
    {
        audioSource1.Stop();
    }
    
    public void PlaySound2(AudioClip clip)
    {
        audioSource2.PlayOneShot(clip);
    }
    
    public void StopSound2()
    {
        audioSource2.Stop();
    }
    
    public void PlaySound3(AudioClip clip)
    {
        audioSource3.PlayOneShot(clip);
    }
    
    public void StopSound3()
    {
        audioSource3.Stop();
    }
}
