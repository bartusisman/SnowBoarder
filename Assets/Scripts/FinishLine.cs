using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float delayNum = 1;
    [SerializeField] ParticleSystem finishEffect;

    bool hasFinished = false;
    
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player" && hasFinished == false)
        {
            hasFinished = true;

            finishEffect.Play();
            GetComponent<AudioSource>().Play();

            Invoke("ReloadScene", delayNum); 
            Debug.Log("You Won!");
        }
    }


    void ReloadScene()
    {
         SceneManager.LoadScene(0);
    }

    public bool gethasFinished()
    {
        return hasFinished;
    }
}
