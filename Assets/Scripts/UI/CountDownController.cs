using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownController : MonoBehaviour
{
    public int countDownTime;
    public TextMeshProUGUI countDownText;
    public GameObject fadeIn;
    public AudioSource countSound;
    public AudioSource goSound;
    
    void Start()
    {
        PlayerController.forwardSpeed = 0f;
        StartCoroutine(CountDownToStart());
    }

    public IEnumerator CountDownToStart()
    {
        yield return new WaitForSeconds(1f);
        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();
            countSound.Play();
            yield return new WaitForSeconds(1f);

            countDownTime -= 1;
        }

        countDownText.text = "GO!";
        goSound.Play();
        yield return new WaitForSeconds(1f);
        countDownText.text = "";

        PlayerController.forwardSpeed = EventsManager.speedAtDeath;
        PlayerController.horizontalSpeed = EventsManager.hSpeedAtDeath;
        PlayerController.verticalSpeed = EventsManager.vSpeedAtDeath;
        PlayerController.canMove = true;
        ShootingController.canShoot = true;
        countDownTime = 3;
    }
}
