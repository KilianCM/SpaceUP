using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingEngine : MonoBehaviour
{
    public ClickAction oxygen;
    public ClickAction rp1;
    public Material OXLiquidMaterial;
    public Material RP1LiquidMaterial;
    public float consumption = 0.1f;
    public ParticleSystem particle;
    public float fillAmount = -0.4f;
    public float emptyAmount = 1.4f;
    public ParticleSystem OXFlow;
    public ParticleSystem RP1Flow;

    private void Start()
    {
        OXLiquidMaterial.SetFloat("_FillAmount", fillAmount);
        RP1LiquidMaterial.SetFloat("_FillAmount", fillAmount);

        consumption *= -1;//invert consuption for correct display
    }
    // Update is called once per frame
    void Update()
    {
        if (oxygen.isActive){
            OXFlow.Play();
            OXLiquidMaterial.SetFloat("_FillAmount", OXLiquidMaterial.GetFloat("_FillAmount") - (consumption * Time.deltaTime));
        }
        else { OXFlow.Stop(); }
        if (rp1.isActive) {
            RP1Flow.Play();
            RP1LiquidMaterial.SetFloat("_FillAmount", RP1LiquidMaterial.GetFloat("_FillAmount") - (consumption * Time.deltaTime));

        }
        else { RP1Flow.Stop(); }
        if (oxygen.isActive && rp1.isActive && OXLiquidMaterial.GetFloat("_FillAmount")<emptyAmount)
        {
            particle.Play();
        }
        else
            particle.Stop();
    }
}
