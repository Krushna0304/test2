using UnityEngine;

public class selfRotate : MonoBehaviour
{
    private float speed =10f;
    void Update()
    {
        transform.Rotate(0,0,speed * Time.deltaTime);
    }
}
