using UnityEngine;

public class EventController : MonoBehaviour
{
    public GameObject Score_Text;
    public GameObject startButton;
    public GameObject settingButton;
    public GameObject settingPanel;
    public GameObject pauseButton;

    public AudioSource audioSource;
    public AudioClip audioClip1;
    public AudioClip audioClip2;

    private Transform playerTransform;
    private Vector3 playertargetPos;
    public Transform cameraTransform;
    public Vector3 CameraTargetposition;
    private Quaternion targetRot;

    [SerializeField]private float transitionSpeed;
    private bool gameStart;
    private float delayTime;

   public  void Start()
    {

        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("replay",false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("gameStart", false);

        GameObject.FindGameObjectWithTag("Env").GetComponent<MoveForward>().enabled = false;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>().enabled = false;
     
        startButton.SetActive(true);
        settingButton.SetActive(true);
        Score_Text.SetActive(false);
        settingPanel.SetActive(false);
        pauseButton.SetActive(false);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip1;
        audioSource.Play();

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        playertargetPos = Vector3.zero;
        CameraTargetposition = new Vector3(0,4,-7);
        targetRot = Quaternion.identity;

        delayTime = 1.4f;
        gameStart = false;
        transitionSpeed = 2f;

    }


    void Update()
    {

        if (gameStart)
        {
            playerTransform.position = Vector3.Lerp(playerTransform.position, playertargetPos, transitionSpeed * Time.deltaTime);
            playerTransform.rotation = Quaternion.Lerp(playerTransform.rotation, targetRot, transitionSpeed * Time.deltaTime);

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, CameraTargetposition, transitionSpeed * Time.deltaTime);
            cameraTransform.rotation = Quaternion.Lerp(cameraTransform.rotation, targetRot, transitionSpeed * Time.deltaTime);
        }
    }

    public void startGame()
    {
        startButton.SetActive(false);
        pauseButton.SetActive(true);
        gameStart = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("gameStart", true);
        
        audioSource.Stop();
        audioSource.clip = audioClip2;
        audioSource.Play();

        Score_Text.SetActive(true);
        settingButton.SetActive(false);
        settingPanel.SetActive(false);

        Invoke("animationDelay", delayTime);
    }

    void animationDelay()
    {
       
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        GameObject.FindGameObjectWithTag("Env").GetComponent<MoveForward>().enabled = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FollowPlayer>().enabled = true;
        GetComponent<TunnelManager>().enabled = true;
        GetComponent<Movement>().enabled = true;
    }
}
