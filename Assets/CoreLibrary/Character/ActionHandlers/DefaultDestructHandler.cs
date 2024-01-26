namespace CoreLibrary.Character
{
    public class DefaultDestructHandler : BaseActionHandler
    {
        public bool RequireRevive { get; set; }

        protected virtual void Awake()
        {
        }

        public void Destroy()
        {
            RequireRevive = false;
            Trigger();
        }

        public virtual void Revive()
        {
            RequireRevive = true;
        }
    }
}