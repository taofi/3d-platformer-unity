using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBlock : MonoBehaviour, IActivatable
{
    private Renderer blockRenderer;
    [SerializeField]
    private Color orangeColor;
    [SerializeField]
    private Color redColor = Color.red;
    [SerializeField]
    private Color whiteColor = Color.white;


    [SerializeField]
    private int damageAmount;

    private float lastActivationTime = -Mathf.Infinity; 
    [SerializeField]
    private float activationCooldown ; 

    void Start()
    {
        blockRenderer = GetComponent<Renderer>();
    }

    public void ActivateBlock()
    {
        
        if (Time.time - lastActivationTime >= activationCooldown)
        {
            lastActivationTime = Time.time; 
            StartCoroutine(ChangeColorAndDealDamage());
        }
    }

    private IEnumerator ChangeColorAndDealDamage()
    {
        blockRenderer.material.color = orangeColor;

        yield return new WaitForSeconds(1f);

        blockRenderer.material.color = redColor;
        DealDamageToPlayersOnBlock();

        yield return new WaitForSeconds(0.7f);

        blockRenderer.material.color = whiteColor;
    }

    private void DealDamageToPlayersOnBlock()
    {
        Vector3 boxCenter = transform.position + new Vector3(0, 1f, 0);
        Collider[] colliders = Physics.OverlapBox(boxCenter, transform.localScale / 2);

        foreach (Collider collider in colliders)
        {
            PlayerStats playerStats = collider.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damageAmount);
            }
        }
    }
}
