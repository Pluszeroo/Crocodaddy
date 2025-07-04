using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    public AudioSource clickSound;

    public void PlayClickSound()
    {
        if (clickSound != null)
            clickSound.Play();
    }
}
