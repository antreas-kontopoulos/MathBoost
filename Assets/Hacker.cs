using UnityEngine;
using UnityEngine.SceneManagement;

public class Hacker : MonoBehaviour {

    int level;
    string password;

    string[] level1Εquations = { "8 + 5 * 2 = ?", "15 + 16 / 2 = ?", "12 * 4 - 3 = ?", "20 - 11 * 12 = ?" };
    string[] level1Passwords = { "18", "23", "45", "112" };

    string[] level2Εquations = { "8 * (8 - 6 / 3) = ?", "10 * 3 / (4 + 1 * 2) = ?", "(144 / (3 * 6 - 6)", "9 * (48 / 2 / 2)" };
    string[] level2Passwords = { "48", "5", "12", "108" };

    string[] level3Εquations = { "(8 * 7 - 1) / (1 + (15 * 4 / 6)) = ?", "(5^2 + 5) / ( 3 * ( 5 * 4 / 10 / 2 )) = ?", "(9 * 7) * ( 2^3 / (8 - 2 * 2)) = ?" };
    string[] level3Passwords = { "5", "10", "126"};
    

    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;

    // Use this for initialization
    void Start () {
        ShowMainMenu();
    }

   void ShowMainMenu () {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Press 1 to hack the library. [Easy]");
        Terminal.WriteLine("Press 2 to hack the bank.    [Medium]");
        Terminal.WriteLine("Press 3 to hack NASA.        [Hard]");
        Terminal.WriteLine("Enter your selection:");
    }

    void OnUserInput(string input) {
        if (input == "menu")
        {
            ShowMainMenu();
        }
        else if (input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("Please close the tab to exit");     // If on the web 
            Application.Quit();        
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }

    void RunMainMenu(string input) {
        int index = -1;
        if (input == "1")
        {
            level = 1;
            index = Random.Range(0, level1Passwords.Length);
            password = level1Passwords[index];
            StartGame();
            Terminal.WriteLine("Please do the maths to hack the library!");
            Terminal.WriteLine(level1Εquations[index]);
        }
        else if (input == "2")
        {
            level = 2;
            index = Random.Range(0, level2Passwords.Length);
            password = level2Passwords[index];
            StartGame();
            Terminal.WriteLine("Please do the maths to hack the bank!");
            Terminal.WriteLine(level2Εquations[index]);
        }
        else if (input == "3")
        {
            level = 3;
            index = Random.Range(0, level3Passwords.Length);
            password = level3Passwords[index];
            StartGame();
            Terminal.WriteLine("Please do the maths to hack NASA!");
            Terminal.WriteLine(level3Εquations[index]);
        }
        else
        {
            Terminal.WriteLine("Please choose a valid target");
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            StartGame();
            RunMainMenu(level.ToString());
            Terminal.WriteLine("Wrong Pasword. Please try again.");
        }
    }

    void StartGame(){
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        Terminal.WriteLine("You chose level " + level);
    }

    private void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowReward();
        Terminal.WriteLine("Type 'menu' to play again.");

    }

    private void ShowReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("WELL DONE! Get a book from the library.");
                Terminal.WriteLine(@"
      ______ ______
    _/      Y      \_
   // ~~ ~~ | ~~ ~  \\
  // ~ ~ ~~ | ~~~ ~~ \\      
 //________.|.________\\     
`----------`-'----------'
                ");
                break;
            case 2:
                Terminal.WriteLine("WELL DONE! Welcome to bank's system.");
                Terminal.WriteLine(@"
      _.-------.
    -' .-------'
 __/  /_______
/__   _______/
   \  \
    -_ `-------.
      `--------'
            ");
                break;
            case 3:
                Terminal.WriteLine("WELL DONE! Welcome to NASA.");
                Terminal.WriteLine(@"
    /\
   /__\
  |    |
 /|    |\
/_|    |_\
   \  /
   ||||   
                ");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                break;

        }
    }

    // Update is called once per frame
    void Update () {
    
    }
}
