using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] Sfx;

    public AudioSource level1Music, gameOverMusic, winMusic;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver()
    {
        level1Music.Stop();
        gameOverMusic.Play();
    }

    public void PlayLevelWin()
    {
        level1Music.Stop();
        winMusic.Play();     
    }

    public void PlaySFX(int sfxToPlay)
    {
        Sfx[sfxToPlay].Stop();
        Sfx[sfxToPlay].Play();
    }
}
