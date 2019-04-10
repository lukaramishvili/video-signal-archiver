# video-signal-archiver
> continuous high-fidelity video recorder for a TV Station [C# / WinForms / MySQL]

Records continuous video signal from a video card and organizes it into a predetermined user-managed directory structure by TV Show, record time, show name etc (falls back to 1-hour (intuitively named) chunks when this information is not available).

Best results were achieved with Blackmagic Design DeckLink cards, but any PCIe capture cards can be used.

Features:
* Never loses any video data that goes through the video cable
* Dedicated CaptureTestConsole app for real-time management and emergency manual intervention
* Has a admin panel to allocate, ahead of time, which time slots will be recorded to which TV shows' files – the user can specify night-time show start/end times and **go to sleep**.
* The admin panel can be accessed from network
* Can upload recorded files to a remote FTP server (file sizes can be *huge*, so the server still has to be located nearby). Since the record servers have to be located in the Master Control Room where the coax cables run (and a lot of staff can't enter), this features allows for fast and easy company-wide distribution of recent recordings, as well as enabling more straightforward off-site archiving.
* Extensive metadata about recorded content
* Multiple codec support
* AVI / FLV container format support
* ffmpeg integration

Not implemented yet:
* Auto-omitting TV ads – ad time on TV can be highly variable, so not even operators know when they'll start/end. Implementation would require real-time human intervention, which would defeat the whole point.
* Post-factum Breaking News separation – requires manual file editing.

*CaptureTestConsole utilizes DirectX.Capture library from Brian Low*
