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

    public Text rawInputText;
    public Text normalizedInputText;

    public Button sphereButton;
    public Button cubeButton;

    public Text StreamNameLabel;
    public Text StreamTypeLabel;

    public GameObject sphereGroup;
    public GameObject cubeGroup;
    public GameObject audioFB;

    public Camera mainCamera;

    public GameObject audioFBText;

    //private bool firstTime = true;
    private bool lookAtSphere = true;

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

    //for the sphereButton
    public void sphereFBOn()
    {
        //if (!sharedMenu.activeInHierarchy)
        //    sharedMenu.SetActive(true);

        cubeMenu.SetActive(false);        
        sphereMenu.SetActive(true);

        //sphereButton.enabled = false;
        //cubeButton.enabled = true;

        cubeGroup.SetActive(false);
        audioFB.SetActive(false);
        audioFBText.SetActive(false);
        sphereGroup.SetActive(true);

        if (!lookAtSphere)
        {
            mainCamera.transform.Rotate(new Vector3(0, 180, 0));
            lookAtSphere = true;
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

        //cubeButton.enabled = false;
        //sphereButton.enabled = true;

        sphereGroup.SetActive(false);
        audioFB.SetActive(false);
        audioFBText.SetActive(false);
        cubeGroup.SetActive(true);

        if (lookAtSphere)
        {
            mainCamera.transform.Rotate(new Vector3(0, 180, 0));
            lookAtSphere = false;
        }
        

        //if (firstTime)
         //   firstTime = false;
        //Debug.Log("ANGOLO y: " + mainCamera.transform.eulerAngles.y);
    }

    public void audioFBOn()
    {
        sphereMenu.SetActive(false);
        cubeMenu.SetActive(false);

        sphereGroup.SetActive(false);
        cubeGroup.SetActive(false);

        audioFB.SetActive(true);
        audioFBText.SetActive(true);

    }

        public void loadMainScene()
    {
        SceneManager.LoadScene("settings");
    }

}
