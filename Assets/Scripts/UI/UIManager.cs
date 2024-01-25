using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField]
    Slider playerSlider;

    [SerializeField]
    TMP_Text coinTxt;

    [SerializeField]
    Transform butonlarPanel;

    [SerializeField]
    GameObject pausePanel;

    [SerializeField]
    GameObject bitisPanel;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        TumButonlarinAlphasiniDusur();
        butonlarPanel.GetChild(0).GetComponent<CanvasGroup>().alpha = 0f;
        PlayerHareketController.instance.HerseyiKapatNormaliAc();

        pausePanel.SetActive(false);
        bitisPanel.SetActive(false);

    }

    public void SlideriGuncelle(int gecerliDeger, int maxDeger)
    {
        playerSlider.maxValue = maxDeger;
        playerSlider.value = gecerliDeger;
    }


    public void CoinAdetGuncelle()
    {
        coinTxt.text = GameManager.instance.toplananCoinAdet.ToString();
    }

    void TumButonlarinAlphasiniDusur()
    {
        foreach (Transform btn in butonlarPanel)
        {
            btn.gameObject.GetComponent<CanvasGroup>().alpha = 0.25f;
            btn.GetComponent<Button>().interactable = true;
        }
    }

    public void NormalButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;

        PlayerHareketController.instance.HerseyiKapatNormaliAc();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
    }

    public void KilicButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;

        PlayerHareketController.instance.HerseyiKapatKiliciAc();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }

    public void OkButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;

        PlayerHareketController.instance.HerseyiKapatOkuAc();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }

    public void MizrakButonaBasildi()
    {
        TumButonlarinAlphasiniDusur();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetComponent<CanvasGroup>().alpha = 1f;
        PlayerHareketController.instance.HerseyiKapatMizrakAc();

        UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

    }


    public void PausePanelAcKapat()
    {
        if(!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;

        }
    }

    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("AnaMenu");
    }

    public void BitisPanelinAc()
    {
        bitisPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void TekrarOyna()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OyundanCik()
    {
        Application.Quit();
    }
}

