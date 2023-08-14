using StatePattern.Interfaces;
using StatePattern.States;

namespace StatePattern.Models;

public class DownloadManager
{
    private IDownloadState _state;

    public DownloadManager()
    {
        _state = new DownloadPausedState();
    }

    public void StartDownload()
    {
        _state.StartDownload();
        _state = new DownloadStartedState();
    }

    public void PauseDownload()
    {
        _state.PauseDownload();
        _state = new DownloadPausedState();
    }

    public void ResumeDownload()
    {
        _state.ResumeDownload();
        _state = new DownloadStartedState();
    }

    public void CancelDownload()
    {
        _state.CancelDownload();
        _state = new DownloadPausedState();
    }
}