using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    private AudioSource LoseSound;

    // Start is called before the first frame update
    void Start()
    {
        LoseSound = GetComponents<AudioSource>()[0];
        LoseSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
