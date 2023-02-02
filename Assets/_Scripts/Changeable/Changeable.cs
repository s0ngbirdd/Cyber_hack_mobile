using System.Collections;
using UnityEngine;

public class Changeable : MonoBehaviour
{
    // Serialize
    /*[SerializeField] private Sprite _spritePlayerTile;
    [SerializeField] private Sprite _spriteEnemyTile;
    [SerializeField] private Sprite _spriteDeactivated;*/

    [SerializeField] private float _timeBeforeSpriteChange = 1.0f;
    [SerializeField] private float _timeBeforeDeactivation = 0.1f;
    
    // Private
    private bool _isCoroutineEnd = true;
    private bool _isDeactivated;
    private Coroutine _coroutineChangeSprite;
    private BoxCollider2D _collider2D;
    private SpriteRenderer _spriteRenderer;

    private Color _playerTileColor = Color.cyan;
    private Color _enemyTileColor = Color.magenta;
    private Color _deactivatedColor = Color.grey;

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _playerTileColor;
    }

    private void Update()
    {
        if (_isCoroutineEnd && !_isDeactivated)
        {
            _coroutineChangeSprite = StartCoroutine(ChangeSprite());
            _isCoroutineEnd = false;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_isDeactivated)
        {
            _collider2D.size = new Vector2(3, 3);

            StopCoroutine(_coroutineChangeSprite);
            StartCoroutine(Deactivate());

            _isDeactivated = true;
        }
    }

    public IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(_timeBeforeSpriteChange);

        /*if (_spriteRenderer.sprite.Equals(_spritePlayerTile))
        {
            _spriteRenderer.sprite = _spriteEnemyTile;
        }
        else if (_spriteRenderer.sprite.Equals(_spriteEnemyTile))
        {
            _spriteRenderer.sprite = _spritePlayerTile;
        }*/

        if (_spriteRenderer.color.Equals(_playerTileColor))
        {
            _spriteRenderer.color = _enemyTileColor;
        }
        else if (_spriteRenderer.color.Equals(_enemyTileColor))
        {
            _spriteRenderer.color = _playerTileColor;
        }

        _isCoroutineEnd = true;
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(_timeBeforeDeactivation);

        _collider2D.size = new Vector2(0.96f, 0.96f);
        //_spriteRenderer.sprite = _spriteDeactivated;
        _spriteRenderer.color = _deactivatedColor;
    }
}
