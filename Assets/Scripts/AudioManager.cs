using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------Audio Source-------")]
    //[SerializeField] AudioSource SoundSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------Audio Clip-------")]
    public AudioClip chime;
    public AudioClip footStep;
    public AudioClip grumpy;
    public AudioClip happyEnding;
    public AudioClip liquidPour;
    public AudioClip menuClick;
    public AudioClip otterHit;
    public AudioClip sadEnding;
    public AudioClip tapFeedback;
    public AudioClip transition;
    public AudioClip glassDrop;
    public AudioClip shaking;
    public AudioClip babyCry;


    private void Start()
    {
        //musicSource.clip = background;
        //musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
