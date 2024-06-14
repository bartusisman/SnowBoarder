using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float delayNum = 1;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    bool hasCrashed = false;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();

            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            
            Invoke("LoadScene", delayNum);
            Debug.Log("You just hit me and i hit my head!");           
        }
        
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }

    public bool gethasCrashed()
    {
        return hasCrashed;
    }
}
