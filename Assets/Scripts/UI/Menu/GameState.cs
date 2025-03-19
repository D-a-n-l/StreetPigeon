public static class GameState
{
    public static bool State { get; private set; } = false;

    public static void Set(bool value) => State = value;
}