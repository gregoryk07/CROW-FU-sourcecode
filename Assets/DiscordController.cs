using Discord;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordController : MonoBehaviour
{

    public long applicationID;
    [Space]
    public string details = "Walking around the world";
    public string state = "Current velocity: ";
    [Space]
    public string largeImage = "game_logo";
    public string largeText = "Discord Tutorial";
    private long time;

    private static bool instanceExists;
    public Discord.Discord discord;

    Scene scene;

    void Awake()
    {
        // Transition the GameObject between scenes, destroy any duplicates
        if (!instanceExists)
        {
            instanceExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Log in with the Application ID
        discord = new Discord.Discord(applicationID, (System.UInt64)Discord.CreateFlags.NoRequireDiscord);

        time = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();

        UpdateStatus();
    }

    void Update()
    {
        scene = SceneManager.GetActiveScene();
        // Destroy the GameObject if Discord isn't running
        try
        {
            discord.RunCallbacks();
        }
        catch
        {
            Destroy(gameObject);
        }
    }

    void LateUpdate()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            details = "Loading...";
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            details = "In menu";
        }
        if(SceneManager.GetActiveScene().buildIndex > 1)
        {
            details = "In game";
        }
        if(Debug.isDebugBuild)
        {
            state = "Testing";
        }
        else
        {
            state = "Playing";
        }

        UpdateStatus();
    }

    void UpdateStatus()
    {
        // Update Status every frame
        try
        {
            var activityManager = discord.GetActivityManager();
            var activity = new Discord.Activity
            {
                Details = details,
                State = state,
                Assets =
                {
                    LargeImage = largeImage,
                    LargeText = largeText
                },
                Timestamps =
                {
                    Start = time
                }
                
            };

            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res != Discord.Result.Ok) Debug.LogWarning("Failed connecting to Discord!");
            });

        }
        catch
        {
            // If updating the status fails, Destroy the GameObject
            Destroy(gameObject);
        }
        
    }
    private void OnDisable()
    {
        discord.Dispose();
    }
}