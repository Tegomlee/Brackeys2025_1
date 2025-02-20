using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public AudioClip CallSound;
    public AudioClip AnswerSound;
    public AudioClip DeclineSound;
    public AudioSource PhoneSound;
    public GameObject Phone;
    public Button Answer;
    public Button Decline;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Answer.onClick.AddListener(Answerscript);
        Decline.onClick.AddListener(Declinescript);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Ringtone()
    {
        PhoneSound.PlayOneShot(CallSound);
    }
    void Answerscript()
    {
        PhoneSound.Stop();
        PhoneSound.PlayOneShot(AnswerSound);
    }
    void Declinescript()
    {
        PhoneSound.Stop();
        PhoneSound.PlayOneShot(DeclineSound);
    }
}
