using System;

namespace Game
{
    public delegate void ValueChangedDelegate<in T1, in T2>(T1 previous, T2 current);
    
    public interface IReadOnlyObservableProperty<out T>
    {
        T Value { get; }

        event ValueChangedDelegate<T, T> ValueChanged;
    }
}