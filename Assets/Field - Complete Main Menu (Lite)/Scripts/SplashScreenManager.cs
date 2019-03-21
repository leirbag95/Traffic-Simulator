using UnityEngine;

public class SplashScreenManager : MonoBehaviour {

    [Header("RESOURCES")]
    public GameObject splashScreen;
    public GameObject splashScreenLogin;
    public GameObject splashScreenRegister;
    public GameObject mainPanels;
    private Animator mainPanelsAnimator;

    [Header("SETTINGS")]
    public bool isLoggedIn;
    public bool alwaysShowLoginScreen = true;
    public bool disableSplashScreen;

    void Start ()
    {
        if (disableSplashScreen == true)
        {
            splashScreen.SetActive(false);
            splashScreenLogin.SetActive(false);
            splashScreenRegister.SetActive(false);
            mainPanels.SetActive(true);

            mainPanelsAnimator = mainPanels.GetComponent<Animator>();
            mainPanelsAnimator.Play("Main Panel Opening");
        }

        else if (isLoggedIn == false && alwaysShowLoginScreen == true)
        {
            splashScreen.SetActive(false);
            splashScreenLogin.SetActive(true);
            splashScreenRegister.SetActive(true);
        }

        else if (isLoggedIn == false && alwaysShowLoginScreen == false)
        {
            splashScreen.SetActive(false);
            splashScreenLogin.SetActive(true);
            splashScreenRegister.SetActive(true);
        }

        else if (isLoggedIn == false && alwaysShowLoginScreen == false)
        {
            splashScreen.SetActive(false);
            splashScreenLogin.SetActive(true);
            splashScreenRegister.SetActive(true);
        }

        else if (isLoggedIn == true && alwaysShowLoginScreen == true)
        {
            splashScreen.SetActive(false);
            splashScreenLogin.SetActive(true);
            splashScreenRegister.SetActive(true);
        }

        else if (isLoggedIn == true && alwaysShowLoginScreen == false)
        {
            splashScreen.SetActive(true);
            splashScreenLogin.SetActive(false);
            splashScreenRegister.SetActive(false);
        }
    }
}
