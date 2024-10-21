using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private GameObject optionsUI;

    public AudioMixer audioMixer;

    [SerializeField] private GameObject startButton;
    private Button stB;
    [SerializeField] private GameObject quitButton;
    private Button qtB;
    [SerializeField] private GameObject optionsButton;
    private Button opB;

    [Header("Music Sources")]
    [SerializeField] private GameObject musicSource1;
    [SerializeField] private GameObject musicSource2;
    [SerializeField] private GameObject musicSource3;
    [SerializeField] private GameObject musicSource4;

    public void OnBackClicked()
    {
        optionsUI.SetActive(false);
        stB = startButton.GetComponent<Button>();
        qtB = quitButton.GetComponent<Button>();
        opB = optionsButton.GetComponent<Button>();
        stB.interactable = true;
        qtB.interactable = true;
        opB.interactable = true;
        menuUI.SetActive(true);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void OnButton1Clicked()
    {
        TurnOffAll();
        musicSource1.SetActive(true);
    }

    public void OnButton2Clicked()
    {
        TurnOffAll();
        musicSource2.SetActive(true);
    }

    public void OnButton3Clicked()
    {
        TurnOffAll();
        musicSource3.SetActive(true);
    }

    public void OnButton4Clicked()
    {
        TurnOffAll();
        musicSource4.SetActive(true);
    }

    public void TurnOffAll()
    {
        musicSource1.SetActive(false);
        musicSource2.SetActive(false);
        musicSource3.SetActive(false);
    }
}
