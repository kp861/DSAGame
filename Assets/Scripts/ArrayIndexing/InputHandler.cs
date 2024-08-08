using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField InputField;
    [SerializeField] Text resultText;
    private ScoreKeeper scoreKeeper;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    SceneLoader sceneLoader;

    private void Start()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }
    public void ValidateInput()
    {
        string input = InputField.text; 

        if (input == "8")
        {
            scoreKeeper.IncrementScore(10);
            audioSource1.Play();
            sceneLoader.LoadSceneWithDelay("InsertionSortLevel", 1f);
        }
        else
        {
            scoreKeeper.DecrementScore(10);
            audioSource2.Play();
        }
    }
}
