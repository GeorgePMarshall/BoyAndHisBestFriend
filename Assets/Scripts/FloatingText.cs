using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour {

    TextMesh textMesh;
    [SerializeField]GameObject player;
    [SerializeField]Vector3 offset;
    [SerializeField]GameObject backDrop;

    bool showText = false;
    string textToShow;
    float timer;

	// Use this for initialization
	void Start ()
    {
        textMesh = GetComponent<TextMesh>();
        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
        backDrop.transform.localScale = new Vector3(getTextWidth(textMesh) / 50, 1, 2.5f);


        if (timer <= 1)
            timer += Time.deltaTime;

        if(showText)
        {
            textMesh.text = textToShow;
            showText = false;
            timer = 0;
        }
        else if(timer >= 1)
        {
            textMesh.text = "";
        }

    }

    float getTextWidth(TextMesh mesh)
    {

        float width = 0;

        foreach(char character in mesh.text)
        {
            CharacterInfo info;
            if(mesh.font.GetCharacterInfo(character, out info, 100, FontStyle.Bold))
            {
                width += info.advance;
            }

        }

        return width;

    }

    public void showTextThisFrame(string textToShow)
    {
        Debug.Log("showing text: " + textToShow);

        this.textToShow = textToShow;
        showText = true;
    }


}
