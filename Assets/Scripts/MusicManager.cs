using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = IntroMusic;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!IntroOver && Time.timeSinceLevelLoad > IntroLength)
        {
            audioSource.clip = NormalBGMusic;
            audioSource.Play();
            IntroOver = true;
        }
    }

    private AudioSource audioSource;

    [SerializeField]
    private AudioClip IntroMusic;

    private float IntroLength = 4.2f;

    [SerializeField]
    private AudioClip NormalBGMusic;

    private bool IntroOver = false;
}
