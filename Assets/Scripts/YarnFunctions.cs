using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;


public class YarnFunctions : MonoBehaviour
{
   [YarnCommand("Test")]
   public void Test(){

    Debug.Log($"Test {name}");

   }
}
