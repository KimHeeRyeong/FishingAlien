using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodAnimationEvent : MonoBehaviour
{
    [HideInInspector]public bool active = true;
    [HideInInspector] public bool parabolaActive = false;
    [SerializeField] GameObject parabola;
    private void Update()
    {
        if (parabolaActive != parabola.activeSelf)
            parabola.SetActive(parabolaActive);

        if(!active)
            gameObject.SetActive(active);

    }
}
