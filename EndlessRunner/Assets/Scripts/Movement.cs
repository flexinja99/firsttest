using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Drawing.Text;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{

    private Pos _before;
    private Pos _after;
    private Pos _current;
    private Vector3 _leftPos;
    private Vector3 _centerPos;
    private Vector3 _rightPos;
    private float _moveTimer;
    private float _moveTime = 0.1f;
    private bool _doMoveLeft;
    public bool doMoveLeft
    {
        set
        {
            if (value)
                _moveTimer = _moveTime;
            else
                _moveTimer = -1.0f;
            _doMoveLeft = value;
        }
    }
    private bool _doMoveRight;
    public bool doMoveRight
    {
        set
        {
            if (value)
                _moveTimer = _moveTime;
            else
                _moveTimer = -1.0f;
            _doMoveRight = value;
        }
    }
    private bool isMovable { get; set; }
    public bool isMoving => _doMoveLeft || _doMoveRight;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _centerPos = transform.position;
        _leftPos = transform.position + Vector3.left * 1.5f;
        _rightPos = transform.position + Vector3.right * 1.5f;
        _current = Pos.Center;
        isMovable = true;
    }

    private void Update()
    {
        if (isMovable &&
            isMoving)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                doMoveLeft = true;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                doMoveRight = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (_moveTimer <0)
            return;

        if (_doMoveLeft)
        {
            switch (_current)
            {
                case Pos.Left:
                    _rb.MovePosition(Vector3.Lerp(GetVector( _leftPos, _centerPos, (1.0f - _moveTimer / _moveTimer)));
                    break;
                case Pos.Center:
                    _rb.MovePosition(Vector3.Lerp(_centerPos, _rightPos, (1.0f - _moveTimer / _moveTimer))); 
                    break;
                case Pos.Right:
                   
                    break;
                default:
                    break;
            }
            _moveTimer -= Time.fixedDeltaTime;

            if (_moveTimer < 0)
            {
                _current--;
            }
           
        }
      
    }
    private Vector3 GetVector3(Pos pos)
    {
        switch (pos)
        {
            case Pos.Left:
                return _leftPos;
                
            case Pos.Center:
                return _centerPos;
                
            case Pos.Right:
                return _rightPos;
                
            default:
                break;
        }
    }
}
