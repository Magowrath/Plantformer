using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PlayerController player;
    [SerializeField] private Image totalStarBar;
    [SerializeField] private Image currentStarBar;

    void Start()
    {
        totalStarBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        currentStarBar.fillAmount = player.score * 0.33f;
    }
}
