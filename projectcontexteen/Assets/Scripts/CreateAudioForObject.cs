using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateAudioForObject : MonoBehaviour
{
    private AudioSource audioSource { get { return GetComponent<AudioSource>(); } }
    public AudioClip[] audioClips;
    private int currentIndex = 0;

    void Start()
    {
        gameObject.AddComponent<AudioSource>();
        SetAudioClip(currentIndex);
        audioSource.playOnAwake = false;
        audioSource.volume = 0.3f;
    }

    public void PlayAudio(int index)
    {
        if (index < 0 || index >= audioClips.Length)
        {
            Debug.LogError("Invalid audio clip index: " + index);
            return;
        }
        SetAudioClip(index);
        audioSource.PlayOneShot(audioClips[index]);
    }

    private void SetAudioClip(int index)
    {
        currentIndex = index;
        audioSource.clip = audioClips[currentIndex];
    }
}
