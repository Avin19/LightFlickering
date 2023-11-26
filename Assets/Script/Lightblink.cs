
using UnityEngine;
using UnityEngine.UI;

public class Lightblink : MonoBehaviour
{
    [SerializeField] private Button blinBtn;

    [SerializeField] private Button randomBtn;
    [SerializeField] private Button realistbtn;
    private float internalTimer = 1f;
    public float timer;
    [SerializeField] private Light lightNow;
    public bool blinkcheck = false;
    public bool randonFlick = false;
    public bool realistFlicker = false;
    public bool isOn;
    private float delay;
    private float defaultIntensity;


    private void Start()
    {
        blinBtn.onClick.AddListener(() =>
        {
            blinkcheck = !blinkcheck;
            randonFlick = false;
            realistFlicker =false;
        });
        randomBtn.onClick.AddListener(() =>
        {
            randonFlick = !randonFlick;
            blinkcheck = false;
            realistFlicker =false;
        });
        realistbtn.onClick.AddListener(() =>
           { realistFlicker = !realistFlicker ;
            blinkcheck =false;
            randonFlick =false;}

        );
        defaultIntensity = lightNow.intensity;


    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (blinkcheck && timer > internalTimer)
        {
            lightNow.enabled = !lightNow.enabled;
            timer = 0;
        }
        if (randonFlick && timer > internalTimer)
        {
            lightNow.enabled = !lightNow.enabled;
            internalTimer = Random.Range(0f, 1f);
            timer = 0;
        }
        if (realistFlicker && timer > delay)
        {
            ToggleLight();
        }


    }

    private void ToggleLight()
    {
        isOn = !isOn;
        if (isOn)
        {
            lightNow.intensity = defaultIntensity;
            delay = Random.Range(0, 1);
        }
        else
        {
            lightNow.intensity = Random.Range(0.6f, defaultIntensity);
            delay = Random.Range(0, 0.2f);
        }
        timer = 0;

    }
}
