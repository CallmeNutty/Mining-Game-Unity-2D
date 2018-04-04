using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField]
    private AudioSource soundEffects;

    public void PlayRandomSoundEffect(AudioClip[] clip)
    {
        soundEffects.PlayOneShot(clip[Random.Range(0, clip.Length)], 1);
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        soundEffects.PlayOneShot(clip, 1);
    }
}
