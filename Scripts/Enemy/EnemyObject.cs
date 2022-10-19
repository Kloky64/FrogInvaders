using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;
using Object = System.Object;

public class EnemyObject : MonoBehaviour
{
    private Vector3 _movement = new Vector3();
    public float speed = 1;
    private Collider2D _bottomBoundaryCollider;
    private Collider2D _leftBoundaryCollider;
    private Collider2D _rightBoundaryCollider;
    private Collider2D _objectCollider;
    private int _sign = 1;
    public float lineShift = 1;
    private int _linesShifted = 0;
    public float accelerationScale = 1;
    private CameraCollision _cameraCollision;
    private bool _isAlive;

    void Start()
    {
        _isAlive = true;
        Camera myCam = Camera.main;
        _cameraCollision = myCam.GetComponent<CameraCollision>();
        _objectCollider = transform.GetComponent<Collider2D>();
        _bottomBoundaryCollider = _cameraCollision.Bottom.GetComponent<Collider2D>();
        _leftBoundaryCollider = _cameraCollision.Left.GetComponent<Collider2D>();
        _rightBoundaryCollider = _cameraCollision.Right.GetComponent<Collider2D>();
    }
    
    void Update()
    {
        _movement = Vector3.zero;
        Vector3 currentPos = Vector3.zero;
        if (_objectCollider.IsTouching(_leftBoundaryCollider) && _sign < 0)
        {
            _sign *= -1;
            MovementOptions.DescendAtNextLine(gameObject, lineShift, ref _linesShifted);
            Accelerate();
        } else if (_objectCollider.IsTouching(_rightBoundaryCollider) && _sign > 0)
        {
            _sign *= -1;
            MovementOptions.DescendAtNextLine(gameObject, lineShift, ref _linesShifted);
            Accelerate();
        } else if (_objectCollider.IsTouching(_bottomBoundaryCollider))
        {
            Destroy(gameObject);
            return;
        }
        MovementOptions.MoveHorizontally(gameObject, ref _movement, _sign);
        gameObject.transform.position += Time.deltaTime * speed * _movement;
    }

    private void Accelerate()
    {
        if (_linesShifted % 3 == 1)
        {
            speed *= accelerationScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.GetComponent<PlayerController>().Kill();
        }
        
        if(col.gameObject.CompareTag("PlayerBullet")){
            Die();
        }
    }

    private void Die()
    {
        if (_isAlive)
        {
            _isAlive = false;
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().KillEnemy();
        }
    }
}
