using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackHeadManager : MonoBehaviour
{
    public GameObject attackHeadPlaceholder;
    
    public GameObject playerOneLeftHand;
    public GameObject playerOneRightHand;
    public Texture playerOneLeftGlove;
    public Texture playerOneRightGlove;

    public GameObject playerTwoLeftHand;
    public Texture playerTwoLeftGlove;
    public GameObject playerTwoRightHand;
    public Texture playerTwoRightGlove;

    private void Start()
    {
        /*
        attackHeadPlaceholder.SetActive(false);
        playerOneLeftHand.GetComponent<RawImage>().texture = playerOneLeftGlove;
        playerOneLeftHand.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));

        playerOneRightHand.GetComponent<RawImage>().texture = playerOneRightGlove;
        playerOneRightHand.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, -90));
        
        playerTwoLeftHand.GetComponent<RawImage>().texture = playerTwoLeftGlove;
        playerTwoLeftHand.GetComponent<RectTransform>().Rotate(new Vector3(180, 0, 90));
        */
        playerTwoRightHand.GetComponent<RawImage>().texture = playerTwoRightGlove;
        playerTwoRightHand.GetComponent<RectTransform>().Rotate(new Vector3(0, -180, -90));
    }

    public void playerOneJab()
    {
        attackHeadPlaceholder.SetActive(true);
        playerOneLeftHand.SetActive(true);

    }

    
    public void playerOneCross()
    {
        attackHeadPlaceholder.SetActive(true);
        playerOneRightHand.SetActive(true);
        

    }
    
    public void inactiveImage()
    {
        attackHeadPlaceholder.SetActive(false);
        playerOneLeftHand.SetActive(false);
       
    }
    
}
