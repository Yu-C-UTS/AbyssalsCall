using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    [SerializeField] private AudioSource bgMusic;
    // Start is called before the first frame update
    void Start()
    {
        bgMusic.Play();
    }
}
