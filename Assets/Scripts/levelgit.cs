using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class levelgit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void leveller(int levelid)
    {
        Application.LoadLevel(levelid);
    }
}
