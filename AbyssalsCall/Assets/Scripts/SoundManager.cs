using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource bgm;
    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
    }

 
}
