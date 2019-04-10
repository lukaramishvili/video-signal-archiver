# video-signal-archiver
> continuous high-fidelity video recorder for a TV Station [C# / WinForms / MySQL]

Records continuous video signal from a video card and organizes it into a predetermined user-managed directory structure by TV Show, record time, show name etc (falls back to 1-hour chunks when this information is not available).

Best results were achieved with Blackmagic Design DeckLink cards, but any PCIe capture cards can be used.

Features:
* Never loses any video data that goes through the video cable
* Dedicated Recording Console app for emergency intervention
* Has a admin panel to allocate, ahead of time, which time slots will be recorded to which TV shows' files – the user can specify night-time show start/end times and **go to sleep**.
* The admin panel can be accessed from network

Not implemented yet:
* Auto-omitting TV ads – ad time on TV can be highly variable, so not even operators know when they'll start/end. Implementation would require real-time human intervention, which would defeat the whole point.
* Post-factum Breaking News separation – requires manual file editing.
