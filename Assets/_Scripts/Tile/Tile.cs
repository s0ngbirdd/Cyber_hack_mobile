using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Serialize
    [SerializeField] private GameObject _highlight;
    [SerializeField] private GameObject _occupied;

    // Private
    private Filling _filling;

    private void Start()
    {
        _filling = FindObjectOfType<Filling>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0) || Input.GetMouseButtonDown(0))
        {
            if(!_highlight.activeSelf)
            {
                if (_occupied.activeSelf)
                {
                    _occupied.SetActive(false);
                }

                _highlight.SetActive(true);

                _filling.IncreaseCurrentFill();
            }
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (_highlight.activeSelf)
            {
                _highlight.SetActive(false);
                
                if (Fill.currentPos >= 1)
                {
                    Fill.currentPos -= 1;
                    Debug.Log("Fill.currentPos - >>> " + Fill.currentPos);
                }
                
            }

            _occupied.SetActive(true);
        }


        if (collision.gameObject.tag == "Changeable" && collision.gameObject.GetComponent<SpriteRenderer>().color.Equals(Color.green))
        {
            if (_occupied.activeSelf)
            {
                _occupied.SetActive(false);
            }

            if (Fill.currentPos < Fill.maxPos && !_highlight.activeSelf)
            {
                Fill.currentPos += 1;
            }
            Debug.Log("Fill.currentPos - GREEN >>> " + Fill.currentPos + "\n" + gameObject.name);
            _highlight.SetActive(true);
        }

        else if (collision.gameObject.tag == "Changeable" && collision.gameObject.GetComponent<SpriteRenderer>().color.Equals(Color.red))
        {
            if (_highlight.activeSelf)
            {
                _highlight.SetActive(false);
                if (Fill.currentPos >= 1)
                {
                    Fill.currentPos -= 1;
                    Debug.Log("Fill.currentPos - >>> " + Fill.currentPos);
                }
            }

            _occupied.SetActive(true);
        }
        
    }*/
}
