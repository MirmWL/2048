using UnityEngine;

public class Cells : MonoBehaviour
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private Transform _gameFieldTransform;
    [SerializeField] private float _offset;
    
    private CellPool _pool;

    private void Awake()
    {
        _pool = new CellPool(_prefab, _gameFieldTransform, _offset);
        _pool.Create();
    }

    public Cell GetRandom()
    {
        Cell random = _pool.Cells[Random.Range(0, _pool.Cells.Count)]; 
        return random;
    }
}