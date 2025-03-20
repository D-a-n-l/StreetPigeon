public static class GameState
{
    public static bool IsGame { get; private set; } = false;

    public static void Set(bool value) => IsGame = value;
}