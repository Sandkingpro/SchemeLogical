namespace SchemeLogical
{
    public class StateContainer
    {
        private string? savedString;
        private string? isOperand;
        private List<Item> currentItems;
        private Pages.Index parent;
        private bool flag=false;
        private Item current=new();

        public Pages.Index Parent
        {
            get
            { return parent; }
            set
            {
                parent = value;
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
