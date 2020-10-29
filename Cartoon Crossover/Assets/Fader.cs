using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fadeImage;

    public Animator anim;
    // Start is called before the first frame update

    public void Fade(string destination)
    {
        StartCoroutine(Fading(destination));
    }
    public IEnumerator Fading(string destination)
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        SceneManager.LoadScene(destination, LoadSceneMode.Single);
    }
}
