using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyEffect : MonoBehaviour
{
    private ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (ps && !ps.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
