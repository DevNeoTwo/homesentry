using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarnivel : MonoBehaviour
{
    [SerializeField] string nivel;
    audiomanager audiomanagerscript;
    
    public void cambiaescena()
    {
        
            
            SceneManager.LoadScene(nivel);
        
    }
    
}
