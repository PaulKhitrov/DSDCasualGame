using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectContext : Singleton<ProjectContext>
{
    public PauseManager PauseManager { get; private set; }

    private void Awake()
    {
        PauseManager = new PauseManager();
    }
}
