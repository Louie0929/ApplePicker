/****
 * Created By: Xingzhou Li
 * Date Created: 1/31/2022
 * 
 * Last Edited: 2/7/2022
 * Edited by: Xingzhou Li
 * 
 * Description: Controls apple movement
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;


    // Update is called once per frame
    void Update()
    {
      if (transform.position.y < bottomY)
        {
            Destroy(this.gameObject);
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>(); // Get the reference to
                                                                            // the ApplePicker component of Main
                                                                            // Camera
            apScript.AppleDestroyed(); // Call the public AppleDestroyed() method of apScript
        }  
    } // end Update
}
