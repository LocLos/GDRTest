using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private int _speed;
    [SerializeField]
    private LineRenderer lineRenderer;

    private PlayerInput _playerInput;
    Queue<Vector2> targetsPos = new Queue<Vector2>();

    public void Construct(PlayerInput playerInput) =>
        _playerInput = playerInput;

    void Update()
    {
        AddPoint();
        if (targetsPos.Count != 0)
        {
            Move();
            CheckDistance();
        }
    }

    private void AddPoint()
    {
        if (_playerInput.IsTouchScreen)
            targetsPos.Enqueue(_playerInput.TargetPos);
    }

    private void Move()
    {
        if (targetsPos.Count == 0) return;

        transform.position = Vector2.MoveTowards
            (transform.position, targetsPos.Peek(), _speed * Time.deltaTime);

        DrowLinePath();
    }

    private void CheckDistance()
    {
        if (Vector2.Distance(transform.position, targetsPos.Peek()) < .1f)
        {
            targetsPos.Dequeue();
            lineRenderer.enabled = false;
        }
    }
    private void DrowLinePath()
    {
        lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, transform.position); //x,y and z position of the starting point of the line
        lineRenderer.SetPosition(1, targetsPos.Peek());
    }
}
