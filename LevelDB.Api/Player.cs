using ZeroFormatter;

namespace LevelDB.Api
{
    [ZeroFormattable]
    public class Player
    {
        public Player()
        {
        }

        public Player(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Index(0)] public virtual string FirstName { get; set; }
        [Index(1)] public virtual string LastName { get; set; }
    }
}