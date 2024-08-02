using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMgr : MonoSingleton<CharacterMgr>
{
    public Character[] characters;

    private void Awake()
    {
        characters = Resources.LoadAll<Character>("Characters");
    }

    public Character GetCharacter(string characterName)
    {
        for(int i = 0; i < characters.Length; i++)
        {
            if (characters[i].characterName == characterName)
            {
                Character character = Instantiate(characters[i]);

                return character;
            }
        }
        return null;
        
    }
}
