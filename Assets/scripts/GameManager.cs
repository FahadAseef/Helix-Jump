using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Text scoretext;
    public Text bestscoretext;
    public static bool isgmdestroyed;
    public Material helixmat;
    public Color[] colours;
    public Material maincolor;
    public Material dangercolor;
    public GameObject helixcheese;
    public Transform helixparent;
    public Material endmaterial;
    public static int helixvalue=10;

    private void Awake()
    {
        //if (!isgmdestroyed)
        //{
        //    DontDestroyOnLoad(this.gameObject);
            gm = this;
        //    isgmdestroyed = true;
        //}
    }

    private void Start()
    {
        bestscoretext.text = "best score : " + PlayerPrefs.GetInt("bestscores");
        scoretext.text = "" + ballcontroller.score;
        sethelixmatcolor();
        helixcheeselevel();
    }

    public void sethelixmatcolor()
    {
     helixmat.color= colours[Random.Range(0,colours.Length)];
    }

    public void helixcheeselevel()
    {
        for(int i = 0; i < helixvalue; i++)
        {
          GameObject currenthelix =  Instantiate(helixcheese, helixparent);
            currenthelix.transform.localPosition = new Vector3(0.54f,0.4f-(i*.50f),-0.43f);
            if (i == 0)
            {
                int randomvalue = Random.Range(0, helixvalue);
                currenthelix.transform.GetChild(randomvalue).gameObject.SetActive(false);
            }
            else if (i == helixvalue-1)
            {
                setlastcolor(currenthelix,true);
            }
            else
            {
                sethelixprefab(currenthelix);
            }
        }
    }

    void setlastcolor(GameObject helix ,bool islast)
    {
        for(int i = 0; i < helix.transform.childCount; i++)
        {
            helix.transform.GetChild(i).gameObject.GetComponentInChildren<Renderer>().material = endmaterial;
            if (islast==true)
            {
                helix.transform.GetChild(i).gameObject.tag = "lastcheese";
            }
        }
        
    }   

    public void sethelixprefab(GameObject helix)
    {
        int dangerobjnumber = Random.Range(1, 5);
        int holeobjnumber = Random.Range(1, 4);
        int[] array = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, };
        for (int i = 0; i < dangerobjnumber; i++)
        {
            int randvalue = array[Random.Range(0, array.Length)];
            helix.transform.GetChild(randvalue).gameObject.GetComponentInChildren<Renderer>().material = dangercolor;
            helix.transform.GetChild(randvalue).gameObject.tag = "danger";
        }
        for (int i = 0; i < holeobjnumber; i++)
        {
            int randvalue = array[Random.Range(0, array.Length)];
            helix.transform.GetChild(randvalue).gameObject.SetActive(false);
            helix.transform.GetChild(randvalue).gameObject.tag = "hole";
        }
    }

    public void gameover()
    {
        ballcontroller.score = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void levelchanged()
    {
        helixvalue += 5;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
