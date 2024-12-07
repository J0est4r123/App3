using UnityEngine;
using System;
using System.Collections.Generic;

public class StaticData : MonoBehaviour
{
    public static double score;
    public static double[] scores = new double[10];
    public static string[] names = new string[10];
    public static bool[] unlockedCharacters = new bool[5];
    public static int selectedCharacter = 0;
    public static int confirmedCharacter = 0;
    public static int money = 0;
    public static List<Vector3> position = new List<Vector3>();
    public static List<Vector3> scale = new List<Vector3>();
    public static List<int> level = new List<int>();
    public static List<float> frameTimes = new List<float>();
    public static bool inReplay;
    public static int replayFrame;
    public static int currentLevelReplayFrameStart;

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
            unlockedCharacters[0] = true;

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
            money = 0; // Default starting currency
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

    public static void SetConfirmedCharacter(int index)
    {
        confirmedCharacter = index;
        PlayerPrefs.SetInt("confirmedCharacter", confirmedCharacter);
    }
    public static Color GetUnlockedColor(int index)
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
