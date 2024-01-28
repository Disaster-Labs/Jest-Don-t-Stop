using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "FallingObjects")
        {
            Debug.Log("Item hit floor!");
            GameManager.Singleton.update_hits(1, "fail");
            Destroy(col.gameObject);
        }
    }
}
