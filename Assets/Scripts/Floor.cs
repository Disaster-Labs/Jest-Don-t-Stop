using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Singleton.update_hits(1, "fail");
        Destroy(col.gameObject);
    }
}
