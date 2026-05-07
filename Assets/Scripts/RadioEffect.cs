using UnityEngine;

public class RadioEffect : MonoBehaviour, IInteract
{
    public ParticleSystem smoke;
    public ParticleSystem spark;

    private bool flag = false;


    public void Interact()
    {
        flag = !flag;
        Effect();
    }

    public void Effect()
    {   
        if (flag)
        {
           smoke.Play();
           spark.Play(); 
        }
        else
        {
            smoke.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            spark.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}   
