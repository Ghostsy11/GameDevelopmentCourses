
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColisionHandeler : MonoBehaviour
{

    [SerializeField] float amountOfSecoundsToWait = 4f;
    AudioSource audio123;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip success;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;
    bool isTransitioning = false;
    public bool disablingcollisions = false;
    private void Start()
    {

        audio123 = GetComponent<AudioSource>();
    }

    private void Update()
    {

    }
    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning || disablingcollisions) { return; }

        switch (other.gameObject.tag)
        {

            case "Finish":
                StartCrashNextLevel();
                break;
            case "Friendly":
                break;
            default:
                StartCrashSequence();
                break;
        }
    }


    void StartCrashSequence()
    {
        isTransitioning = true;
        audio123.Stop();
        audio123.PlayOneShot(crash);
        crashParticles.Play();
        Debug.Log(crashParticles);
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadScene", amountOfSecoundsToWait);
    }

    void StartCrashNextLevel()
    {
        isTransitioning = true;
        audio123.Stop();
        audio123.PlayOneShot(success);
        successParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadSceneNextLevel", amountOfSecoundsToWait);
    }
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

    }
    public void ReloadSceneNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneLevel = currentSceneIndex + 1;
        if (nextSceneLevel == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneLevel = 0;
        }
        SceneManager.LoadScene(nextSceneLevel);
    }
}
