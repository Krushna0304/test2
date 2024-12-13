using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
        if (transform.CompareTag("Coin") || transform.CompareTag("car"))
        {
            Destroy(this.gameObject, 15f);
        }
    }
    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
    }
}
