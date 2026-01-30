internal sealed class ReloadMameGameCommand : IBridgeCommand
{
   private readonly Wrapper _wrapper;
   private readonly string _gameDirectory;
   private readonly string[] _gameNames;
   public ReloadMameGameCommand(
       Wrapper wrapper,
       string gameDirectory,
       string[] gameNames)
   {
       _wrapper = wrapper;
       _gameDirectory = gameDirectory;
       _gameNames = gameNames;
   }
   public void Execute()
   {
       _wrapper.StopGameOnly();
       _wrapper.LoadGameOnly(_gameDirectory, _gameNames);
       // ALWAYS do this after retro_load_game
       _wrapper.InitGraphics();
   }
}