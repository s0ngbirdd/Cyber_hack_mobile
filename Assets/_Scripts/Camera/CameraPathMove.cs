using System.Collections;
using UnityEngine;

public class CameraPathMove : MonoBehaviour
{
    // Serialize
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeToFindPoint = 0.1f;

    // Private
    private Transform _movePoint;
    private int _targetNumber = 0;

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
                if (GameObject.Find($"target{_targetNumber + 1}"))
                {
                    _movePoint = GameObject.Find($"target{++_targetNumber}").transform;
                }

                else
                {
                    //ShowSummaryEvent?.Invoke();

                    _movePoint = null;
                }
            }
        }
    }

    private IEnumerator FindPoints()
    {
        yield return new WaitForSeconds(_timeToFindPoint);

        _movePoint = GameObject.Find($"target{_targetNumber}").transform;
    }

    /*private float InstanceNumber()
    {
        return int.Parse(new string(SceneManager.GetActiveScene().name.Where(char.IsDigit).ToArray()));
    }*/
}
