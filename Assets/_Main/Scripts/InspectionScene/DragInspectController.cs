using System;
using _Main.Scripts.MobileInput;
using UnityEngine;

namespace _Main.Scripts.InspectionScene
{
    public class DragInspectController
    {
        private MobileInputHandler _inputHandler;
        private Transform _cameraTr;
        private Transform _targetSocketTr;
        private float _rotationSpeed, _zoomSpeed, _minZoom, _maxZoom;
        
        private float _currentDistance, _xRotation, _yRotation;

        private const float _deadZone = 5f;

        public DragInspectController(MobileInputHandler inputHandler, Transform cameraTr, Transform targetSocketTr, float rotationSpeed, float zoomSpeed, float minZoom, float maxZoom)
        {
            _inputHandler = inputHandler;
            _cameraTr = cameraTr;
            _targetSocketTr = targetSocketTr;
            _rotationSpeed = rotationSpeed;
            _zoomSpeed = zoomSpeed;
            _minZoom = minZoom;
            _maxZoom = maxZoom;
            _currentDistance = Vector3.Distance(_cameraTr.position,_targetSocketTr.position);
        }

        public void HandleRotation()
        {
            if (Mathf.Abs(_inputHandler.VerticalInput) > _deadZone)
            {
                _targetSocketTr.Rotate(Vector3.right, -_inputHandler.VerticalInput * _rotationSpeed  * Time.deltaTime, Space.World);
            }
            
            if (Mathf.Abs(_inputHandler.HorizontalInput) > _deadZone)
            {
                _targetSocketTr.Rotate(Vector3.up, -_inputHandler.HorizontalInput * _rotationSpeed * Time.deltaTime, Space.World);
            }
        }

        public void HandleZoom()
        {
            _currentDistance += _inputHandler.PinchDelta * _zoomSpeed * Time.deltaTime * 100f;
            _currentDistance = Mathf.Clamp(_currentDistance, _minZoom, _maxZoom);
            
            _cameraTr.position = -Vector3.forward * _currentDistance;
        }
    }
}