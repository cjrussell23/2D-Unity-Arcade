using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamController : MonoBehaviour
{
    private float _maxAbove = 4;
    private float _maxBelow = 2;
    [SerializeField] private Transform _trackingTarget;
    [SerializeField] private float _xOffset = 4;
    [SerializeField] private float _yOffset = 2;
    [SerializeField] private float _followSpeed = 5;
    [SerializeField] private bool _isXLocked = false;
    [SerializeField] private bool _isYLocked = true;
    void Start()
    {
        
    }
    void FixedUpdate()
    {
        float xTarget = _trackingTarget.position.x + _xOffset;
        float yTarget = _trackingTarget.position.y + _yOffset;
        float xNew = transform.position.x;
        if (!_isXLocked)
        {
            xNew = Mathf.SmoothDamp(transform.position.x, xTarget, ref _followSpeed, Time.deltaTime);
        }
        float yNew = transform.position.y;
        if (!_isYLocked)
        {
            yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime
            * _followSpeed);
        }
        // Camera follows the player if the player goes out of cameras y range.
        if(_trackingTarget.position.y - yNew > _maxAbove || yNew - _trackingTarget.position.y > _maxBelow)
        {
            yNew = _trackingTarget.position.y + _yOffset; ;
        }
        transform.position = new Vector3(xNew, yNew, transform.position.z);
    }

}

