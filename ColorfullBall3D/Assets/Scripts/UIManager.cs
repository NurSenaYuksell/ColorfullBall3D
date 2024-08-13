using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;

    private bool radialshine;

    public Image FillRateImage;
    public GameObject Player;
    public GameObject FinishLine;
    public Animator LayoutAnimator;

    public TextMeshProUGUI coin_text;

    [Header("Setting Buttons")]
    [Space(2)]
    public GameObject settings_Open;
    public GameObject settings_Close;
    public GameObject layout_Background;

    [Header("Sound Buttons")]
    [Space(2)]
    public GameObject sound_On;
    public GameObject sound_Off;

    [Header("Vibration Buttons")]
    [Space(2)]
    public GameObject vibration_On;
    public GameObject vibration_Off;

    public GameObject iap;
    public GameObject information;

    public GameObject intro_Hand;
    public GameObject toptopmove_Text;
    public GameObject noAds;
    public GameObject shop_Button;

    public GameObject Restart_Screen;

    //Oyun sonu Ekrani
    public GameObject finishScreen;
    public GameObject blackBackground;
    public GameObject complete;
    public GameObject radial_shine;
    public GameObject coin;
    public GameObject rewarded;
    public GameObject nothanks;

    public string vibration = "Vibration";


    public void Start()
    {
        if (PlayerPrefs.HasKey("Sound") == false)
        {
            PlayerPrefs.SetInt("Sound", 1);
        }
        if (PlayerPrefs.HasKey(vibration) == false)
        {
            PlayerPrefs.SetInt(vibration, 1);
        }

        CoinTextUpdate();
    }

    public void Update()
    {
        if (radialshine == true)
        {
            radial_shine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));
        }
        FillRateImage.fillAmount = ((Player.transform.position.z*100) / (FinishLine.transform.position.z))/100;
    }


    public void FirstTouch()
    {
        intro_Hand.SetActive(false);
        toptopmove_Text.SetActive(false);
        noAds.SetActive(false);
        shop_Button.SetActive(false);
        settings_Open.SetActive(false);
        settings_Close.SetActive(false);
        layout_Background.SetActive(false);
        sound_On.SetActive(false);
        sound_Off.SetActive(false);
        vibration_On.SetActive(false);
        vibration_Off.SetActive(false);
        iap.SetActive(false);
        information.SetActive(false);
    }

    public void CoinTextUpdate()
    {
        coin_text.text = PlayerPrefs.GetInt("moneyy").ToString();
    }

    public void RestartButtonActive()
    {
        Restart_Screen.SetActive(true);
    }

    public void RestartScene()
    {
        Veriables.firsttouch = 0;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void FinishScreen()
    {
        StartCoroutine(nameof(FinishLaunch));


    }

    public IEnumerator FinishLaunch()
    {
        Time.timeScale = 0.5f;
        radialshine = true;
        finishScreen.SetActive(true);
        blackBackground.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        complete.SetActive(true);
        yield return new WaitForSecondsRealtime(1.3f);
        radial_shine.SetActive(true);
        coin.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        rewarded.SetActive(true);
        yield return new WaitForSecondsRealtime(3f);
        nothanks.SetActive(true);


    }



    public void Privacy_Policy()
    {
        Application.OpenURL("https://www.tosugames.com/privacy-policy/");
    }

    public void TermOfUse()
    {
        Application.OpenURL("https://www.tosugames.com/sample-page/");
    }



    // Buton Fonksiyonları
    public void Settings_Open()
    {
        settings_Open.SetActive(false);
        settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");


        if (PlayerPrefs.GetInt("Sound") == 1)
        {

            sound_On.SetActive(true);
            sound_Off.SetActive(false);
            AudioListener.volume = 1;

        }
        else if (PlayerPrefs.GetInt("Sound") == 2)
        {
            sound_On.SetActive(false);
            sound_Off.SetActive(true);
            AudioListener.volume = 0;

        }

        if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            vibration_On.SetActive(true);
            vibration_Off.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Vibration") == 2)
        {

            vibration_On.SetActive(false);
            vibration_Off.SetActive(true);
        }

    }

    public void Settings_Close()
    {
        settings_Open.SetActive(true);
        settings_Close.SetActive(false);
        LayoutAnimator.SetTrigger("Slide_out");
    }

    public void Sound_On()
    {
        sound_On.SetActive(false);
        sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 2);

    }

    public void Sound_Off()
    {
        sound_On.SetActive(true);
        sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 1);

    }

    public void Vibration_On()
    {
        vibration_On.SetActive(false);
        vibration_Off.SetActive(true);
        PlayerPrefs.SetInt(vibration, 2);
    }

    public void Vibration_Off()
    {
        vibration_On.SetActive(true);
        vibration_Off.SetActive(false);
        PlayerPrefs.SetInt(vibration, 1);
    }

    public IEnumerator WhiteEffect()
    {
        whiteeffectimage.gameObject.SetActive(true);
        while (effectcontrol == 0)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color += new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 1))
            {
                effectcontrol = 1;

            }
        }
        while (effectcontrol == 1)
        {
            yield return new WaitForSeconds(0.01f);
            whiteeffectimage.color -= new Color(0, 0, 0, 0.1f);
            if (whiteeffectimage.color == new Color(whiteeffectimage.color.r, whiteeffectimage.color.g, whiteeffectimage.color.b, 0))
            {
                effectcontrol = 2;
            }
        }
        if (effectcontrol == 2)
        {
            Debug.Log("Efekt Bitti");
        }

    }
}

