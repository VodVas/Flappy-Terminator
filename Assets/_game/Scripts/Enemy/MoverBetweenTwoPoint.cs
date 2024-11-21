using UnityEngine;

public class MoverBetweenTwoPoint : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speed = 2f;

    private Vector3 _targetPosition;
    private bool _isDestinationPointB = true;
    private float _littleValue = 0.1f;

    private void Start()
    {
        _targetPosition = _pointB.position;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _targetPosition) < _littleValue)
        {
            _isDestinationPointB = !_isDestinationPointB;

            _targetPosition = _isDestinationPointB ? _pointB.position : _pointA.position;
        }
    }
}