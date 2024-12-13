using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector2 startPosition;
    private Vector2 finishPosition;
    private float thresholdValue = 50f;

    public int swipeIndex = 0; 


    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                startPosition = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                finishPosition = touch.position;

                DetectSwipe(startPosition,finishPosition);
            }
        }
    }

    public void  DetectSwipe(Vector2 startPosition,Vector2 finishPosition)
    {
        Vector2 direction = finishPosition - startPosition;
        if(direction.magnitude > thresholdValue)
        {
            float x = direction.x;
            float y = direction.y;
            if ( Mathf.Abs(x) > Mathf.Abs(y))
            {
                if(x > 0)
                {
                    //Right Swap
                    swipeIndex = 1;
                }
                else
                {
                    //Left Swap
                    swipeIndex = 2;
                }
            }
            else

            {
                if(y > 0)
                {
                    //Up Swap
                    swipeIndex = 3;
                }
                else
                {
                    //Down Swap
                    swipeIndex = 4;
                }

            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().MovePlayer(swipeIndex);
        }

    }
}
