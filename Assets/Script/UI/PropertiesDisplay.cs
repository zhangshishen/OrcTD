using UnityEngine;
using System.Collections;

using UnityEngine.UI;


//a mutable class that change every frame
public class PropertiesDisplay : MonoBehaviour
{
    // Use this for initialization
    public Image[] img;
    public Text[] txt;
    public string[] val;

    public MonsterProperties mosprop;

    float initlen = 10.0f;
    void Awake()
    {
        int i = 0;
        if(img.Length!=val.Length){
            return;
        }
        foreach(Image image in img){
            image.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,initlen + 20.0f * i++);

        }
    }
    void Start()
	{

	}
    private void updateValue(){
        
    }

	// Update is called once per frame
	void Update()
	{
        updateValue();

		int i = 0;
		if (img.Length != val.Length)
		{
			return;
		}
		foreach (Text text in txt)
		{
            text.text = val[i++];
		}
	}
}
