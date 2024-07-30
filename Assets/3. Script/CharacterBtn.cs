using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterBtn : MonoBehaviour
{
    public Character character;
    public CharacterType characterType;

    public string characterName;
    public void OnClickedCharacterBtn()
    {
        for (int i = 0; i < TileMgr.Instance.tiles.Count; i++)
        {
            Tile tile = TileMgr.Instance.tiles[i];
            if (tile.characterName == "" && tile.characterCount < Tile.characterMaxCount)
            {
                tile.characterName = characterName;
                tile.characterCount++;
                Character spawnCharacter = Instantiate(character);
                spawnCharacter.transform.position = tile.transform.position;
                break;
            }else if(tile.characterName == characterName && tile.characterCount < Tile.characterMaxCount)
            {
                tile.characterCount++;
                Character spawnCharacter = Instantiate(character);
                spawnCharacter.transform.position = tile.transform.position;
                break;
            }
        }
    }
}
