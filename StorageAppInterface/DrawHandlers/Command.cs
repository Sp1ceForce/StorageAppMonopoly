using System;

namespace StorageAppInterface.DrawHandlers
{
    public class Command
    {
        public event Action OnCommandTrigger;
        public Command(string description) 
        { 
            CommandDescription = description;
        }
        public string CommandDescription { get; private set; }
        public void Activate()
        {
            OnCommandTrigger?.Invoke();
        }
        
    }
}
