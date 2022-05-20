using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using System;
using UnityEngine.EventSystems;

public class SplineMoveController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private List<PathCreator> splines = new List<PathCreator>();
    [SerializeField] private float moveSpeed;
    private LinkedList<PathCreator> _splinesList;
    private float _moveDistance;

    public PathCreator CurrentSpline { get; private set; }
    public float MoveSpeed { get => moveSpeed; }
    private bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

    private void Awake()
    {
        ProjectContext.Instance.PauseManager.Register(this);
    }

    private void Start()
    {
        _splinesList = new LinkedList<PathCreator>(splines);
        CurrentSpline = _splinesList.First.Next.Value;
    }

    private void Update()
    {
        if (IsPaused)
            return;

        Move();
        TouchInput();

        if (Input.GetKeyUp(KeyCode.A))
        {
            StrafeLeft();
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            StrafeRight();
        }
    }

    public void Move()
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

    public void TouchInput()
    {
        if (Input.touchCount > 0 && !EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
        {
            var touch = Input.GetTouch(0);
            if (touch.position.x < Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                StrafeLeft();
            }
            else if (touch.position.x > Screen.width / 2 && touch.phase == TouchPhase.Began)
            {
                StrafeRight();
            }
        }
    }

    public void SetPause(bool isPaused)
    {
        
    }
}
