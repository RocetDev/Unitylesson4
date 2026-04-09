using UnityEngine;

public class MagnetField : MonoBehaviour
{
    public float radius = 0.5f;
    public float force = 50f;
    public bool flag = false;

    public void TurnFlip()
    {
        flag = !flag;
    }
    public void TurnOn()
    {
        flag = true;
    }

    public void TurnOff()
    {
        flag = false;
    }

    void FixedUpdate()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider hit in colls)
        {
            Screw screw = hit.GetComponent<Screw>();

            if(screw == null)
            {
                continue;
            }

            Rigidbody rb = hit.GetComponent<Rigidbody>();
            
            if(rb == null)
            {
                continue;
            }

            if(flag)
            {
                Vector3 direction = (transform.position - hit.transform.position).normalized;
                rb.AddForce(direction * force, ForceMode.Force);
            }
        }
    }
}
