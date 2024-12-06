using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] characters; // All available characters
    [SerializeField] private Image[] characterSkins; // Visual representation of characters
    [SerializeField] private Button purchaseButton; // Button for purchasing characters
    [SerializeField] private Button selectButton; // Button for selecting characters
    [SerializeField] private int[] characterPrices; // Prices for each character
    [SerializeField] private Image[] buttons; // Button visuals for locked/unlocked

    private void Start()
    {
        UpdateUI();

        // Initialize character visuals based on unlock status
        for (int i = 0; i < characterSkins.Length; i++)
        {
            if (StaticData.IsCharacterUnlocked(i))
            {
                characterSkins[i].color = GetUnlockedColor(i);
                buttons[i].color = Color.white;
            }
            else
            {
                characterSkins[i].color = Color.black;
                buttons[i].color = Color.black;
            }
        }

        characters[StaticData.selectedCharacter].SetActive(true);
    }

    public void NavigateCharacter(int direction)
    {
        StaticData.selectedCharacter += direction;

        // Wrap around if index is out of bounds
        if (StaticData.selectedCharacter < 0)
        {
            StaticData.selectedCharacter = characters.Length - 1;
        }
        else if (StaticData.selectedCharacter >= characters.Length)
        {
            StaticData.selectedCharacter = 0;
        }

        UpdateUI();
    }

    public void PurchaseCharacter()
    {
        int selected = StaticData.selectedCharacter;

        if (!StaticData.IsCharacterUnlocked(selected) && StaticData.money >= characterPrices[selected])
        {
            StaticData.money -= characterPrices[selected];
            StaticData.UnlockCharacter(selected);
            Debug.Log($"Character {selected} unlocked!");
            PlayerPrefs.SetInt("money", StaticData.money);
            UpdateUI();
        }
        else
        {
            Debug.Log("Not enough currency or character already unlocked!");
        }
    }

    public void SelectCharacter()
    {
        int selected = StaticData.selectedCharacter;

        if (StaticData.IsCharacterUnlocked(selected))
        {
            StaticData.SetConfirmedCharacter(selected);
            Debug.Log($"Character {selected} selected!");
        }
        else
        {
            Debug.Log("Character is not unlocked and cannot be selected!");
        }
    }

    private void UpdateUI()
    {
        int selected = StaticData.selectedCharacter;

        // Update purchase button state
        purchaseButton.interactable = !StaticData.IsCharacterUnlocked(selected) && StaticData.money >= characterPrices[selected];

        // Update select button state
        selectButton.interactable = StaticData.IsCharacterUnlocked(selected);
    }

    private Color GetUnlockedColor(int index)
    {
        switch (index)
        {
            case 0: return new Color32(255, 255, 255, 255);
            case 1: return new Color32(226, 63, 63, 255);
            case 2: return new Color32(67, 174, 224, 255);
            case 3: return new Color32(222, 0, 245, 255);
            case 4: return new Color32(120, 4, 255, 255);
            default: return Color.white;
        }
    }
}
