using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            Destroy(player.gameObject);
            Destroy(floatingTextManager.gameObject);
            Destroy(hud);
            Destroy(menu);
            return;
        }

        Instance = this;
        SceneManager.sceneLoaded += LoadState;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public List<Sprite> playerSprites;
    public List<RuntimeAnimatorController> playerAnimators;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    public Player player;
    public Weapon weapon;
    public FloatingTextManager floatingTextManager;
    public RectTransform hitpointBar;
    public GameObject hud;
    public GameObject menu;
    public Animator deathMenuAnimator;
    public Animator travelMenuAnimator;
    public QuestManager questManager;
    public CharacterMenu characterMenu;
    [HideInInspector] public string LastSceneName;

    public TradeOffer tradeOffer;
    public Text priceText;

    public SFXManager sfxManager;
    public MusicManager musicManager;

    public GameObject dialogueBox;
    public Text dialogueText;

    public int pesos;
    public int experience;
    public int shipLevel;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public bool TryUpgradeWeapon()
    {
        if (weapon.weaponLevel >= weaponPrices.Count)
            return false;

        if (pesos >= weaponPrices[weapon.weaponLevel])
        {
            pesos -= weaponPrices[weapon.weaponLevel];
            weapon.UpgradeWeapon();
            return true;
        }

        return false;
    }

    public void OnHitpointChange()
    {
        float ratio = (float)player.hitpoint / (float)player.maxHitpoint;
        hitpointBar.localScale = new Vector3(1, ratio, 1);
    }

    public int GetCurrentLevel()
    {
        int r = 0;
        int add = 0;

        while (experience >= add)
        {
            add += xpTable[r];
            r++;

            if (r == xpTable.Count) return r;
        }
        return r;
    }
    public int GetXpToLevel(int level)
    {
        int r = 0;
        int xp = 0;

        while (r < level)
        {
            xp += xpTable[r];
            r++;
        }

        return xp;
    }
    public void GrantXp(int xp)
    {
        int currLevel = GetCurrentLevel();
        experience += xp;
        if (currLevel < GetCurrentLevel())
        {
            OnLevelUp();
        }

        GameManager.Instance.ShowText("+ " + xp + " xp", 30, Color.red, player.transform.position, Vector3.up * 40, 1f);
    }
    public void GrantPesos(int value)
    {
        pesos += value;
        ShowText("+ " + value + " pesos", 25, Color.green, player.transform.position, Vector3.up * 25, 1f);
    }
    public void OnLevelUp()
    {
        player.OnLevelUp();
        OnHitpointChange();
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");

        if (spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
        }
    }

    public void Respawn()
    {
        deathMenuAnimator.SetTrigger("hide");
        SceneManager.LoadScene("MainScene");
        player.Respawn();
    }

    /*preferedSkin
     *pesos
     *experience
     *weaponLevel
     *vesselLevel
     *currentMainQuest
     */

    public void SaveState()
    {
        string s = "";

        s += characterMenu.currentCharacterSelection.ToString() + "|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s += weapon.weaponLevel.ToString() + "|";
        s += "0" + "|";
        s += QuestManager.Instance.GetCurrentMainQuest().ToString();

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= LoadState;

        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        characterMenu.currentCharacterSelection = int.Parse(data[0]);

        pesos = int.Parse(data[1]);

        experience = int.Parse(data[2]);
        if (GetCurrentLevel() != 1)
            player.SetLevel(GetCurrentLevel());

        weapon.SetLevelWeapon(int.Parse(data[3]));

        questManager.SetCurrentMainQuest(int.Parse(data[5]));

        characterMenu.OnSelectionChanged();
    }
}
