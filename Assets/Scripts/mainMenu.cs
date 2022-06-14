using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class mainMenu : MonoBehaviour {

    public LSLReceiver receiver;

    public GameObject sphereMenu;
    public GameObject cubeMenu;
    public GameObject sharedMenu;
    public GameObject spritesMenu;


    public Text rawInputText;
    public Text normalizedInputText;

    public Button sphereButton;
    public Button cubeButton;
    public Button spritesButton;


    public Text StreamNameLabel;
    public Text StreamTypeLabel;

    public GameObject sphereGroup;
    public GameObject cubeGroup;
    public GameObject spritesGroup;
    public GameObject audioFB;

    public Camera mainCamera;

    public GameObject audioFBText;

    //private bool firstTime = true;
    private bool lookAtSprite = true;

    void Start()
    {

        StreamNameLabel.text = receiver.StreamName;
        StreamTypeLabel.text = receiver.StreamType;

    }

    void Update()
    {
        rawInputText.text = receiver.input.ToString();
        normalizedInputText.text = receiver.normalizedInput.ToString();
    }

    //for the spritesButton
    public void spritesFBOn()
    {
        //if (!sharedMenu.activeInHierarchy)
        //    sharedMenu.SetActive(true);

        cubeMenu.SetActive(false);
        sphereMenu.SetActive(false);
        spritesMenu.SetActive(true);

        //sphereButton.enabled = false;
        //cubeButton.enabled = true;

        cubeGroup.SetActive(false);
        audioFB.SetActive(false);
        audioFBText.SetActive(false);
        sphereGroup.SetActive(false);
        spritesGroup.SetActive(true);

        if (!lookAtSprite)
        {
            mainCamera.transform.Rotate(new Vector3(0, 180, 0));
            lookAtSprite = true;
        }

        //if (firstTime)
        //   firstTime = false;
        //else
        //  mainCamera.transform.Rotate(new Vector3(0, 180, 0));

        //Debug.Log("ANGOLO y: " + mainCamera.transform.eulerAngles.y);

    }


    //for the sphereButton
    public void sphereFBOn()
    {
        //if (!sharedMenu.activeInHierarchy)
        //    sharedMenu.SetActive(true);

        cubeMenu.SetActive(false);        
        sphereMenu.SetActive(true);
        spritesMenu.SetActive(false);

        //sphereButton.enabled = false;
        //cubeButton.enabled = true;

        cubeGroup.SetActive(false);
        audioFB.SetActive(false);
        audioFBText.SetActive(false);
        sphereGroup.SetActive(true);
        spritesGroup.SetActive(false);

        if (lookAtSprite)
        {
            mainCamera.transform.Rotate(new Vector3(0, 180, 0));
            lookAtSprite = false;
        }

        //if (firstTime)
         //   firstTime = false;
        //else
          //  mainCamera.transform.Rotate(new Vector3(0, 180, 0));

        //Debug.Log("ANGOLO y: " + mainCamera.transform.eulerAngles.y);

    }

    //for the cubeButton
    public void cubeFBOn()
    {
        //if (!sharedMenu.activeInHierarchy)
        //sharedMenu.SetActive(true);

        sphereMenu.SetActive(false);
        cubeMenu.SetActive(true);
        spritesMenu.SetActive(false);

        //cubeButton.enabled = false;
        //sphereButton.enabled = true;

        sphereGroup.SetActive(false);
        audioFB.SetActive(false);
        audioFBText.SetActive(false);
        cubeGroup.SetActive(true);
        spritesGroup.SetActive(false);

        if (lookAtSprite)
        {
            mainCamera.transform.Rotate(new Vector3(0, 180, 0));
            lookAtSprite = false;
        }
        

        //if (firstTime)
         //   firstTime = false;
        //Debug.Log("ANGOLO y: " + mainCamera.transform.eulerAngles.y);
    }

    public void audioFBOn()
    {
        sphereMenu.SetActive(false);
        cubeMenu.SetActive(false);
        spritesMenu.SetActive(false);

        sphereGroup.SetActive(false);
        cubeGroup.SetActive(false);
        spritesGroup.SetActive(false);

        audioFB.SetActive(true);
        audioFBText.SetActive(true);

    }

        public void loadMainScene()
    {
        SceneManager.LoadScene("settings");
    }

}
