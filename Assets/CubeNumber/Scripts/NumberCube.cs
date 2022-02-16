using System;

using UnityEngine;

[RequireComponent(typeof(NumberCubeMovement))]
public class NumberCube : MonoBehaviour
{ 
    public event Action<NumberCube> CollidedWithOtherCube;
 
    [SerializeField] private NumberCubeView _view;

    public NumberCubeMovement Movement;
    public NumberCubeModel Model;
    
    private void Awake()
    {
        Model = new NumberCubeModel();
        _view.Init(Model);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out NumberCube cube))
            CollidedWithOtherCube?.Invoke(cube);
    }
}