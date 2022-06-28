namespace SchemeLogical
{
    public class StateContainer
    {
        private string? savedString;
        private string? isOperand;
        private List<Item> currentItems;
        private bool allow_zone=false;
        private bool flag=false;
        private Item current=new();

        public bool AllowZone
        {
            get { return allow_zone; }
            set { allow_zone = value;
                NotifyStateChanged();
            }
        }
        public List<Item> CurrentItems
        {
            get { return currentItems; }
            set
            {
                currentItems = value;
                NotifyStateChanged();
            }
        }
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
