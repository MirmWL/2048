using System;
using UnityEngine;

public class NumberCubes : MonoBehaviour
{
    [SerializeField] private Cells _cells;
    [SerializeField] private NumberCube _prefab;
    [SerializeField] private Vector3 _offset;

    private NumberCubePool _pool;
    
    private void Start()
    {
        _pool = new NumberCubePool(_cells, _prefab, _offset);
        _pool.Create();
        
        OnEnable();
    }
    private void OnEnable()
    {
        if (_pool == null) return;
        
        foreach (var cube in _pool.Cubes)
            SubscribeToCube(cube);
    
        SubscribeToPool();
    }
    private void OnDisable()
    {
        foreach (var cube in _pool.Cubes)
            UnsubscribeFromCube(cube);
    
        UnsubscribeFromPool();
    }

    public void Init(PlayerInput input)
    {
        input.Swiped += OnSwiped;
    }
    
    private void SubscribeToPool()
    {
        _pool.Created += SubscribeToCube;
    }
    private void SubscribeToCube(NumberCube subscribeTarget)
    {
        subscribeTarget.CollidedWithOtherCube += (cube) => Combine(subscribeTarget, cube);
    }

    private void UnsubscribeFromPool()
    {
        _pool.Created -= SubscribeToCube;
    }
    private void UnsubscribeFromCube( NumberCube subscribeTarget)
    {
        subscribeTarget.CollidedWithOtherCube += (cube) => Combine(subscribeTarget, cube);
    }
    
    private void OnSwiped(SwipeType type)
    {
        Move(type);
        _pool.Create();
    }

    private void Combine(NumberCube cube1, NumberCube cube2)
    {
        if (cube1.Model.Number == cube2.Model.Number)
        {
            cube1.Movement.Jump();
            cube1.Model.Number += cube2.Model.Number;
            
            _pool.Remove(cube2);
        }
    }
    
    private void Move(SwipeType type)
    {
        var swipeDirection = new SwipeDirection(type).Get();
        
        foreach (var numberCube in _pool.Cubes)
            numberCube.Movement.Move(swipeDirection);
    }
}