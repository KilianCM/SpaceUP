using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkingEngine : MonoBehaviour
{
    public ClickAction oxygen;
    public ClickAction rp1;
    public Igniter igniter;
    public Material OXLiquidMaterial;
    public Material RP1LiquidMaterial;
    public float consumption = 0.1f;
    public ParticleSystem particle;
    public float fillAmount = -0.4f;
    public float emptyAmount = 1.4f;
    public ParticleSystem OXFlow;
    public ParticleSystem RP1Flow;
    public GameObject successPopUp;
    public GameObject mainMenuBtn;

    private bool isStarted = false;
    private bool alreadySucceed = false;

    private void Start()
    {
        OXLiquidMaterial.SetFloat("_FillAmount", fillAmount);
        RP1LiquidMaterial.SetFloat("_FillAmount", fillAmount);

        consumption *= -1;//invert consuption for correct display
    }
    // Update is called once per frame
    void Update()
    {
        if (OxOn())
        {
            OXFlow.Play();
            OXLiquidMaterial.SetFloat("_FillAmount", OXLiquidMaterial.GetFloat("_FillAmount") - (consumption * Time.deltaTime));
        }else { 
            OXFlow.Stop(); 
        }
        if (RP1On()) {
            RP1Flow.Play();
            RP1LiquidMaterial.SetFloat("_FillAmount", RP1LiquidMaterial.GetFloat("_FillAmount") - (consumption * Time.deltaTime));

        }else {
            RP1Flow.Stop(); 
        }
        if (OxOn() && RP1On() && (igniter.isOn || isStarted)){
            isStarted = true;
            particle.Play();
            if (!alreadySucceed){
                alreadySucceed = true;
                Invoke("DisplaySuccessPopUp", 3);
            }
        }
        else{
            isStarted = false;
            particle.Stop();
        }
    }

    bool OxOn()
    {
        return oxygen.isActive && OXLiquidMaterial.GetFloat("_FillAmount") < emptyAmount;
    }
    bool RP1On()
    {
        return rp1.isActive && RP1LiquidMaterial.GetFloat("_FillAmount") < emptyAmount;
    }

    void DisplaySuccessPopUp()
    {
        mainMenuBtn.SetActive(true);
        successPopUp.SetActive(true);
    }
}
