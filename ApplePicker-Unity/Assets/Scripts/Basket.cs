/****
 * Created By: Xingzhou Li
 * Date Created: 1/31/2022
 * 
 * Last Edited: 2/10/2022
 * Edited by: Xingzhou Li
 * 
 * Description: Adding point when successfully catch apple
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // This line enables use of uGUI feature

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter"); // Get the Text Component of
                                                              // that GameObject
        scoreGT = scoreGO.GetComponent<Text>(); // Set the starting number of points to 0
        scoreGT.text = "0";
    } // end Start

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition; // get the current screen position
                                                  // of the mouse from Input
        mousePos2D.z = -Camera.main.transform.position.z; // The Camera's z position
                                                          // sets how far to push the mouse into 3D
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D); // Convert the point from 2D
                                                                         // screen space into 3D game world space
        Vector3 pos = this.transform.position; // Move the x position of this
                                               // Basket to the x position of the Mouse
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    } // end Update
    //Find out what hit this basket
    void OnCollisionEnter(Collision coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text); // Parse the text of the scoreGT into an int
            score += 100; // Add points for catching the apple
            scoreGT.text = score.ToString(); // Convert the score back to a
                                             // string and display it
            if (score > HighScore.score)
            {
                HighScore.score = score; // track the high score
            }
        }
    } // end OnCollisionEnter
}
