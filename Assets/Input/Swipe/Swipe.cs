using UnityEngine;

public class Swipe
{
    private Vector3 _startPosition;
    private Vector3 _endPosition;
    private Vector3 _swipePosition;

    public SwipeType GetSwipeType()
    {
        var swipeType = SwipeType.None;
        _swipePosition = Vector3.zero;

        if (Input.GetMouseButtonDown(0))
            _startPosition = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            _endPosition = Input.mousePosition;
            _swipePosition = _endPosition - _startPosition;
        }
       
        _swipePosition.Normalize();
        
        if (_swipePosition.x > 0 && _swipePosition.y > -0.5f && _swipePosition.y < 0.5f)
            swipeType = SwipeType.Right;
        if (_swipePosition.x < 0 && _swipePosition.y > -0.5f && _swipePosition.y < 0.5f)
            swipeType = SwipeType.Left;
        if (_swipePosition.y > 0 && _swipePosition.x > -0.5f && _swipePosition.x < 0.5f)
            swipeType = SwipeType.Up;
        if (_swipePosition.y < 0 && _swipePosition.x > -0.5f && _swipePosition.x < 0.5f)
            swipeType = SwipeType.Down;

        return swipeType;
    }    
}

