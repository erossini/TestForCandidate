namespace HorseRaceEmu.Commands.Abstractions
{
    public abstract class ConsoleCommand<TContext>
    {
        public ConsoleCommand(HotKey key, string description)
        {
            Key = key;
            Description = description;
        }

        public HotKey Key { get; }
        public string Description { get; }

        protected abstract void Body(TContext context);
        public abstract bool CanRun(TContext context);

        public void Run(TContext context)
        {
            Body(context);
        }

        public override string ToString()
        {
            return $"[ {Key} ] {Description}";
        }
    }
}