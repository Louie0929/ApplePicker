/****
 * Created By: Xingzhou Li
 * Date Created: 1/31/2022
 * 
 * Last Edited: 2/7/2022
 * Edited by: Xingzhou Li
 * 
 * Description: Camera of bskets
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    // Start is called before the first frame update
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    } // end Start
    public void AppleDestroyed()
    {
        // Destroy all of the falliing apples
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray)
        {
            Destroy(tGO);
        }
        int basketIndex = basketList.Count - 1; // Destroy one of the baskets 
        GameObject tBasketGO = basketList[basketIndex]; // Get a reference to that Basket GameObject
        basketList.RemoveAt(basketIndex); // Remove the basket from the list and destroy the GameObject
        Destroy(tBasketGO);
        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
    } // end AppleDestroyed()
}
