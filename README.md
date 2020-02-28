# Logitech WLED Sync

Windows tray application that syncs RGB LEDs of Logitech's gaming devices to WLED (https://github.com/Aircoookie/WLED). Currently only solid colours are supported (no effects).

## Configuration

Right click on the tray application icon and click "Settings". The rest should be self-explanatory.


## Building Instructions

Download the Logitech LED Illumination SDK from [here](https://www.logitechg.com/en-us/innovation/developer-lab.html), move "LogitechLedEnginesWrapper.dll" to the build output folder (where the .exe is), move "LogitechGSDK.cs" to the project's root folder (where the other .cs files are) and hit "Build"!