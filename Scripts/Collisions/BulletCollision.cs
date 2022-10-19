using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private Collider2D _boundaryCollider;
    private CameraCollision _cameraCollision;
    private Collider2D _objectCollider;
    private Collider2D _toHitCollider;
    public bool enemy = false;
    void Start()
    {
        Camera myCam = Camera.main;
        _cameraCollision = myCam.GetComponent<CameraCollision>();
        _objectCollider = transform.GetComponent<Collider2D>();
        if (enemy)
        {
            _boundaryCollider = _cameraCollision.Bottom.GetComponent<Collider2D>();
        }
        else
        {
           _boundaryCollider = _cameraCollision.Top.GetComponent<Collider2D>();
        }
    }
    
    void Update()
    {
        if (_objectCollider.IsTouching(_boundaryCollider))
        {
            Destroy(gameObject);
            return;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.GetComponent<PlayerController>().Kill();
        }
    }
    
}
