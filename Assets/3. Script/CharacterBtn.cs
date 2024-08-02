using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterBtn : MonoBehaviour
{
    public void OnClickedCharacterBtn()
    {
        Tile tile = TileMgr.Instance.GetEmptyTile();
        if (tile == null)
        {
            return;
        }
        CharacterInfo characterInfo =  DrawingMgr.Instance.DrawCharacter();
        GameMgr.Instance.SpawnCharacter(characterInfo.name);
        
    }
}
