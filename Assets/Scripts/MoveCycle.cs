using UnityEngine;

public class MoveCycle : MonoBehaviour
{

    [SerializeField] private Vector2 _direction = Vector2.right;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private int _size = 1;

    private Vector3 _leftEdge;
    private Vector3 _rightEdge;

    private void Start()
    {
        _leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        _rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);
    }

    private void Update()
    {
        if (_direction.x > 0 && (transform.position.x - _size) > _rightEdge.x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _leftEdge.x - _size;
            transform.position = currentPosition;
        }
        else if (_direction.x < 0 && (transform.position.x + _size) < _leftEdge.x)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = _rightEdge.x + _size;
            transform.position = currentPosition;
        }
        else
        {
            transform.Translate(_direction * _speed * Time.deltaTime);
        }
    }
}
