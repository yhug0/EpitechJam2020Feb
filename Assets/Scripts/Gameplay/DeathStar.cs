using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathStar : MonoBehaviour
{
    public Slider slider;

    public int damage = 40;

    public void Start()
    {
    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "planet")
            return;
        slider.value -= damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= 0)
        {
             SceneManager.LoadScene("Loose");
        }
    }
}
