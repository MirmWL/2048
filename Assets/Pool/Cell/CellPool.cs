using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class CellPool
{
    private readonly CellSpawnPositions _cellSpawnPositions;
    private readonly Cell _prefab;
    private readonly List<Cell> _cells;
    
    public CellPool(Cell prefab, Transform gameFieldTransform, float offset)
    {
        _prefab = prefab;
        
        _cells = new List<Cell>();
        _cellSpawnPositions = new CellSpawnPositions(gameFieldTransform, offset, prefab.transform);
    }

    public IReadOnlyList<Cell> Cells => _cells;

    public void Create()
    {
        foreach (Vector3 spawnPosition in _cellSpawnPositions.SpawnPositions)
        {
            Quaternion rotation = _prefab.transform.rotation;
            var cell = Object.Instantiate(_prefab, spawnPosition, rotation);
            
            _cells.Add(cell);
        }
    }
}
