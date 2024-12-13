using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   
    private Animator animator;
    private Rigidbody rb;
    public LayerMask bridgeLayer;

    public GameObject exitPanel;
    public TextMeshProUGUI scoreText;

    private float locationIndex = 0;
    private Vector3 loc;

    private float force = 10f;
    bool gameRunning = true;
    bool onBridge = false;
    public Transform bridgeT;

    private float score;
    private float highScore;
    private bool Cheker = true;
    private float totalCoin;
    public float bridgeCheckDist;

    void Start()
    {
        Time.timeScale = 1;

        animator = GetComponent<Animator>();
        animator.SetBool("gameStart", true);
        animator.SetBool("replay", false);
        animator.SetBool("isSlide", false);

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        rb = GetComponent<Rigidbody>();

        StartCoroutine("scoreCalculator");
        highScore = PlayerPrefs.GetFloat("highScore" , 0);
        totalCoin = PlayerPrefs.GetInt("totalCoin",0);
    }

    IEnumerator scoreCalculator()
    {
        while(gameRunning)
        {
        score++;
            yield return new WaitForSeconds(1f);
        }

    }

    void Update()
    {
        loc = transform.position;
        loc.x = locationIndex * 1f;
        transform.position = loc;
        
        scoreText.text = "Score : " + score.ToString();

        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
            PlayerPrefs.Save();
        }

        if(Physics.Raycast(transform.position,Vector3.down, bridgeCheckDist,bridgeLayer))
        {
          
            onBridge = true;
        }
        else
        {
            onBridge = false;
        }
    }

    public void MovePlayer(int swipeIndex)
    {
        if (onBridge)
        {
            return;
        }
        if (swipeIndex != 0)
        {
            if (swipeIndex == 1)
            {
                if (locationIndex < 1)
                {
                    locationIndex++;
                }
            }
            else if (swipeIndex == 2)
            {
                if (locationIndex > -1)
                {
                    locationIndex--;
                }
            }
            else if (swipeIndex == 3)
            {
                rb.AddForce(Vector3.up * force * Time.deltaTime, ForceMode.Impulse);

            }
            else if (swipeIndex == 4)
            {
                if (Cheker)
                {
                    Cheker = false;
                    StartCoroutine(corotine());
                    animator.SetBool("IsSlide", true);
                }
            }
        }
      }
    IEnumerator corotine()
    {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(1f);

        animator.SetBool("IsSlide", false);
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<CapsuleCollider>().enabled = true;
    }

    public void ExitGame()
    {

        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ReplayGame()
    {
        Time.timeScale = 1f;
        animator.SetBool("replay", true);
        SceneManager.LoadScene("gameMode");
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Coin"))
        {
            totalCoin += 1;
            PlayerPrefs.SetFloat("totalCoin",totalCoin);
            PlayerPrefs.Save();
            Destroy(col.gameObject);
        }
        if (col.gameObject.CompareTag("car"))
        {
            exitPanel.SetActive(true);
            StopAllCoroutines();
            gameRunning = false;
            Time.timeScale = 0;

        }
    }

}
