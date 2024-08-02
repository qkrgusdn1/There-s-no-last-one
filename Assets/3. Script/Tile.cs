using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int index;

    public string characterName;

    public const int characterMaxCount = 3;
    public List<Character> characterList = new List<Character>();

    public bool AddCharacter(Character character)
    {
        if (characterList.Count >= characterMaxCount)
            return false;

        characterList.Add(character);
        character.transform.position = transform.position;
        return true;
        
    }

}
