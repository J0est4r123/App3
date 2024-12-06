using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;

    private void Start()
    {
        int selectedCharacter = StaticData.selectedCharacter;
        if (selectedCharacter >= 0 && selectedCharacter < characterPrefabs.Length)
        {
            Instantiate(characterPrefabs[selectedCharacter], Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid character selection!");
        }
    }
}
