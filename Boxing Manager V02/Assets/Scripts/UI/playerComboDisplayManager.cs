using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerComboDisplayManager : MonoBehaviour
{
    public Button oneTwoButton;
    public player PlayerOne;

    //Kontrollerar vilka Combos som är upplåsta av spelaren

    public void checkForActiveCombos()
    {
        if (PlayerOne.oneTwoUnlocked == false)
        {
            oneTwoButton.gameObject.SetActive(false);
        }

        else
            oneTwoButton.gameObject.SetActive(true);
    }
    public void checkForActiveCombosButton()
    {
        if (PlayerOne.oneTwoUnlocked == false)
        {
            ColorBlock colors = oneTwoButton.colors;
            colors.normalColor = Color.red;
            colors.highlightedColor = new Color32(255, 100, 100, 255);
            oneTwoButton.colors = colors;
        }
    }
}
