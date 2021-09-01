using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMenu : MonoBehaviour
{
    public Text levelText, hitpointText, pesosText, upgradeCostText, xpText;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public Image weaponSprite;
    public RectTransform xpBar;

    public void OnArrowClick(bool isRight)
    {
        if (isRight)
        {
            currentCharacterSelection++;

            if (currentCharacterSelection == GameManager.Instance.playerSprites.Count)
            {
                currentCharacterSelection = 0;
            }

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;

            if (currentCharacterSelection < 0)
            {
                currentCharacterSelection = GameManager.Instance.playerSprites.Count - 1;
            }

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.Instance.playerSprites[currentCharacterSelection];
        GameManager.Instance.player.SwapSprite(currentCharacterSelection);
    }

    public void OnUpgradeClick()
    {
        if (GameManager.Instance.TryUpgradeWeapon())
        {
            UpdateMenu();
        }
    }

    public void UpdateMenu()
    {
        weaponSprite.sprite = GameManager.Instance.weaponSprites[GameManager.Instance.weapon.weaponLevel];
        if (GameManager.Instance.weapon.weaponLevel == GameManager.Instance.weaponPrices.Count)
        {
            upgradeCostText.text = "MAX";
        }
        else
        {
            upgradeCostText.text = GameManager.Instance.weaponPrices[GameManager.Instance.weapon.weaponLevel].ToString();
        }

        levelText.text = GameManager.Instance.GetCurrentLevel().ToString();
        hitpointText.text = GameManager.Instance.player.hitpoint.ToString();
        pesosText.text = GameManager.Instance.pesos.ToString();


        int currLevel = GameManager.Instance.GetCurrentLevel();
        if (currLevel == GameManager.Instance.xpTable.Count) 
        {
            xpText.text = GameManager.Instance.experience.ToString() + " total xp";
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int prevLvlXp = GameManager.Instance.GetXpToLevel(currLevel - 1);
            int currLvlXp = GameManager.Instance.GetXpToLevel(currLevel);

            int diff = currLvlXp - prevLvlXp;
            int currXpIntoLevel = GameManager.Instance.experience - prevLvlXp;

            float completionRatio = (float)currXpIntoLevel / (float)diff;

            xpText.text = currXpIntoLevel.ToString() + " / " + diff;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
        }
    }
}
