using UnityEngine;

public class Shield : MonoBehaviour
{
    // Serialize
    [SerializeField] private string _tagToCompare = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            collision.gameObject.GetComponent<Enemy>().ChangeDestructibleType(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals(_tagToCompare))
        {
            collision.gameObject.GetComponent<Enemy>().ChangeDestructibleType(true);
        }
    }
}
