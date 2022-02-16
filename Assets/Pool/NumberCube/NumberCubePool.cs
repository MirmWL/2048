using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class NumberCubePool
{
    public event Action<NumberCube> Created;
    
    private readonly Cells _cells;
    private readonly Vector3 _offset;
    private readonly NumberCube _prefab;
    private readonly List<NumberCube> _cubes;
    
    public NumberCubePool(Cells cells, NumberCube prefab, Vector3 offset)
    {
        _cells = cells;
        _prefab = prefab;
        _offset = offset;

        _cubes = new List<NumberCube>();
    }

    public IReadOnlyList<NumberCube> Cubes => _cubes;

    public void Create()
    {
        Vector3 spawnPosition = _cells.GetRandom().transform.position + _offset;
        var cube = Object.Instantiate(_prefab, spawnPosition, Quaternion.identity);
        
        _cubes.Add(cube);
        
        Created?.Invoke(cube);
    }
    
    public void Remove(NumberCube item)
    {
        _cubes.Remove(item);
        Object.Destroy(item.gameObject);
    }
}