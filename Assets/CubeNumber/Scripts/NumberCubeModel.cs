using System;

public class NumberCubeModel
{
    public event Action<int> Changed;

    private int _number;

    public NumberCubeModel(int number = 2)
    {
        Number = number;
    }

    public int Number
    {
        get => _number;
        set
        {
            _number = value;
            Changed?.Invoke(value);
        }
    }
}