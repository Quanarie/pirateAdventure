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
                currentCharacterSelection = GameManager.Instance.playerSprites.Count;
            }

            OnSelectionChanged();
        }
    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.Instance.playerSprites[currentCharacterSelection];
    }

    public void OnUpgradeClick()
    {

    }

    public void UpdateMenu()
    {
        //weaponSprite.sprite = 
        //uprgadeCostText.text = 

        //levelText.text = 
        hitpointText.text = GameManager.Instance.player.hitpoint.ToString();
        pesosText.text = GameManager.Instance.pesos.ToString();

        //xpText.text = 
    }
}
