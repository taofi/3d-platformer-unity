using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockActivator : MonoBehaviour
{
    [SerializeField]
    private MonoBehaviour activeBlock;
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player")) // ��������������, ��� ����� ����� ��� "Player"
        {
            IActivatable block = activeBlock as IActivatable;
            block?.ActivateBlock();
        }
    }
}
