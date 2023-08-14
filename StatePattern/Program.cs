using StatePattern.Models;

DownloadManager downloadManager = new DownloadManager();

downloadManager.StartDownload();
downloadManager.PauseDownload();
downloadManager.ResumeDownload();
downloadManager.CancelDownload();

downloadManager.StartDownload();
downloadManager.StartDownload();
downloadManager.PauseDownload();