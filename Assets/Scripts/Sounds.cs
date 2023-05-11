using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{

    public AudioSource AudioSource;
    public AudioClip PlayButtonClip;
    public AudioClip AgainButtonClip;

    public void PlayPlayButtonSound()
    {
        AudioSource.clip = PlayButtonClip;
        AudioSource.Play();
    }
}
