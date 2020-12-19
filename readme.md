#### Introduction

ppInk is an on-screen annotation software under Windows, forked from gInk.

ppInk introduces new features compared to gInk, greatly inspired by another
screen annotation software Epic Pen, but even more easy to use. ppInk / gInk are
made with the idea kept in mind that the interface should be simple and should
not distract attention of both the presenter and the audience when used for
presentations. Unlike in many other softwares in the same category, you select
from pens to draw things instead of changing individual settings of color,
transparency and tip width everytime. Each pen is a combination of these
attributes and is configurable to your need.

A set of drawing tools are introduced: Hand Writing, Line, Rectangular,
Ellipsis, Arrow, Numbering Tag, Text Left/Right aligned

In order to reduce the number of buttons, some buttons have multiple functions,
selected my multiple click on those:

-   Hand / Rectangular / Ellipsis :  
    unfilled drawing -\> filled with pen color -\> filled with white -\> filled
    with black

-   Numbering :  
    transparent background -\> edit tag Number -\> white background -\> black background

-   Arrow :
    Arrow draw at the beginning -\> Arrow draw at the end
    
    (*) : head position when tool is first selected can be modified by option

-   Text:  
    Text left aligned -\> Text Right aligned

-   Move:  
    Move 1 drawing -\> Move all drawings.
    
-   Edit:
    Short click : modify text/number tool (text and font)
    Long click : edit default font (for the time of the session)

*Magnetic*
The magnet activates some magnetic effect :
-   Find a point on the drawing next to the cursor. For rectangles, magnetic
    effect is available to vertices, and also to the middle of sides.(also activated pressing Ctrl)
-   The 8 points of the bounding rectangle of a text.(also activated pressing Ctrl)
-   On the line from the origin. The lines are horizontal,vertical and every 15°.(also activated pressing Shift)
The Magnetic distance can be adjusted in the options.
If only Ctrl or Shift is depressed, the global magnetic effect is switched off to only take into account the magnetic of the pressed key.
Hotkeys are availables for all tools,pens (configurable throught right click on icon next to clock)

*Alt+ shortcut for temporary commands:*
When this option is activated (yes by default), when Alt is pressed and hold, the tool/pen/mode is temporary selected, left when alt is released
eg : with Hand drawing selected, press Alt and keep it  down. Press and release R : rectangle is active, as long as Alt is depressed, and Hand will be reengaged when Alt is released
This can be reset any combinaisons of Pens and Tools : eg : press Alt, you can engage Filled Blue rectangle, depressing R twice, and 3 (in any order), and return to previous tools/color releasing Alt
This can be also used with Erasor
when pressing down Alt, the cursor is also temporary change to the big arrow to ease finding it on screen.

*Option Capture at toolbar opening*
Capture can be engaged as toolbar is opened. This option is set to false by default.

*Long left click/Right click on Pens*
Open the Modify pen dialog box for that pen

*Clear Board (Bin icon):*

short click : Delete all drawings and apply last selected background
Long click : Delete all drawings and select background surface color (white/black/customed color(modifiable through Options))
In options you will be able to select a default mode at opening , and customed color
advice : the created rectangle can be deleted using the erasor next to the border of the screen.

*cursor files:*
You can configure you own cursor file, saving it as cursor.ico in your exe folder (click position and size are loaded from the file). In the same you can save an image as FloatingCall.png to define the calling form image(in this case the width and transparency are in the Window_POS parameter in config.ini
*mouse wheel:*
Mouse wheel allows you to modify the pen width. this can be easily observed with the tipped cursor. in this configuration, finding the mouse may be difficult to find in this configuration : you can then depress the alt key to get the arrow(or customized) cursor

*video recording:*
ppInk has now some capability to do some video recording. tuning is available in options/video tab :
   - basic recording with FFmpeg:
   You need to first install ffmpeg. and select the option in the video tab. In this case the button will be proposed. you can start/stop recording. Names and destination folders are defined throught the command line.
   - advanced recording with OBS-studio:
   You need to first install and configure OBS-studio(https://obsproject.com/fr/download) with OBS-websocket(https://github.com/Palakis/obs-websocket). select the required option (recording or broadcasting). with this program you will be able to start/stop broadcasting or start/pause/resume/stop video recording. file names and folders are defined in OBS-studio.
   Note : ppink is now compatible with release 4.8 of OBS-websocket. this should be fixed in very next release. for the moment,prefer to stop recording when stopping Ink mode

*UI customisation*
You add arrow.ani/cur/ico and eraser.ani/cur/ico to put your own cursors. if you use ico file the cursor is down with the file sized ( you can then put a bigger or smaller image)
toolbar Background Color can be changed in the options. currently a draw hickup make the background color incorrect during opening. transparency is currenly ignored
Button Images can be customized putting Png files in the ppink exe folder. the name to be used are the same as the one from the src folder.

*Alt+Tab engaging Pointer*
When the option is set in the options, switching application (with alt+tab) will engage pointer mode. Also, when pointer mode is activated (by any means, ie button click, alt+tab, global short cut), the toolbar is folded automatically, and when pressing undock button, alt+tab, or global shortcut,the inking mode is restored and the toolbar is unfolded.
Note that you can still fold toolbar when drawing without engaging pointer mode with the dock button.


#### Screen Shots

![](screenshot1.png)

screenshot

#### Download

<https://github.com/PubPub-zz/ppInk/releases/>

#### Change log

<https://github.com/pubpub-zz/ppInk/blob/master/changelog.txt>


#### How to use

Start ppInk.exe and an icon will appear in the system tray and possible a floating window(\*)
(which can be moved using RightClick) to start drawing on screen.  
Inking is started :
 - clicking on floating icon
 - clicking on the icon in the system tray
 - using the global shortcut (ctr+alt+G by default)
 - immediately after start Pping if "--startInking" (case insensitive) has been added tocommand line
 - ppInk is run once more (no extra instance is started)

(\*) activation and position saving are available in options.

Click the exit button or press ESC to exit drawing.

#### Features

-   Compact and intuitive interface with customizable hotkeys.

-   Inks rendered on dynamic desktops.

-   Drawing tools: Hand Writing, Line, Rectangular, Ellipsis, Arrow, Numbering
    Tag, Text Left/Right aligned

-   Stylus with eraser, touch screen and mouse compatible.

-   Click-through mode. (note : once inking is engaged, global shortcut enters and exits this mode)

-   Multiple displays support.

-   Pen pressure support.

-   Snapshot support.

-   Hotkey support.

-   Magnetic effect when drawing shapes

-   Filled shapes

-   Video recording

#### Tips

-   There is a known issue for multiple displays of unmatched DPI settings
    (100%, 125%, 150%, etc.). If you use gInk on a computer with multiple
    displays of unmatched DPI settings, or you encounter problems such as
    incorrect snapshot position, unable to drag toolbar to locations etc.,
    please do the following as a workaround (in Windows 10 version 1903 as an
    example): right-click ppInk.exe, Properties, Compatibility, Change high DPI
    settings, Enable override high DPI scaling behavior scaling performed by:
    Application. (only after v1.0.9, which will be released soon)

-   There are a few hidden options you can tweak in config.ini that are not
    shown in the options window.

#### How to contribute translation

gInk/ppInk supports multiple languages now (ppInk introduces a few new sentences
where internationalization has not be implemented.). Here is how you can
contribute translation. Simply create a duplication of the file "en-us.txt" in
"bin/lang" folder, rename it and then translate the strings in the file. Check
in ppInk to make sure your translation shows correctly, and then you can make a
pull request to merge your translation to the next version of release for others
to use.

gInk  
https://github.com/geovens/gInk  
https://github.com/geovens/gInk  
Weizhi Nai \@ 2019

ppInk
https://github.com/pubpub-zz/ppInk
Pubpub-ZZ \@ 2020
