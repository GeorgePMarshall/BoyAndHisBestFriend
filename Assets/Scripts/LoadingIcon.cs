using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingIcon : MonoBehaviour {

    public float loadingPercentage;
    public float fillAmount;


    Image loadingIcon;

	// Use this for initialization
	void Start ()
    {
        loadingIcon = GetComponent<Image>();


        loadingIcon.type = Image.Type.Filled;
        loadingIcon.fillMethod = Image.FillMethod.Vertical;
        loadingIcon.fillAmount = 0;

    }
	
	// Update is called once per frame
	void Update ()
    {
        loadingIcon.fillAmount = Mathf.Lerp(loadingIcon.fillAmount, loadingPercentage, Time.deltaTime);
        fillAmount = loadingIcon.fillAmount;
	}
}
