using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform followPos;
    public float xOffset;
    public float yOffset;
    public float zOffset;


    private void Start()
    {
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(xOffset, yOffset, followPos.position.z + zOffset);
    }
 
}
