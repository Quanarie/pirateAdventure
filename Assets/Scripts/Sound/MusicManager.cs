using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioSource[] musicTracks;
    private int currentTrack = 0;

    private void Start()
    {
        int number = Random.Range(0, musicTracks.Length);
        currentTrack = number;
        musicTracks[currentTrack].Play();

        SceneManager.sceneLoaded += RandomTrack;
    }

    public void RandomTrack(Scene scene, LoadSceneMode mode)
    {
        int number = Random.Range(0, musicTracks.Length);
        musicTracks[currentTrack].Stop();
        currentTrack = number;
        musicTracks[currentTrack].Play();
    }
}
