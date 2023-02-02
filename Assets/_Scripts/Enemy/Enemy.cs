using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Serialize fields
    //[SerializeField] private BoxCollider2D _collider2d;
    [SerializeField] private LayerMask _wallLayerMask;
    [SerializeField] private float _timeBetweenMove = 0.5f;

    // Private fields
    private BoxCollider2D _collider2D;
    private bool _isCoroutineEnd = true;
    private Direction _direction;
    private float _extraDistance = 0.1f;
    private RaycastHit2D _raycastHit;
    private Color _rayColor = Color.black;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        _direction = (Direction)Random.Range(1, 5);
        _raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.zero, _collider2D.bounds.extents.x, _wallLayerMask);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (_direction == Direction.RIGHT && !IsWall(Direction.RIGHT) && _isCoroutineEnd)
        {
            //StartCoroutine(MoveRight());
            StartCoroutine(Move(1, 0));
            _isCoroutineEnd = false;
            //transform.position = new Vector2(transform.position.x + 0.01f, transform.position.y);
        }
        else if (_direction == Direction.LEFT && !IsWall(Direction.LEFT) && _isCoroutineEnd)
        {
            //StartCoroutine(MoveLeft());
            StartCoroutine(Move(-1, 0));
            _isCoroutineEnd = false;
            //transform.position = new Vector2(transform.position.x - 0.01f, transform.position.y);
        }
        else if (_direction == Direction.UP && !IsWall(Direction.UP) && _isCoroutineEnd)
        {
            //StartCoroutine(MoveUp());
            StartCoroutine(Move(0, 1));
            _isCoroutineEnd = false;
            //transform.position = new Vector2(transform.position.x, transform.position.y + 0.01f);
        }
        else if (_direction == Direction.DOWN && !IsWall(Direction.DOWN) && _isCoroutineEnd)
        {
            //StartCoroutine(MoveDown());
            StartCoroutine(Move(0, -1));
            _isCoroutineEnd = false;
            //transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
        }
    }

    public IEnumerator Move(float xOffset, float yOffset)
    {
        yield return new WaitForSeconds(_timeBetweenMove);

        transform.position = new Vector2(transform.position.x + xOffset, transform.position.y + yOffset);
        _isCoroutineEnd = true;
    }


    /*public IEnumerator MoveRight()
    {
        yield return new WaitForSeconds(_timeBetweenMove);

        transform.position = new Vector2(transform.position.x + 1, transform.position.y);
        _isCoroutineEnd = true;
    }

    public IEnumerator MoveLeft()
    {
        yield return new WaitForSeconds(_timeBetweenMove);

        transform.position = new Vector2(transform.position.x - 1, transform.position.y);
        _isCoroutineEnd = true;
    }

    public IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(_timeBetweenMove);

        transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        _isCoroutineEnd = true;
    }

    public IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(_timeBetweenMove);

        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
        _isCoroutineEnd = true;
    }*/

    public bool IsWall(Direction dir)
    {
        switch (dir)
        {
            case Direction.RIGHT:
                _raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.right, _collider2D.bounds.extents.x + _extraDistance, _wallLayerMask);
                if (_raycastHit.collider != null)
                {
                    _rayColor = Color.blue;
                    _direction = (Direction)Random.Range(1, 5);
                }
                else
                {
                    _rayColor = Color.black;
                }
                Debug.DrawRay(_collider2D.bounds.center, Vector2.right * (_collider2D.bounds.extents.x + _extraDistance), _rayColor);
                return _raycastHit.collider != null;

            case Direction.LEFT:
                _raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.left, _collider2D.bounds.extents.x + _extraDistance, _wallLayerMask);
                if (_raycastHit.collider != null)
                {
                    _rayColor = Color.blue;
                    _direction = (Direction)Random.Range(1, 5);
                }
                else
                {
                    _rayColor = Color.black;
                }
                Debug.DrawRay(_collider2D.bounds.center, Vector2.left * (_collider2D.bounds.extents.x + _extraDistance), _rayColor);
                return _raycastHit.collider != null;

            case Direction.UP:
                _raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.up, _collider2D.bounds.extents.y + _extraDistance, _wallLayerMask);
                if (_raycastHit.collider != null)
                {
                    _rayColor = Color.blue;
                    _direction = (Direction)Random.Range(1, 5);
                }
                else
                {
                    _rayColor = Color.black;
                }
                Debug.DrawRay(_collider2D.bounds.center, Vector2.up * (_collider2D.bounds.extents.y + _extraDistance), _rayColor);
                return _raycastHit.collider != null;

            case Direction.DOWN:
                _raycastHit = Physics2D.Raycast(_collider2D.bounds.center, Vector2.down, _collider2D.bounds.extents.y + _extraDistance, _wallLayerMask);
                if (_raycastHit.collider != null)
                {
                    _rayColor = Color.blue;
                    _direction = (Direction)Random.Range(1, 5);
                }
                else
                {
                    _rayColor = Color.black;
                }
                Debug.DrawRay(_collider2D.bounds.center, Vector2.down * (_collider2D.bounds.extents.y + _extraDistance), _rayColor);
                return _raycastHit.collider != null;

            default:
                return _raycastHit.collider != null;
        }
    }
}
