using Utils;

public enum PlayerType
{
    None,
    Fire,
    Water
}

namespace Features.Entities
{

    public abstract class Player
    {
        public abstract PlayerType Type { get; }
    }

}
