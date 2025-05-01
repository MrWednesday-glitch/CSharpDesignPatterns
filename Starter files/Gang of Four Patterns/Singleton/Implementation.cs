namespace Singleton;

/// <summary>
/// singleton class
/// </summary>
public class Logger
{
    // Lazy <t>
    private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger());

    //private static Logger? _instance;

    /// <summary>
    /// instance
    /// </summary>
    public static Logger Instance
    {
        get
        {
            //if (_instance == null)
            //{
            //    _instance = new Logger();
            //}
            //return _instance;
            return _lazyLogger.Value;
        }
    }

    protected Logger()
    {

    }

    /// <summary>
    /// singleton operationm
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
        Console.WriteLine($"Message to log: {message}");
    }
} 
