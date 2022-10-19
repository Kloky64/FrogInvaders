using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CameraCollision : MonoBehaviour {
    
    public float colThickness = 2f;
    private Vector2 _screenSize;
    public Camera myCam;
    Transform[] _colliders = new Transform[4];
    private float _horizontalDeltaDistance = 0.3f;
    private float _verticalDeltaDistance = 0.5f;
    public float boundHeight = 2;
    public float boundWidth = 4;
    
 
    public Transform Top
    {
        get => _colliders[0];
        set => _colliders[0] = value;
    }
    
    public Transform Bottom
    {
        get => _colliders[1];
        set => _colliders[1] = value;
    }
    
    public Transform Left
    {
        get => _colliders[2];
        set => _colliders[2] = value;
    }
    
    public Transform Right
    {
        get => _colliders[3];
        set => _colliders[3] = value;
    }
    
    void Awake()
    {
        myCam = Camera.main;

        for (int i = 0; i < 4; ++i)
        {
            _colliders[i] = new GameObject().transform;
        }
        
        Vector3 cameraPos = myCam.transform.position;
        
        _screenSize.x = Vector2.Distance(myCam.ScreenToWorldPoint(new Vector2(0, 0)),
            myCam.ScreenToWorldPoint(new Vector2(Screen.width, 0))) * 0.5f; 
        _screenSize.y = Vector2.Distance(myCam.ScreenToWorldPoint(new Vector2(0, 0)),
            myCam.ScreenToWorldPoint(new Vector2(0, Screen.height))) * 0.5f;

        Top.name = "Top";
        Bottom.name = "Bottom";
        Left.name = "Left";
        Right.name = "Right";

        foreach (Transform bound in _colliders)
        {
            bound.gameObject.AddComponent<BoxCollider2D>();
            bound.gameObject.AddComponent<Rigidbody2D>();
            var rigidBound = bound.gameObject.GetComponent<Rigidbody2D>();
            rigidBound.constraints = RigidbodyConstraints2D.FreezeAll;
            bound.parent = transform; 
            
            if (bound == Left || bound == Right) 
                bound.localScale = 
                    new Vector3(colThickness, _screenSize.y * boundHeight, colThickness);
            else
                bound.localScale = 
                    new Vector3(_screenSize.x * boundWidth, colThickness, colThickness);
        }
        
        Right.position = new Vector3(cameraPos.x + _screenSize.x + 
                        (Right.localScale.x * _horizontalDeltaDistance), cameraPos.y, 0);
        Left.position = new Vector3(cameraPos.x - _screenSize.x - 
                        (Left.localScale.x * _horizontalDeltaDistance), cameraPos.y, 0);
        Top.position = new Vector3(cameraPos.x, cameraPos.y + _screenSize.y +
                        (Top.localScale.y * _verticalDeltaDistance), 0);
        Bottom.position = new Vector3(cameraPos.x, cameraPos.y - _screenSize.y -
                        (Bottom.localScale.y * _verticalDeltaDistance), 0);
    }
}