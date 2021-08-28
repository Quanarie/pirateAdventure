using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

    }

    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public PlayerMovement player;

    public int pesos;
    public int experience;

    /*preferedSkin
     *pesos
     *experience
     *weaponLevel
     *vesselLevel
     */

    public void SaveState()
    {
        string s = "";

        s += "0" + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += "0" + "|";
        s += "0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        pesos = int.Parse(data[1]);
        experience = int.Parse(data[2]);
    }
}
