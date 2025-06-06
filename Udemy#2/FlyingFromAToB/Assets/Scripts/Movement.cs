using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float force = 500f;
    [SerializeField] float rotateSpeed = 1f;
    [SerializeField] AudioClip mainengine;
    [SerializeField] ParticleSystem mainEngine;
    [SerializeField] ParticleSystem leftEngine;
    [SerializeField] ParticleSystem rightEngine;
    [SerializeField] ParticleSystem extraEngine;
    [SerializeField] ParticleSystem midEngine;
    Rigidbody rb;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    public void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            HandleFroce();
            AudioAndParticleHandeler();

        }
        else
        {
            ParticleStopHandler();
        }
    }
    public void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotatingToTheLeft();

        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotatingToTheRight();

        }
        else
        {
            IncaseNothingIsHappning();
        }

    }

    private void IncaseNothingIsHappning()
    {
        mainEngine.Stop();
        leftEngine.Stop();
    }

    private void RotatingToTheRight()
    {
        ApplyRotating(rotateSpeed);
        if (!leftEngine.isPlaying)
        {

            leftEngine.Play();
        }
    }

    private void RotatingToTheLeft()
    {
        ApplyRotating(-rotateSpeed);
        if (!mainEngine.isPlaying)
        {
            mainEngine.Play();
        }
    }

    private void ApplyRotating(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.right * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }

    private void HandleFroce()
    {
        rb.AddRelativeForce(Vector3.up * force * Time.deltaTime);

    }

    private void AudioAndParticleHandeler()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainengine);
            mainEngine.Play();
            rightEngine.Play();
            leftEngine.Play();
            extraEngine.Play();
            midEngine.Play();
        }
    }

    private void ParticleStopHandler()
    {
        audioSource.Stop();
        rightEngine.Stop();
        extraEngine.Stop();
        midEngine.Stop();
    }
}
