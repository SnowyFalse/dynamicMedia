using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MessageProcesser : MonoBehaviour
{
    
    // Old version in UI
    /*
    [SerializeField] 
    private Image img;
    
    [SerializeField] 
    private Sprite fox;
    
    [SerializeField] 
    private Sprite seal;
    */
    
    // new version with textures
    [SerializeField] 
    private GameObject podest;
    
    [SerializeField] 
    private GameObject areaWolf;
    
    [SerializeField] 
    private GameObject areaEagle;
    
    [SerializeField] 
    private GameObject areaCapricorn;
    
    [SerializeField] 
    private GameObject areaBeaver;
    
    [SerializeField] 
    private GameObject areaLynx;
    
    
    
    
    
    // Invoked when a line of data is received from the serial device.
    void OnMessageArrived(string msg)
    {
        string processedmsg = msg.Substring(1, msg.Length - 1);;
        Debug.Log("Message arrived and changed: " + msg);
        // _title.text = processedmsg;
        podest.SetActive(false);
        areaWolf.SetActive(false);
        areaEagle.SetActive(false);
        areaCapricorn.SetActive(false);
        areaBeaver.SetActive(false);
        areaLynx.SetActive(false);
        if (processedmsg.Equals("041A2CE2D101"))
        {
            // Wolf
            Debug.Log("Wolf scanned");
            areaWolf.SetActive(true);
            podest.SetActive(true);
            StopCoroutine(SpawnerDestruction());
            StartCoroutine (SpawnerDestruction());

        } else if (processedmsg.Equals("0419CD58C048"))
        {
            // Eagle
            Debug.Log("Eagle scanned");
            areaEagle.SetActive(true);
            podest.SetActive(true);
            StopCoroutine(SpawnerDestruction());
            StartCoroutine (SpawnerDestruction());

        } else if (processedmsg.Equals("0419CE7A7ED7"))
        {
            // Beaver
            Debug.Log("Beaver scanned");
            areaBeaver.SetActive(true);
            podest.SetActive(true);
            StopCoroutine(SpawnerDestruction());
            StartCoroutine (SpawnerDestruction());

        } else if (processedmsg.Equals("0419CE7BFA52"))
        {
            // Capricorn
            Debug.Log("Capricorn scanned");
            areaCapricorn.SetActive(true);
            podest.SetActive(true);
            StopCoroutine(SpawnerDestruction());
            StartCoroutine (SpawnerDestruction());

        } else if (processedmsg.Equals("0419CE7BD27A"))
        {
            // Lynx
            Debug.Log("Lynx scanned");
            areaLynx.SetActive(true);
            podest.SetActive(true);
            StopCoroutine(SpawnerDestruction());
            StartCoroutine (SpawnerDestruction());

        }
        else
        {
            //img.sprite = null;
            areaWolf.SetActive(false);
            areaEagle.SetActive(false);
            podest.SetActive(false);

        }
        
    }
    
    IEnumerator SpawnerDestruction(){

        yield return new WaitForSeconds (60);
        podest.SetActive(false);

    }
    
    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        if (success)
            Debug.Log("Connection established");
        else
            Debug.Log("Connection attempt failed or disconnection detected");
    }
}
