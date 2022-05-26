public class ProjectContext : Singleton<ProjectContext>
{
    public PauseManager PauseManager { get; private set; }

    private void Awake()
    {
        PauseManager = new PauseManager();
    }

    private void OnApplicationFocus(bool focus)
    {
        PauseManager.SetPause(!focus);
    }

    private void OnApplicationPause(bool pause)
    {
        PauseManager.SetPause(!pause);
    }
}
