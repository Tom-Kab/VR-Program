using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;
using System;
using TMPro;

public class PasswordValidity : MonoBehaviour
{
  public string password = "qwerty";
  public GameObject inputTextField;
  public GameObject newPasswordField;
  [SerializeField] private UnityEvent myTrigger;
  [SerializeField] private UnityEvent changeTrigger;


  public void CheckPasswordAndLoadScene()
  {
    if (inputTextField.GetComponent<TMP_InputField>().text == password)
    {
      myTrigger.Invoke();
    }
    else
    {
      Debug.Log("Wrong password");
    }
  }

  public void ChangePassword(){
    password = newPasswordField.GetComponent<TMP_InputField>().text;
    changeTrigger.Invoke();
  }
}