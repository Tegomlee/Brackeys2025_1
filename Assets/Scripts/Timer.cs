using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class Timer : MonoBehaviour
{
    public AudioClip StartSound;
    public AudioClip EndSound;
    public AudioSource TimerSounds;
    [SerializeField] private float TimerCounter;
    [SerializeField] public float AmountOfTimeInSeconds = 180f;
    [SerializeField] private int minutes;
    [SerializeField] private int seconds;
    [SerializeField] private bool TimeUp = false;
    [SerializeField] public bool isCountdown = true;
    [SerializeField] private bool startsoundplayed = false;
    [SerializeField] private TextMeshProUGUI TimerText;

    private void Start()
    {
        TimerCounter = AmountOfTimeInSeconds;
    }
    private void Update()
    {
        if (isCountdown == true)
        { 
            if (startsoundplayed == false)

            {
                TimerSounds.PlayOneShot(StartSound);
                startsoundplayed=true;
            }

            TimerCounter -= Time.deltaTime;
            minutes = Mathf.FloorToInt(TimerCounter / 60f);
            seconds = Mathf.FloorToInt(TimerCounter % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if (TimerCounter < 0)
        {
            TimerText.fontSize = 20;
            TimerText.text = string.Format("L+Ratio );");
            TimerSounds.volume = 0.01f;
            TimerSounds.PlayOneShot(EndSound);
            TimeUp = true;
            isCountdown = false;
        }
    }
}
