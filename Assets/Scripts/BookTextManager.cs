using UnityEngine;
using System.Collections;

public class BookTextManager : MonoBehaviour {

    [SerializeField]int lineLength;
    [SerializeField]float timePerLetter;
    [SerializeField]string text;
    [SerializeField]string wrappedText;
    [SerializeField]bool isCredits;

    string creditsText = "Credits:\n\nDesigner:\nJake Cunningham\nProgrammers:\nGeorge Marshall\nJoel Hadfield\nArtists:\nJesse Taplin\nSteph Andersen\nJoseph Christian\nRyan Sarah\n\nThanks For Playing";

    float timer;
    int curIndex = 0;
    bool shouldWrite = true;

    AudioSource pageWriteSound;

	// Use this for initialization
	void Start ()
    {
        pageWriteSound = GameObject.Find("PageWritingAudio").GetComponent<AudioSource>();

        if(isCredits)
            wrappedText = creditsText;
        else
            wrappedText = ResolveTextSize(text, lineLength);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= timePerLetter)
        {
            timer += Time.deltaTime;
        }

        if (timer > timePerLetter && curIndex < wrappedText.Length && shouldWrite)
        {
            GetComponent<TextMesh>().text = GetComponent<TextMesh>().text + wrappedText[curIndex];
            curIndex++;
            timer = 0;
        }

        if (curIndex >= wrappedText.Length)
        {
            shouldWrite = false;
            //pageWriteSound.Stop();
        }
    }

    //wraps text at intervals
    string ResolveTextSize(string input, int lineLength)
    {
        string[] words = input.Split(" "[0]);


        string curLine = "";
        string result =  "";

        foreach(string s in words)
        {
            int futureLineLength = curLine.Length + s.Length + 1;

            if(futureLineLength > lineLength)
            {
                result += curLine + "\n";
                curLine = s;
            }
            else
            {
                curLine += " " + s;
            }

        }

        result += curLine + "\n";


        return result;

    }

    //starts the book writing the text
    public void reWriteText()
    {
        //pageWriteSound.Play();
        Debug.Log("ReWriting" + gameObject.name);
        shouldWrite = true;
        GetComponent<TextMesh>().text = "";
        timer = -2;
        curIndex = 0;
    }

    public void pauseTextWriting()
    {
        shouldWrite = false;
    }

}
