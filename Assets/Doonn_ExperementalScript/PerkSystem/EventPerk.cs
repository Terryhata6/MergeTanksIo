using System;
using System.Collections.Generic;


public class EventPerk
{
    public static EventPerk Current = new EventPerk();

    public event Action<List<AbstractPerk>> CallEvent;

    private void Call(List<AbstractPerk> perks)
    {
        CallEvent?.Invoke(perks);
    }
}
