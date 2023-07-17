
using UnityEngine;
using UnityEngine.Audio;

public class Ses2 : MonoBehaviour
{
  
    public AudioMixer audioMixer;
    public string outputGroup;

    void Start()
    {
        audioMixer.SetFloat(outputGroup, 0f); 
    }

   
}
