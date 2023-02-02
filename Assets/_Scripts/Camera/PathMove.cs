using System.Collections;
using UnityEngine;

public class PathMove : MonoBehaviour
{
    // Serialize
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeToWait = 0.1f;

    // Private
    private Transform _movePoint;
    private int _targetCount = 0;

    private void Start()
    {
        //Debug.Log("SPEEDLEVEL >>> " + _moveSpeed);
        //_moveSpeed = 1.0f + (InstanceNumber() / 10.0f);
        StartCoroutine(FindPoints());
    }

    private void Update()
    {
        if (_movePoint != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, _movePoint.position, _moveSpeed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 10);

            if (Vector2.Distance(transform.position, _movePoint.position) <= 0)
            {
                //Debug.Log("__POINT__");

                if (GameObject.Find($"target{_targetCount + 1}"))
                {
                    _movePoint = GameObject.Find($"target{++_targetCount}").transform;
                }

                else
                {
                    //ShowSummaryEvent?.Invoke();

                    _movePoint = null;
                }
            }
        }
    }

    public IEnumerator FindPoints()
    {
        yield return new WaitForSeconds(_timeToWait);

        _movePoint = GameObject.Find($"target{_targetCount}").transform;
    }

    /*private float InstanceNumber()
    {
        return int.Parse(new string(SceneManager.GetActiveScene().name.Where(char.IsDigit).ToArray()));
    }*/
}
