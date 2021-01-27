
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (player.position.z < 500)
        {
            scoreText.text = player.position.z.ToString("0");
        }
        else
        {
            scoreText.text = "500";
        }
    }
}
