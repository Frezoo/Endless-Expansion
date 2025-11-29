using System;
using UnityEngine;
using YG;

public class OrbitalMirror : MonoBehaviour
{
    private void Awake()
    {
        CheckOrbitalMirrorCondition();
    }

    private void CheckOrbitalMirrorCondition()
    {
        gameObject.SetActive(YG2.saves.OrbitalMirrorIsBuilded);
    }
}
