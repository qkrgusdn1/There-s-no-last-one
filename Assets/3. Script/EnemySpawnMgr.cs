using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnMgr : MonoBehaviour
{
    
}

[System.Serializable]
public class EnemyInfo
{
    public string name;

    public Enemy enemyPrefab;

    public CharacterGrade type;
}
