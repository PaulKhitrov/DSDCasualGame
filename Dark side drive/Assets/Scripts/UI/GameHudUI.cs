using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHudUI : MonoBehaviour
{
    public void OnClickTogglePause(bool isPaused)
    {
        ProjectContext.Instance.PauseManager.SetPause(isPaused);
    }

    public void OnClickExit()
    {
        
    }
}

