using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChanger : MonoBehaviour
{
    [SerializeField] private int maxModifier;

    private float maxValue;
    private float player_attack;
    private float player_hurt;
    private float player_swoosh;
    private float[] bgTracks;

    private void Start()
    {
        maxValue = GetComponent<Slider>().maxValue;

        player_attack = GameManager.Instance.sfxManager.player_attack.volume;
        player_hurt = GameManager.Instance.sfxManager.player_hurt.volume;
        player_swoosh = GameManager.Instance.sfxManager.player_swoosh.volume;

        bgTracks = new float[GameManager.Instance.musicManager.musicTracks.Length];

        for (int i = 0; i < bgTracks.Length; i++)
        {
            bgTracks[i] = GameManager.Instance.musicManager.musicTracks[i].volume;
        }
    }
    public void SetSound(float soundModifier)
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.sfxManager.player_attack.volume = player_attack * soundModifier * maxModifier / maxValue;
            GameManager.Instance.sfxManager.player_hurt.volume = player_hurt * soundModifier * maxModifier / maxValue;
            GameManager.Instance.sfxManager.player_swoosh.volume = player_swoosh * soundModifier * maxModifier / maxValue;

            for (int i = 0; i < bgTracks.Length; i++)
            {
                GameManager.Instance.musicManager.musicTracks[i].volume = bgTracks[i] * soundModifier * maxModifier / maxValue;
            }

        }
    }
}
