using System.Collections.Generic;
using UnityEngine;
using PathCreation;
using UnityEngine.EventSystems;

public class SplineMoveController : MonoBehaviour, IPauseHandler
{
    [SerializeField] private List<PathCreator> splines = new List<PathCreator>();
    [SerializeField] private float moveSpeed;
    private LinkedList<PathCreator> _splinesList;
    private float _moveDistance = 0.0f;

    public PathCreator CurrentSpline { get; private set; }

    private void Awake()
    {
        _splinesList = new LinkedList<PathCreator>(splines);
        SetStartSettngs();
        ProjectContext.Instance.PauseManager.Register(this);
    }

    private void OnDestroy()
    {
        ProjectContext.Instance.PauseManager.UnRegister(this);
    }

    private void Update()
    {
        Move();

        ////////////////////////планирую это отсюда вынести, в будущем
        TouchInput();

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            StrafeLeft();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            StrafeRight();
        }
        ///////////////////////
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
        enabled = !isPaused;
    }
}
