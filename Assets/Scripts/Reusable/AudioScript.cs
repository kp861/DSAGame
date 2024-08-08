using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource AudioSource1;
    public AudioSource AudioSource2;

    public void PlayCorrectAnswerSound()
    {
        AudioSource1.Play();
    }
    public void PlayIncorrectAnswerSound()
    {
        AudioSource2.Play();
    }
}
