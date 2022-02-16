using UnityEngine;

public class SwipeDirection 
{
    private readonly SwipeType _type;

    public SwipeDirection(SwipeType type)
    {
        _type = type;
    }

    public Vector2 Get()
    {
        var direction = Vector3.zero;
        
        switch (_type)
        {
            case SwipeType.Down:
                direction = Vector3.down;
                break;
            case SwipeType.Left:
                direction = Vector3.left;
                break;
            case SwipeType.Right:
                direction = Vector3.right;
                break;
            case SwipeType.Up: 
                direction = Vector3.up;
                break;
        }

        return direction;
    }
}