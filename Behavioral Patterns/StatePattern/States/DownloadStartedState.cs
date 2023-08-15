using StatePattern.Interfaces;

namespace StatePattern.States;

public class DownloadStartedState : IDownloadState
{
    public void StartDownload()
    {
        Console.WriteLine("Download already started");
    }

    public void PauseDownload()
    {
        Console.WriteLine("Download paused");
    }

    public void ResumeDownload()
    {
        Console.WriteLine("Download resumed");
    }

    public void CancelDownload()
    {
        Console.WriteLine("Download canceled");
    }
}