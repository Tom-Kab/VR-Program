using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultPassword : MonoBehaviour
{
    public string password;
    public Text field;
    
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        input.onEndEdit.AddListener(CheckPassword);
    }

    public void CheckPassword(string arg0)
    {
        Debug.Log(arg0);
    }
}
