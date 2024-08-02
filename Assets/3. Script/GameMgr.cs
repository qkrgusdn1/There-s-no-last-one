using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class GameMgr : MonoSingleton<GameMgr>
{
    public void SpawnCharacter(string characterName)
    {
        if (TileMgr.Instance == null)
        {
            Debug.LogError("TileMgr instance is null!");
            return;
        }

        if (CharacterMgr.Instance == null)
        {
            Debug.LogError("CharacterMgr instance is null!");
            return;
        }

        Tile tile = TileMgr.Instance.GetTile(characterName);
        if (tile == null)
        {
            Debug.LogWarning("Tile is null for character: " + characterName);
            return;
        }

        Character character = CharacterMgr.Instance.GetCharacter(characterName);
        if (character == null)
        {
            Debug.LogWarning("Character is null for character name: " + characterName);
            return;
        }

        tile.AddCharacter(character);
    }
}
