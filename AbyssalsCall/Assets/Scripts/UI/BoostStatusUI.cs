using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostStatusUI : MonoBehaviour
{
    [SerializeField]
    private Slider BoostChargePrefab;

    private List<Slider> activeBoostSliders = new List<Slider>();

    public void UpdateCharge(float NewChargeValue)
    {
        Debug.Log(NewChargeValue);
        while(activeBoostSliders.Count > Mathf.CeilToInt(NewChargeValue))
        {
            Destroy(activeBoostSliders[activeBoostSliders.Count - 1].gameObject);
            activeBoostSliders.RemoveAt(activeBoostSliders.Count - 1);
        }

        int i = 0;
        while(i < NewChargeValue)
        {
            if(activeBoostSliders.Count < NewChargeValue)
            {
                activeBoostSliders.Add(Instantiate<Slider>(BoostChargePrefab, Vector3.zero, Quaternion.identity, transform));
            }
            activeBoostSliders[i].value = Mathf.Clamp01(NewChargeValue - i);
            i += 1;
        }
    }
}
