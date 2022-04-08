namespace Engine.Scenes
{
    // TODO This should be an abstract class
    public interface IScene : IEngineComponent
    {
        IScene NextScene { get; }
        SceneState State { get; }
    }
    
}
