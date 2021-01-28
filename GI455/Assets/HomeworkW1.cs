using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeworkW1 : MonoBehaviour
{
    public InputField Input;
    public Text Output;
    public GameObject Name;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void Search()
    {
        Hashtable Data = new Hashtable();
        Data.Add("Youtube", "Youtube");
        Data.Add("Facebook", "Facebook");
        Data.Add("Spotify", "Spotify");
        Data.Add("Netflix", "Netflix");
        Data.Add("Pornhub", "Pornhub");

        foreach(string x in Data.Keys)
        {
            if (Name = GameObject.Find(Input.text))
            {
                Output.text = Input.text + " is found";
            }

            else
            {
                Output.text = Input.text + " is not found";
            }
        }
    }
}
