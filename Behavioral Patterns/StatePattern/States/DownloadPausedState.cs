using StatePattern.Interfaces;

namespace StatePattern.States;

public class DownloadPausedState : IDownloadState
{
    public void StartDownload()
    {
        Console.WriteLine("Download started");
    }

    public void PauseDownload()
    {
        Console.WriteLine("Download already paused");
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