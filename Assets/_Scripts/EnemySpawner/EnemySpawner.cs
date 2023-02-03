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
    //[SerializeField] private GameObject _enemyPrefab;

    //[SerializeField] private GameObject _deactivated;
    //[SerializeField] private Sprite _spriteDeactivated;
    [SerializeField] private float _timeBetweenSpawn = 10.0f;

    [SerializeField] private int _poolCount = 3;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private Enemy _enemyPrefab;

    //Private
    //private GameObject[] _enemyArray = new GameObject[3];
    //private Enemy[] _enemyArray = new Enemy[3];
    //private bool _canSpawnEnemy = true;
    //private int _spawnEnemyIndex = 0;
    //private GameObject _enemyObject;
    //private Enemy _enemyObject;
    private Direction _direction;
    private bool _isCoroutineEnd;
    private int _clickCount = 0;
    private Coroutine _coroutineEnemySpawn;
    private bool _isDeactivated;

    private SpriteRenderer _spriteRenderer;
    private Color _deactivatedColor = Color.grey;

    private PoolMono<Enemy> _enemyPool;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _enemyPool = new PoolMono<Enemy>(_enemyPrefab, _poolCount, transform);
        _enemyPool.AutoExpand = _autoExpand;

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

    private IEnumerator EnemySpawn()
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

        /*for (int i = 0; i < _enemyArray.Length; i++)
        {
            //if (_enemyArray[i] == null)
            if (!_enemyArray[i].gameObject.activeSelf)
            {
                _canSpawnEnemy = true;
                _spawnEnemyIndex = i;
                break;
            }
            else
            {
                _canSpawnEnemy = false;
            }
        }*/

        //if (_canSpawnEnemy)
        //{
            /*switch (_direction)
            {
                case Direction.RIGHT:
                    Enemy enemyRight = _enemyPool.GetFreeElement();
                    enemyRight.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
                    //_enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    //_enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.LEFT:
                    Enemy enemyLeft = _enemyPool.GetFreeElement();
                    enemyLeft.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
                    //_enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    //_enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.UP:
                    Enemy enemyUp = _enemyPool.GetFreeElement();
                    enemyUp.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
                    //_enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x, transform.position.y + 1), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    //_enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;

                case Direction.DOWN:
                    Enemy enemyDown = _enemyPool.GetFreeElement();
                    enemyDown.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
                    //_enemyObject = Instantiate(_enemyPrefab, new Vector2(transform.position.x, transform.position.y - 1), Quaternion.identity);
                    //_enemyObject.transform.SetParent(levelGenerator.transform, true);
                    //_enemyArray[_spawnEnemyIndex] = _enemyObject;
                    break;
            }*/
        //}

        if (_direction.Equals(Direction.RIGHT))
        {
            Enemy enemy = _enemyPool.GetFreeElement();
            //_enemyPool.HasFreeElement(out Enemy enemy);
            if (enemy != null)
            {
                enemy.transform.position = new Vector2(transform.position.x + 1, transform.position.y);
            }
        }
        else if (_direction.Equals(Direction.LEFT))
        {
            Enemy enemy = _enemyPool.GetFreeElement();
            //_enemyPool.HasFreeElement(out Enemy enemy);
            if (enemy != null)
            {
                enemy.transform.position = new Vector2(transform.position.x - 1, transform.position.y);
            }
        }
        else if (_direction.Equals(Direction.UP))
        {
            Enemy enemy = _enemyPool.GetFreeElement();
            //_enemyPool.HasFreeElement(out Enemy enemy);
            if (enemy != null)
            {
                enemy.transform.position = new Vector2(transform.position.x, transform.position.y + 1);
            }
        }
        else if (_direction.Equals(Direction.DOWN))
        {
            Enemy enemy = _enemyPool.GetFreeElement();
            //_enemyPool.HasFreeElement(out Enemy enemy);
            if (enemy != null)
            {
                enemy.transform.position = new Vector2(transform.position.x, transform.position.y - 1);
            }
        }

        _isCoroutineEnd = true;
    }
}
