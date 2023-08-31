using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PositionDetector : MonoBehaviour
{
    [SerializeField] private ARRaycastManager _arRaycastManager;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Camera _arCam;
    [SerializeField] private AudioPlayerController _playerController;
    [SerializeField] private UnityEvent _spawnEvent;
    
    private List<ARRaycastHit> _hitList;
    private bool _isCreated = false;
    private GameObject _instance;

    private void Start()
    {
        _hitList = new List<ARRaycastHit>();
    }

    private void Update()
    {
        HandleTouchInput();
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount == 0)
            return;

        Touch touch = Input.GetTouch(0);
        if (TryGetRaycastHitFromTouch(touch))
        {
            if (touch.phase == TouchPhase.Began)
            {
                CreateInstant(_hitList[0].pose.position);
            }
            else if (touch.phase == TouchPhase.Moved && _instance != null)
            {
                MoveInstance(_hitList[0].pose.position);
            }
        }
    }

    private bool TryGetRaycastHitFromTouch(Touch touch)
    {
        return _arRaycastManager.Raycast(touch.position, _hitList, TrackableType.Planes);
    }
    
    private void CreateInstant(Vector2 position)
    {
        if (!_isCreated)
        {
            _instance = Instantiate(_prefab, position, Quaternion.identity);
            
            _playerController.SetAnimator(_instance.GetComponent<Animator>());
            
            _instance.transform.position = position;
            _isCreated = true;
            
            _spawnEvent.Invoke();
        }
        else
            _instance.transform.position = _hitList[0].pose.position;
    }
    
    private void MoveInstance(Vector3 position)
    {
        _instance.transform.position = position;
    }
}