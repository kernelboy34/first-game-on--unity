using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{
    public GameObject menu;
    public GameObject gameovermenu;
    public GameObject col;
    public GameObject piedra;
    public GameObject piedra2;
    public GameObject obstaculo2;
    public Renderer fondi;
    public List <GameObject> cols;
    public List <GameObject> obstaculo;
    public bool gameOver=false;
    public bool start = false;
    void Start()
    {
        for(int i =0;i<21;i++){
            cols.Add(Instantiate(col,new Vector2(-10+i,-3), Quaternion.identity));
        }
        obstaculo.Add(Instantiate(piedra,new Vector2(14,-2), Quaternion.identity));
        obstaculo.Add(Instantiate(piedra2,new Vector2(18,-2), Quaternion.identity));
        obstaculo.Add(Instantiate(obstaculo2,new Vector2(15 ,-2), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
     if (start== false){
        if(Input.GetKeyDown(KeyCode.X)){
            start = true;
        }

     }
     if (start== true && gameOver == true){
        gameovermenu.SetActive(true);

        if(Input.GetKeyDown(KeyCode.X)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

     }
     if (start == true && gameOver == false){
        menu.SetActive(false);
       fondi.material.mainTextureOffset = fondi.material.mainTextureOffset + new Vector2(0.01f,0) * Time.deltaTime;
       for(int i =0;i<cols.Count;i++){
        if(cols[i].transform.position.x <= -10){
            
            cols[i].transform.position = new Vector3(10,-3,0);
        }
            cols[i].transform.position = cols[i].transform.position +new Vector3(-1,0,0)* Time.deltaTime*2;
        }
        for(int i =0;i<obstaculo.Count;i++){
        if(obstaculo[i].transform.position.x <= -10){
            float randomObs = Random.Range(11,18);
            obstaculo[i].transform.position = new Vector3(randomObs,-2,0);
        }
            obstaculo[i].transform.position = obstaculo[i].transform.position +new Vector3(-1,0,0)* Time.deltaTime*2;
        }
     }
    }
}
