using UnityEngine;
using System.Collections;


//effect class ,every effect should be singleton

public interface Effect
{
    // Use this for initialization

    Effect GetEffect();

    float GetTime();
    float GetAttackInfluence();
    float GetArmorInfluence();
    float GetSpeedInfluence();
    float GetFrequencyInfluence();
    float GetRangeInfluence();

}
