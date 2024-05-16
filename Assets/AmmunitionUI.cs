using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUI : MonoBehaviour
{
    public Text ammunitionText; // Reference to the Text component in the UI

    // Update the ammunition count in the UI
    public void UpdateAmmunitionCount(int ammunitionCount)
    {
        if (ammunitionText != null)
        {
            ammunitionText.text = "Ammunition: " + ammunitionCount.ToString(); // Update the text
        }
    }
}