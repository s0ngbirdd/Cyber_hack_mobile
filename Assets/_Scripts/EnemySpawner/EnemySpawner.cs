using System.Collections;
using UnityEngine;

/*public enum Direction
{
    RIGHT = 1,
    LEFT = 2,
    UP = 3,
    DOWN = 4
}*/

public class EnemySpawner : MonoBehaviour
{
    // Public
    //public GameObject levelGenerator;
    //public int spawnCount = 0;

    // Serialize
    [SerializeField] private GameObject _enemyPrefab;
    //[SerializeField] private GameObject _deactivated;
    //[SerializeField] private Sprite _spriteDeactivated;
    [SerializeField] private float _timeBetweenSpawn = 10.0f;

    //Private
    private GameObject[] _enemyArray = new GameObject[3];
    private bool _canSpawnEnemy = true;
    private int _spawnEnemyIndex = 0;
    private GameObject _enemyObject;
    private Direction _direction;
    private bool _isCoroutineEnd;
    private int _clickCount = 0;
    private Coroutine _coroutineEnemySpawn;
    private bool _isDeactivated;

    private SpriteRenderer _spriteRenderer;
    private Color _deactivatedColor = Color.grey;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        ChooseDirection();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !_isDeactivated)
        {
            _clickCount += 1;

            if (_clickCount >= 2)
            {
                //Debug.Log("STOP!!!");
                StopCoroutine(_coroutineEnemySpawn);
                //_deactivated.SetActive(true);
                //_spriteRenderer.sprite = _spriteDeactivated;
                _spriteRenderer.color = _deactivatedColor;

                //gameObject.GetComponent<EnemySpawner>().enabled = false; //////// ???????????????????????
                _isDeactivated = true;
            }
        }
    }

    private void Update()
    {
        if (_isCoroutineEnd && !_isDeactivated)
        {
            //Debug.Log("START!!!");
            _coroutineEnemySpawn = StartCoroutine(EnemySpawn());
            _isCoroutineEnd = false;
        }
    }

    public IEnumerator EnemySpawn()
    {
        yield return new WaitForSeconds(_timeBetweenSpawn);

        //Debug.Log("SPAWN!!!");
        ChooseDirection();
        //_isCoroutineEnd = true;
    }

    private void ChooseDirection()
    {
        _direction = (Direction)Random.Range(1, 5);

        /*foreach (GameObject gameObject in _enemyArray)
        {
            if (gameObject == null)
            {
                _canSpawn = true;
                break;
            }
            else
            {
                _canSpawn = false;
            }
        }*/

        for (int i = 0; i < _enemyArray.Length; i++)
        {
            if (_enemyArray[i] == null)
            {
                _canSpawnEnemy = true;
                _spawnEnemyIndex = i;
                break;
            }
            else
            {
                _canSpawnEnemy = false;
            }
        }

        if (_canSpawnEnemy)
        {
            switch (_direction)
            {
                case Direction.RIGHT:
                    _enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    _enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.LEFT:
                    _enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    _enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.UP:
                    _enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    _enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.DOWN:
                    _enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    _enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;
            }
        }

        _isCoroutineEnd = true;
    }
}
