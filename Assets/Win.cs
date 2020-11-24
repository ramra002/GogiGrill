using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    private AudioSource WinSound;
    // Start is called before the first frame update
    void Start()
    {
		WinSound = GetComponents<AudioSource>()[0];
        WinSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
