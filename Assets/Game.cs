using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private NumberCubes _cubes;
    private PlayerInput _input;

    private void Awake()
    {
        _input = new PlayerInput();
        StartCoroutine(_input.InputRoutine());
        
        _cubes.Init(_input);
    }
}