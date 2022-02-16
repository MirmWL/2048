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

            if (_swipe.GetSwipeType() != SwipeType.None)
                Swiped?.Invoke(_swipe.GetSwipeType());
        }
    }
}