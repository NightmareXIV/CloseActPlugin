# CloseActPlugin
This small plugin is designed to allow more convenient management of ACT.

Currently, the following functions are present:
* Minimize ACT on startup;
* Gracefully close ACT on FFXIV exit;
* Clear encounter data on combat end (useful for low-end PC);
* Prevent second copy of ACT from starting.

Normally stuff like this could be done without plugin using built-in tools provided by Windows, however, because of complex nature of ACT main window, it's easier and more reliable to do so using plugin.

## Known issues
* Will not work properly if more than one copy of FFXIV is running simultaneously. 
## Automatically starting ACT on FFXIV launch
Please use [FFXIV Quick Launcher](https://github.com/goatcorp/FFXIVQuickLauncher) to do that.