using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManager : MonoBehaviour
{
    // Start is called before the first frame update
	
    public TextMeshProUGUI textMesh;
    public static TextManager instance;
    int score;
	
    public void IncreaseScore(){
         score++;
	textMesh.text = "Alton bag: " + score;
    }
 
    void Start()
    {
	if(instance == null){
	  instance = this;
}
        score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
