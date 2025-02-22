using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PhoneManager : MonoBehaviour
{
    public Animator animator;
    public AudioClip CallSound;
    public AudioClip AnswerSound;
    public AudioClip DeclineSound;
    public AudioSource PhoneSound;
    public GameObject Phone;
    public GameObject Player;
    public Button Answer;
    public Button Decline;
    public bool trigger;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Answer.onClick.AddListener(Answerscript);
        Decline.onClick.AddListener(Declinescript);
    }

    // Update is called once per frame
    void Update()
    {
        trigger = Player.GetComponent<PlayerController>().phonetrigger;
        if (trigger==true)
        {
            animator.SetTrigger("call");
        }
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
