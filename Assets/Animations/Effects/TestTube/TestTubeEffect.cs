using System.Collections;
using UnityEngine;

public class TestTubeEffect : MonoBehaviour, IInteract
{
    public float duration = 5.0f;
    public float maxApmlitude = 0.15f;
    public AnimationCurve intensityCurve = AnimationCurve.EaseInOut(0, 0, 1, 1);


    public ParticleSystem explosionEffect;
    public AudioSource explosionSound;

    private Vector3 originalPosition;

    public void Interact()
    {
        StartVibration();
    }

    public void StartVibration()
    {
        StartCoroutine(VibrateCoroutine());
    }

    
    private IEnumerator VibrateCoroutine()
    {
        originalPosition = transform.localPosition;
        float time = 0f;

        while(time < duration)
        {
            time += Time.deltaTime;
            float progress = time/duration;
            float currentAmpl = maxApmlitude * intensityCurve.Evaluate(progress);
            Vector3 shake = Random.insideUnitSphere * currentAmpl;
            transform.localPosition = originalPosition + shake;
            yield return null;
        }

        transform.localPosition = originalPosition;

        explosionEffect?.Play();
        explosionSound?.Play();
    }
}
