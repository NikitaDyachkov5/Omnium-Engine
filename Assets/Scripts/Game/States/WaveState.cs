using System;

public class WaveState
{
    public bool IsFight { get; private set; }
    public bool IsBreak {  get; private set; }

    public event Action FightChanged;
    public event Action BreakChanged;

    public void BreakTime()
    {
        IsFight = false;
        IsBreak = true;
        BreakChanged?.Invoke();
    }

    public void FightTime()
    {
        IsFight = true;
        IsBreak = false;
        FightChanged?.Invoke();
    }
}

/*
 НА БУДУЩЕЕ
 */