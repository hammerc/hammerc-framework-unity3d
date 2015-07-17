using System;

public class MoveYEventArgs : EventArgs
{
    private float _y;

    public MoveYEventArgs(float y)
    {
        _y = y;
    }

    public float y
    {
        get { return _y; }
    }
}
