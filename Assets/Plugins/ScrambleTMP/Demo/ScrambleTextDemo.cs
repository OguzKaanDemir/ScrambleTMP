using TMPro;
using UnityEngine;
using ScrambleTMP.Scripts;

public class ScrambleTextDemo : MonoBehaviour
{
    public ScrambleData.Language language1;
    public ScrambleData.Language language2;
    public ScrambleData.Language language3;
    public ScrambleData.Language language4;
    public string text1;
    public string text2;
    public string text3;
    public string text4;
    public TMP_Text tmpText1;
    public TMP_Text tmpText2;
    public TextMeshProUGUI tmpuguiText1;
    public TextMeshProUGUI tmpuguiText2;

    void Start()
    {
        Test();
        tmpText2.ScrambleText(text2, language2, false, 3, 10);

        // _ = for no green line
        _ = tmpuguiText2.ScrambleText(text4, language4, true, 2);

        tmpuguiText1.ScrambleText(text3, language3);
    }

    private async void Test()
    {
        await tmpText1.ScrambleText(text1, language1, true, 5, 15, 0.01f);
        Debug.Log("tmpText1 Done");
    }
}
