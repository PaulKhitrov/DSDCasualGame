using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class SplineMoveController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private List<PathCreator> splines = new List<PathCreator>();
    [SerializeField] private float moveSpeed;

    private LinkedList<PathCreator> _splinesList;
    private float _moveDistance = 0.0f;

    public PathCreator CurrentSpline { get; private set; }
    private PauseManager PauseManager => ProjectContext.Instance.PauseManager;

    private void Awake()
    {
        _splinesList = new LinkedList<PathCreator>(splines);
        SetStartSettngs();
        PauseManager.Register(this);
    }

    private void OnDestroy()
    {
        PauseManager.UnRegister(this);
    }

    private void Update()
    {
        Move();
    }

    public void SetStartSettngs()
    {
        _moveDistance = 0.0f;
        CurrentSpline = _splinesList.First.Next.Value;
        enabled = false;
    }

    private void Move()
    {
        _moveDistance += moveSpeed * Time.deltaTime;
        transform.position = CurrentSpline.path.GetPointAtDistance(_moveDistance);
    }

    private void SetCurrentSpline(PathCreator line)
    {
        if (line != null)
        {
            CurrentSpline = line;
        }
    }

    public void StrafeLeft()
    {
        SetCurrentSpline(_splinesList.Find(CurrentSpline).Previous?.Value);
    }

    public void StrafeRight()
    {
        SetCurrentSpline(_splinesList.Find(CurrentSpline).Next?.Value);
    }

    public void SetPause(bool isPaused)
    {
        enabled = !isPaused;
    }
}
