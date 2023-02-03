using UnityEngine;

public class Speed : MonoBehaviour
{
    // Serialize
    [SerializeField] private string _tagToCompare = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            collision.gameObject.GetComponent<Enemy>().ChangeTimeBetweenMove(0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            collision.gameObject.GetComponent<Enemy>().ChangeTimeBetweenMove(0.5f);
        }
    }
}
