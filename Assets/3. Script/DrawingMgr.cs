using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingMgr : MonoBehaviour
{
    public List<CharacterInfo> characters = new List<CharacterInfo>();
    public Image characterthum;

    public void OnClickedDrawingButton()
    {
        Debug.Log("OnClickedDrawingButton");
        CharacterInfo drawnCharacter = DrawCharacter();
        characterthum.sprite = drawnCharacter.thum;
    }

    public CharacterInfo DrawCharacter()
    {
        float rareProbability = 0.2f;
        float uniqueProbability = 0.05f;

        float random = Random.Range(0f, 1f);

        CharacterType selectedType;
        if (random < uniqueProbability)
        {
            selectedType = CharacterType.unique;
        }
        else if (random < uniqueProbability + rareProbability)
        {
            selectedType = CharacterType.rare;
        }
        else
        {
            Debug.Log("ss");
            selectedType = CharacterType.normal;
        }

        List<CharacterInfo> filteredCharacters = characters.FindAll(character => character.type == selectedType);
        return filteredCharacters[Random.Range(0, filteredCharacters.Count)];
    }
}

[System.Serializable]
public class CharacterInfo
{
    public string name;

    public Sprite thum;

    public CharacterType type;

}

public enum CharacterType
{
    normal,
    rare,
    unique
}
