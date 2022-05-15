namespace Game
{
    public sealed class ObservableProperty<T> : IReadOnlyObservableProperty<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value))
                {
                    return;
                }

                var previous = _value;
                _value = value;
                ValueChanged?.Invoke(previous, value);
            }
        }
        
        public event ValueChangedDelegate<T, T> ValueChanged;

        public ObservableProperty(T value = default)
        {
            _value = value;
        }
    }
}