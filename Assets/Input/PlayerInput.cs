using System;
using System.Collections;

public class PlayerInput
{
    public event Action<SwipeType> Swiped;
    private readonly Swipe _swipe;

    public PlayerInput()
    {
        _swipe = new Swipe();
    }

    public IEnumerator InputRoutine()
    {
        while (true)
        {
            yield return null;

            SwipeType swipeType = _swipe.GetSwipeType();
            
            if (swipeType != SwipeType.None)
                Swiped?.Invoke(swipeType);
        }
    }
}