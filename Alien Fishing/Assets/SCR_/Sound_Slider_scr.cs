using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound_Slider_scr : MonoBehaviour
{
    public Text Sound_slider_text = null;
    // Start is called before the first frame update
    void Start()
    {
        Sound_slider_text.text = this.GetComponent<Slider>().value + "/" + this.GetComponent<Slider>().maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        int f = (int)this.GetComponent<Slider>().value;
        Sound_slider_text.text = f + "/" + this.GetComponent<Slider>().maxValue;
        Debug.Log("This slider = " + f);
    }

    public void sliderMove(float f)
    {
        //Debug.Log("slider = "+f);
    }
}
