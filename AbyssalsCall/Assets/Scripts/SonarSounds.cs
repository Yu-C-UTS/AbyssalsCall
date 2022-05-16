using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarSounds : MonoBehaviour
{
    [SerializeField] AudioSource sonarSfx;

    void Start()
    {
        sonarSfx.Play();
        Invoke("playAudio", 5.0f);
    }

    void playAudio() 
    {
        sonarSfx.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
