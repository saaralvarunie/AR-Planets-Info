using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIandSound : MonoBehaviour
{
    public TMP_Text infoBox;

    public AudioClip Marsclip1;
    public AudioClip Marsclip2;
    public AudioClip Marsclip3;

    private AudioSource audioSource;

    private string UIState = "void"; // Starting point
    private int infoID = 1; // Pointer to info text

    private string marsText1 = "Mars, our closest neighbour and possibly humanity's next home";
    private string marsText2 = "Mars is also known as the Red Planet\n"
                             + "Mars is named after the Roman god of war\n"
                             + "Mars is smaller than Earth with a diameter of 4217 miles";
    private string marsText3 = "ToDo: Add more information here.";

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                string tag = hit.transform.tag;

                if (tag == "mars")
                {
                    UIState = "Mars";
                    infoID = 1;
                    infoBox.text = marsText1;
                    audioSource.PlayOneShot(Marsclip1, 1f);
                }
                else if (tag == "earth")
                {
                    UIState = "Earth";
                    infoBox.text = "Earth\nMostly Harmless!";
                }
                else if (tag == "marsInfo" || tag == "earthInfo")
                {
                    Destroy(hit.transform.gameObject);
                    UIState = "void";
                    infoBox.text = "Select a Planet";
                }
            }
        }
    }

    public void nextButton()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (UIState == "Mars")
        {
            switch (infoID)
            {
                case 1:
                    infoID = 2;
                    infoBox.text = marsText2;
                    audioSource.PlayOneShot(Marsclip2, 1f);
                    break;
                case 2:
                    infoID = 3;
                    infoBox.text = marsText3;
                    // Uncomment when clip is available:
                    // audioSource.PlayOneShot(Marsclip3, 1f);
                    break;
                default:
                    break;
            }
        }
        else if (UIState == "Earth")
        {
            // You can add Earth info cycling here
        }
    }
}
