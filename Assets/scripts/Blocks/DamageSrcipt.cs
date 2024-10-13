using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSrcipt : MonoBehaviour
{
    public int damage;
    

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
