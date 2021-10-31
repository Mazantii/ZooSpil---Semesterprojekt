using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // hentet saa vi kan benytte UI

public class PlayerHealth : MonoBehaviour
{

    public float Health = 4f; //Antal liv spilleren har i starten.
    public Slider Slider; // vores slider altsaa livsbar er hvad vi referere til her. Det er den som styre hvor meget af vores fillimage der er fyldt ud.
    public Image FillImage; // vi vil skifte farve paa livsbaren alt efter hvor meget liv vi har, derfor skal vi kunne have adgang til det billede.
    public Color FullHealthColor = Color.green; // Her har vi lavet en variabel til naer spilleren har fuldt liv, og givet den en groen farve.
    public Color NoHealthColor = Color.red; // her er det omvendt, imod 0 liv og roed farve.

    private float CurrentHealth; //spillerens liv.
    public bool Dead; // siger sig selv, veardi til at se om spilleren har 0 health.

    private void OnEnable()
    {
        CurrentHealth = Health; // Her giver vi spilleren det liv som vi har set i Health, saa vi kan holde oeje med det loebene.
        Dead = false; // Det ville blive et kort spil hvis spilleren doede onenable

        SetHealthUI(); // opdatere livsbaren
    }

    public void TakeDamage(float amount)
    {
        //her tager spilleren skade
        CurrentHealth -= amount; // her traekker vi den skade spilleren har taget, fra dens liv.

        SetHealthUI(); // opdatere livsbaren

        if(CurrentHealth <= 0f && !Dead) // vi tjekker om spilleren doer af skaden, og om spilleren ikke allerede er doed.
        {
            OnDeath(); //her kalder vi denne funktion, som "Dreaber" spilleren.
        }
    }

    private void SetHealthUI()
    {
        //Her saetter vi vaerdien af slideren og farven.
        Slider.value = CurrentHealth; // her saetter vi slideren til den samme vaerdi som spillerens liv, saa det er synligt hvor meget liv spilleren har tilbage.

        FillImage.color = Color.Lerp(NoHealthColor, FullHealthColor, CurrentHealth / Health); // Visualiseringen af slideren. Lerp blander farverne, og til sidst vaelger vi hvor meget af hver farve vi skal bruge.
    }

    private void OnDeath()
    {
        // her doer spilleren
        Dead = true; //vi saetter den til true med det samme, saa den ikke bliver brugt mere end en gang.

        gameObject.SetActive(false); // her slaar vi spillern fra.
    }
}
