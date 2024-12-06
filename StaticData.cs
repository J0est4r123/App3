using UnityEngine;
using System;

public class StaticData : MonoBehaviour
{
    public static double score;
    public static double[] scores = new double[10];
    public static string[] names = new string[10];
    public static bool[] unlockedCharacters = new bool[5];
    public static int selectedCharacter = 0;
    public static int confirmedCharacter = 0;
    public static int money = 0;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("init") == 1)
        {
            // Load data from PlayerPrefs
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = Convert.ToDouble(PlayerPrefs.GetString($"score{i}", "35999.99"));
            }

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = PlayerPrefs.GetString($"name{i}", "N/A");
            }

            for (int i = 0; i < unlockedCharacters.Length; i++)
            {
                unlockedCharacters[i] = PlayerPrefs.GetInt($"characterUnlocked_{i}", 0) == 1;
            }

            selectedCharacter = PlayerPrefs.GetInt("selectedCharacter", 0);
            confirmedCharacter = PlayerPrefs.GetInt("confirmedCharacter", 0);
            money = PlayerPrefs.GetInt("money", 0);
        }
        else
        {
            // Initialize default data
            for (int i = 0; i < scores.Length; i++)
            {
                PlayerPrefs.SetString($"score{i}", "35999.99");
                scores[i] = 35999.99;
            }

            for (int i = 0; i < names.Length; i++)
            {
                PlayerPrefs.SetString($"name{i}", "N/A");
                names[i] = "N/A";
            }

            // Unlock the first character by default
            for (int i = 0; i < unlockedCharacters.Length; i++)
            {
                unlockedCharacters[i] = (i == 0);
                PlayerPrefs.SetInt($"characterUnlocked_{i}", i == 0 ? 1 : 0);
            }

            selectedCharacter = 0;
            confirmedCharacter = 0;
            money = 100; // Default starting currency
            PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
            PlayerPrefs.SetInt("confirmedCharacter", confirmedCharacter);
            PlayerPrefs.SetInt("money", money);

            PlayerPrefs.SetInt("init", 1);
        }
    }

    public static void UnlockCharacter(int index)
    {
        if (index >= 0 && index < unlockedCharacters.Length)
        {
            unlockedCharacters[index] = true;
            PlayerPrefs.SetInt($"characterUnlocked_{index}", 1);
        }
    }

    public static bool IsCharacterUnlocked(int index)
    {
        return index >= 0 && index < unlockedCharacters.Length && unlockedCharacters[index];
    }

    public static void SetSelectedCharacter(int index)
    {
        selectedCharacter = index;
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
    }

    public static void SetConfirmedCharacter(int index)
    {
        confirmedCharacter = index;
        PlayerPrefs.SetInt("confirmedCharacter", confirmedCharacter);
    }
}
