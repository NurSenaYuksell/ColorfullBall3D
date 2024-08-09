using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public Image whiteeffectimage;
    private int effectcontrol = 0;
    public Animator LayoutAnimator;

    [Header("Setting Buttons")]
    [Space(2)]
    public GameObject settings_Open;
    public GameObject settings_Close;

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

