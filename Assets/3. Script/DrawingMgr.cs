using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawingMgr : MonoSingleton<DrawingMgr>
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

        CharacterGrade selectedType;
        if (random < uniqueProbability)
        {
            selectedType = CharacterGrade.unique;
        }
        else if (random < uniqueProbability + rareProbability)
        {
            selectedType = CharacterGrade.rare;
        }
        else
        {
            Debug.Log("ss");
            selectedType = CharacterGrade.normal;
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

    public CharacterGrade type;

}

public enum CharacterGrade
{
    normal,
    rare,
    unique
}
