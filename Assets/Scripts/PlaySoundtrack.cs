using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundtrack : MonoBehaviour
{
    private AudioSource audioSource;
    private CrashDetector crashDetector;
    private FinishLine finishLine;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
        
        // Get the CrashDetector and FinishLine components
        crashDetector = GetComponent<CrashDetector>();
        finishLine = GetComponent<FinishLine>();

        // Start playing the audio if it's not already playing
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    void Update()
    {
        // Check if the player has crashed or finished
        if (crashDetector != null && crashDetector.gethasCrashed() ||
            finishLine != null && finishLine.gethasFinished())
        {
            // Restart the audio
            if (audioSource != null)
            {
                audioSource.Stop();
                audioSource.Play();
            }
        }
    }
}
