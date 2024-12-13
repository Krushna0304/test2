using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject OFFObj;
    public AudioListener audioListener;
    public AudioSource audioSource;
    public TextMeshProUGUI highscore_Text;
    public TextMeshProUGUI totalcoin_Text;
    public Button button;

    public Sprite PauseImageP;
    public Sprite ResumeImageP;
    bool status = false;
    bool isMusicOn = true;
    bool pause = false;

    private void Start()
    {
        OFFObj.SetActive(false);
        pause = false;
    }

    public void changeState()
    {

        pause = !pause;
        if (pause)
        {
            Time.timeScale = 0;
            button.image.sprite = PauseImageP;
        }
        else
        {
            Time.timeScale = 1;
            button.image.sprite = ResumeImageP;
        }
    }
    public void volumeController()
    {
        if(isMusicOn)
        {
            //audioSource.Stop();
            audioListener.enabled = false;
            OFFObj.SetActive(true);
        }
        else
        {
            //audioSource.Play();
            audioListener.enabled = true;
            OFFObj.SetActive(false);
        }
        isMusicOn = !isMusicOn;
    }
    public void OpenSettings()
    {
        status = !status;
        settingPanel.SetActive(status);
        highscore_Text.text = "High Score : " + PlayerPrefs.GetFloat("highScore").ToString();
        totalcoin_Text.text = "Total Coin : " + PlayerPrefs.GetFloat("totalCoin").ToString();

        //openLeaderBoard();
    }

   
}
