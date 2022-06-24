namespace SchemeLogical
{
    public class StateContainer
    {
        private string? savedString;
        private string? isOperand;
        private bool flag=false;
        private Item current=new();

        public string Property
        {
            get => savedString ?? string.Empty;
            set
            {
                savedString = value;
                NotifyStateChanged();
            }
        }
        public string? PropertyOperand
        {
            get=>isOperand ?? string.Empty;
            set
            {
                isOperand = value;
                NotifyStateChanged();
            }
        }
        public bool Flag
        {
            get => flag;
            set 
            { 
                flag = value; 
                NotifyStateChanged(); 
            }

        }
        public Item Current
        {
            get => current;
            set { current = value;
                NotifyStateChanged();
            }
        }
        public event Action? OnChange;

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
