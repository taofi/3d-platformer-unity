using UnityEngine;

public class WindScript : MonoBehaviour
{
    public float force = 10f;  
    private Vector3 windDirection; 
    private float changeInterval = 2f;  
    private float timer;
    public ParticleSystem windParticles;

    void Start()
    {
        ChangeWindDirection();
        timer = changeInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeWindDirection();
            timer = changeInterval;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.Move(windDirection * force * Time.deltaTime);
            }
        }
    }

    void ChangeWindDirection()
    {
        if(Random.Range(-1f, 1f) > 0f)
            windDirection = new Vector3(Random.Range(-1f, 1f), 0, 0).normalized;
        else
            windDirection = new Vector3(0, 0, Random.Range(-1f, 1f)).normalized;


        if (windParticles != null)
        {
            Quaternion newRotation = Quaternion.LookRotation(windDirection);
            windParticles.transform.rotation = newRotation;
        }
    }
}
