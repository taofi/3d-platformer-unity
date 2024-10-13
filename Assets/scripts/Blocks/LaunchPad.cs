using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    public float upwardForce;  // ����, � ������� ������������ �����
    public float directionalForce;  // ����, � ������� ������� � ����������� �����
    public float acceleration;  // ��������� �������� � �����������

    [SerializeField]
    private AudioClip jumpSoundClip;

    private Vector3 direction;  
    private Vector3 currentVelocity;  

    void Start()
    {
        direction = transform.forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            CharacterController controller = other.GetComponent<CharacterController>();
            if (controller != null)
            {
                currentVelocity = Vector3.up * upwardForce; 
                StartCoroutine(ApplyEffect(controller));
                SFXManager.instance.PlaySoundFXClip(jumpSoundClip, transform, 1f);

            }
        }
    }

    private System.Collections.IEnumerator ApplyEffect(CharacterController controller)
    {
        do
        {
            currentVelocity += direction.normalized * acceleration * Time.deltaTime;

            controller.Move(currentVelocity * Time.deltaTime);

            yield return null;
        } while (!controller.isGrounded);
    }

    
}

