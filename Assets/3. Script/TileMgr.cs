using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class TileMgr : MonoSingleton<TileMgr>
{
    public Vector2Int size;
    public Tile tilePrefab;
    public float gap;

    [HideInInspector]
    public List<Tile> tiles = new List<Tile>();

    private void Start()
    {
        CreateTile();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            CreateTile();
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            for(int i = 0; i < tiles.Count; i++)
            {
                tiles[i].gameObject.SetActive(false);
            }
            
        }
    }
    public Tile GetEmptyTile()
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].characterList.Count > 0)
            {
                continue;
            }

            return tiles[i];
        }
        return null;
    }

    public Tile GetTile(string characterName)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            if (tiles[i].characterList.Count >= Tile.characterMaxCount)
                continue;
            if(tiles[i].characterList.Count > 0)
            {
                if(tiles[i].characterList[0].characterName != characterName)
                {
                    continue;
                }
            }
            return tiles[i];
        }
        return null;
    }


    void CreateTile()
    {
        int x = size.x;
        int y = size.y;

        float initX = ((size.x - 1) / 2) * -gap;
        float initY = ((size.y - 1) / 2) * -gap;

        Vector2 targetPos = new Vector2(initX, initY);

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                Tile tile = GetTileInPooling();
                tile.index = new Vector2Int(i, j);
                tile.transform.position = targetPos;
                targetPos.y += gap;
            }
            targetPos.x += gap;
            targetPos.y = initY;
        }
    }

    Tile GetTileInPooling()
    {
        for(int i = 0; i < tiles.Count; i++)
        {
            if (!tiles[i].gameObject.activeSelf)
            {
                tiles[i].gameObject.SetActive(true);
                return tiles[i];
            }
        }
        Tile tile = Instantiate(tilePrefab);
        tiles.Add(tile);
        return tile;
    }

}

