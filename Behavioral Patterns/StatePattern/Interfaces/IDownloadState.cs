namespace StatePattern.Interfaces;

interface IDownloadState
{
    void StartDownload();
    void PauseDownload();
    void ResumeDownload();
    void CancelDownload();
}