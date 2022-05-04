### Introduction

`ppInk` is an on-screen annotation software under Windows, forked from  [`gInk`](https://github.com/geovens/gInk).

![](Animation.gif)

`ppInk` introduces many new features compared to `gInk`, greatly inspired by another 
screen annotation software `Epic Pen`, but even more easy to use. `ppInk` / `gInk` are 
made with the idea kept in mind that the interface should be simple and should 
not distract attention of both the presenter and the audience when used for 
presentations. Unlike in many other softwares in the same category, you select 
from pens to draw things instead of changing individual settings of color, 
transparency and tip width everytime. Each pen is a combination of these
attributes and is configurable to your need.

As another option you can use `ppInk` to support demonstrations: 

https://user-images.githubusercontent.com/4083478/119278023-16f58b00-bc23-11eb-95de-9dc16505bf43.mp4

(extract from @NOVAinc on Twitch)

Other demo: https://www.twitch.tv/novaaoe/clip/PlacidConcernedBulgogiOptimizePrime-mONUtlMLGvu2uUu1

This tool is intended to be usable through mouse, tablet pen (taking pressure into account) but also througt touchscreen or graphic tablet. 

A set of drawing tools are introduced: Hand Writing, Line (2 points and polyline), Rectangular, 
Ellipsis, Arrow, Numbering Tag, Text Left/Right aligned, cliparts, strokes of patterns and move/copy/resize/rotate.

![image](screenshot2.png)

In order to reduce the number of buttons, some buttons have multiple functions, 
selected by multiple click on those or some through long click (or right click as an alternative):

-   **Pen**
    - Short click: Select pen.
    - Long Click: Open the pen parameters dialog.

-   **Hand** <IMG src="https://user-images.githubusercontent.com/4083478/130368095-bf41c299-5e27-4e6e-b94a-6959afea9258.png" width=150>
/ **Rectangular** <IMG src="https://user-images.githubusercontent.com/4083478/130368108-db7a8dd2-e465-4ebe-923d-bf573cfa53c6.png" width=150>
/ **Ellipsis** <IMG src="https://user-images.githubusercontent.com/4083478/130368123-469c7ee4-d28e-44b2-8467-2d70b437e321.png" width=150>
    - unfilled drawing -\> filled with pen color -\> outside filled with pen color -\> filled with white -\> filled with black
    
-   **Line** <IMG src="https://user-images.githubusercontent.com/4083478/130368141-ae6d7cd7-af5f-4215-ad59-e1de5c7d97bb.png" width=150>
    - 2 points -\> polyline -\> pen color filled polygon -\> white filled polygon -\> black filled polygon

-   **Numbering**
    - transparent background -\> edit tag Number -\> white background -\> black background

-   **Arrow**
    - Arrows heads and tails are now customizable. 
    - Multiple click will scroll through the different arrows. 
    - You can select the ends either in `Options | General`, or with a long press on the `Arrow` button.
    - The definition image shall be 300x201 and a line size of 18px (the image will be shrinked/enlarged to match the current pen size). The center corresponds to the visual end. The line will be ended a little before center by default, but you can define a different position with a blue pixel on line 101 (centered line). Normally the ends will be rotated to be aligned with the line, except if the filename of the image is starting with ! (e.g., to have always horizontal square).  
    <IMG src="https://user-images.githubusercontent.com/4083478/130369626-c5693244-e48a-4640-95f5-ff162cfccda4.png" width=300>

-   **Text**
    - Text left aligned -\> Text Right aligned.
    - You can now use `Ctrl+Enter` to validate the entry.

-   **Move** 
    - Move 1 drawing -\> Copy 1 drawing -\> Move all drawings.
    
-   **Edit**
    - Short click: modify text/number tool (text and font) *or* the color/pen width of a stroke.
    - Long click: edit default font (for the time of the session).
    - _Note: If some strokes are selected before short click, the pen/color dialog will open to modify all selected strokes at once._

-   **Lasso**
    - Allow selection of multiple stroke either with the lasso, or clicking on strokes (surrounded).
    - Left click for `Lasso` selection will add to selection, and right click will substract (for touchscreen, remember that longclick is engaging rightclick).
    - Each time you click on `Lasso` tool or use shortcut the selection is reset.
    - Once you have just added a stroke with the `Lasso`, you can use undo to cancel this selection.
    - In `Lasso` mode, the global length is reported in a tooltip.
    - After `Lasso` selection, you can:
      * engage `Erase` to delete selection.
      * engage `Move/Copy` to move/copy selection.
      * engage `Edit` to modify color/line style/width of the selected strokes.

-   **Resize / Rotate**
    - Allow to resize or rotate the selection (also applies to stroke under the cursor if no selection has been done first).
    - First, the cursor becomes a target, waiting for the center for the transformation with left click, or you can right click (in this case the center will be the center of the selected stroke(s))
    - Then the cursor becomes an arrow, and you can adjust the size or the angle.
      https://user-images.githubusercontent.com/4083478/130367372-233d6d64-06fc-4f0f-a976-d66a621f36ac.mp4

-   **Pointer Mode** (arrow cursor)
    - Short click: engage `Pointer` mode.
    - Long click: engage `Window` mode (Open a window) or click (to come back to fullscreen).

-   **Pen Width**
    - Short click: select Pen Width.
    - Long click : engage **color picker**. This functions allow to modify the current pen color by picking up a color on screen; in this mode mousewheel modifies transparency.

-   **Cliparts**
    - Open the dialog to select image and the background/frame. This list displayed of cliparts is initialized from the list defined in the `Options`. you can overload adding images for the inking sessions from files or from the clipboard.
    - You can then stamp the images. 
      * You just click, the image will be stamped with the images original size.
      * If you use the right click the image will be centered on the cursor click.
      * If you just draw a vertical or horizontal line, the image will be drawn with the drawn width/height respecting proportional size.
      * Else you can draw a box which will define the image size (non proportional).
      * If you draw from bottom/right to up/left, the image will be stamped reversed.
    - 3 preset cliparts are also available: they can be configured in the `Options` dialogbox, or for the time of the session through a right or long click on the `Selected` button.
    - **Animated Cliparts are now supported**: APNG and animaged-GIF are supported. By default animations are supported forever. You can specify duration or loops using square brackets (negative means the object will be destroyed at the end). `x` after the number means the number of loops. e.g.,
       * `ppInkClipart.png` -> animated for ever.
       * `ppInkClipart[5.2].png` -> animated for 5.2 sec and then animation stops.
       * `ppInkClipart[-3.1].png` -> animated for 3.1 sec and then disappear.
       * `ppInkClipart[3.5x].png` -> animated for 3 cycles and a half and then animation stops.
       * `ppInkClipart[-2x].png` -> animated for 2 cycles and then disappear.

-   **Stroke of Patterns**
    - This tools provides capability to draw images along a hand stroke.
    - The function is selected in the `Clipart` dialog box through the type of filling selection. Then you will be asked for the size of the image:  
      https://user-images.githubusercontent.com/4083478/130367766-ee6cbd89-34d1-43ac-9f3e-13184b6a0bca.mp4
    - _Note: the checkbox "`save Pattern setup`" allows when you modify one of the predefined clipart to bypass the image size and interval in order to go directly to stroke drawing._

-   **Snapshot**
    - Short click: Take a snapshot and exit after.
    - Long click: Take a snapshot and return to `Inking` mode (keeping data); use `Alt+Hokey` to do that with keyboard.
    - Note that an option is available to invert behaviors between Long and Short click.

-   **Magnetic**
    - The magnet activates some magnetic effect:
      * Find a point on the drawing next to the cursor. For rectangles, magnetic effect is available to vertices, and also to the middle of sides. (also activated pressing `Ctrl`)
      * The 8 points of the bounding rectangle of a text. (also activated pressing `Ctrl`)
      * On the line from the origin. The lines are horizontal, vertical and every 15°. (also activated pressing `Shift`)
    - The Magnetic distance can be adjusted in the `Options`.
    - If only `Ctrl` or `Shift` is depressed, the global magnetic effect is switched off to only take into account the magnetic of the pressed key.
    - Hotkeys are availables for all tools and pens (configurable through right click on icon next to clock).

-   **Move one -> Copy one-> Move All(pan)** <IMG src="https://user-images.githubusercontent.com/4083478/130367997-51bf0abd-f55e-4c6a-b147-8d6fd2a502b2.png" width=150>
    - You can move one stroke when clicking first time on the button. The stroke to be moved/copied will be surrounded by a rectangle to identify it and gets its measurement.
    - When the cursor flies over a shape in `Move one/Copy one` or `Erase` Mode, a tool tip indicates the length of the stroke. If the stroke is a 3 point polyline, it will also indicates the drawn angle.

-   **Zoom**
    - Two zoom can be activated (multiple clicks on the `Zoom` button):
      * The first one offers a standard dynamic window following the cursor.
      * With the second one, you select the area that you want to enlarge. This area will be frozen and then full displayed on the screen. You can then carry on drawing on this new enlarged background image. a new click will end working on this image and will show back the screen and will restore the previously drawn strokes.
    - Behind the zoom, a `Spot` mode is also available where the screen is masked and a transparent area follows the cursor:
      ![image](https://user-images.githubusercontent.com/4083478/130369204-8e898181-c456-46f5-9291-ef0122cba2bd.png)
    - _Note 1: if the option is activated, you can activate the Spot by depressing `Alt`._
    - _Note 2: the spot remains active during `Pointer` mode._
    - _Note 3: color, transparency, spot size, and activation with `Alt` can be adjusted in the `Options | General` tab._
 
-   **Save / Load**
    - Through those two buttons, you will be able to store (in a text format) the current strokes.
    - `Load` redraw the saved strokes onto the existing drawing.
    - `Save` button: A long click (or first short click) is a sort of "save as": it open the dialog box and will allow you to select the filename. The following short clicks will overwrite the strokes into the previously named file. Note that a backup is done when inking is ended/quit.
    - `Load` button: A long click (or first short click) is a sort of "load as": it open the dialog box and will allow you to select the filename. The following short clicks will load the strokes from the previously named file. At first click the file loaded is the autosave (from latest session).
    - _Note: Keep in mind that an automatic save is performed when closing inking mode in `autosave.strokes.txt`. If you have ended your drawing session by error, you can recall your work by depressing `Load` button immediately after opening session._

-   **`Alt` shortcut for temporary commands**
    - When this option is activated (yes by default), when `Alt` is pressed and hold, the tool/pen mode is temporary selected, left when `Alt` is released. 
      * e.g., with `Hand` drawing selected -> Press `Alt` and keep it down -> Press and release `R`: rectangle is active, as long as `Alt` is depressed, and `Hand` will be reengaged when `Alt` is released.
    - This can be reset by any combinations of `Pens` and `Tools`: 
      * e.g., Press down `Alt`, and then you can engage Filled Blue rectangle by depressing `R` twice, and `3` (in any order), and return to previous tools/color releasing `Alt`.
    - `Alt` also works with dash line selection or fading shortcut.
    - This can be also used with `Erasor`.
    - When pressing down `Alt`, the cursor is also temporary change to the big arrow to ease finding it on screen.

-   **Option Capture at toolbar opening**
    - Capture can be engaged as toolbar is opened. This option is set to false by default.

-   **Long left click/Right click on Pens**
    - Open the `Modify` pen dialog box for that pen.

-   **Clear Board (Bin icon)**
    - Short click: Delete all drawings and apply last selected background.
    - Long click: Delete all drawings and select background surface color (white/black/customed color (modifiable through `Options`))
    - In `Options` you will be able to select a default mode at opening, and customed color.
    - Advice: The created rectangle can be deleted using the `Erasor` next to the border of the screen.

-   **Pens specials**
    - Through the `Options` or long click on a `Pen` button, or using the `Edit` pen hotkey you can edit advanced pen: 
      ![](penDialog.png)
    - Fading: the stroke drawn will disappear after the defined time (adjustable in `Options | Pen` dialogbox tab).
    - Line Style (Stroke/Solid/Dash/Dot/DashDot/DashDotDot): This will apply the defined line style on all type of drawings. Stroke keeps the original drawing which uses the pen pressure to adjust the width. Solid, Dash, ... ignore pen pressure.
      ![image](https://user-images.githubusercontent.com/19545604/119908686-8cb26d00-bf29-11eb-9dd3-ec421d216b23.png)
    - _Note 1: When drawing with dashed lines, try to not draw too slowly. The number of vertex will increase and make the drawing not very nice._
    - _Note 2: Hotkeys allows to set/unset the fading, linestyle, increase/decrease penwidth and open the pen modify dialog of the current pen._
    - _Note 3: an option is now available in `Options | Pen` to allow to modify the linestyle when clicking on already selected `Pen` button (or using hotkeys). Also an option in hotkeys allow to select which linestyle will be accessible through click / hotkeys (not applicable to `Pen Modify` dialog box)._
    - _Note 4: A global option exists also to set/unset smoothing. When off, strokes drawing will not be smoothed. General recommendation is to leave this option on._

-   **Color picker**
    - When activated (hotkey or long press on `Pen Width` button): a pickup tool will be available to pickup from screen a color and set it (on mouse click release) to current pen. When in this mode, the mouse wheel will allow to adjust transparency. 

-   **Cursor files**
    - You can configure you own cursor file, saving it as `cursor.ico` in your exe folder (click position and size are loaded from the file). In the same way you can save an image as `FloatingCall.png` to define the calling form image (in this case the width and transparency are in the `Window_POS` parameter in `config.ini`.

-   **Mouse wheel**
    - Mouse wheel allows you mainly to modify the pen width. This can be easily observed with the tipped cursor. Finding the mouse may be difficult to find in this configuration: you can then depress the `Alt` key to get the arrow (or customized) cursor. When `Number` tool is selected, instead of change pen with, it changes the number size.
    - `Shift+mouse wheel` allows to select pen.
    - _Note 1: `mouse wheel` / `Shift+mouse wheel` can now be swapped (`Shift+mouse wheel` to access pen width), available in `Options | Pen` tab._
    - _Note 2: as said above, two hotkeys are available to control width through the keyboard._ 

-   **Video recording**
    - `ppInk` has now some capability to do some video recording.
    - Tuning is available in `Options | Video` tab:
      * `basic recording with FFmpeg`: You need to first install `ffmpeg` and select the option in the `Video` tab. In this case the button will be proposed. You can start/stop recording. Names and destination folders are defined through the command line.
      * `advanced recording with OBS-studio`: You need to first install and configure [`OBS-studio`](https://obsproject.com/fr/download) with [`OBS-websocket`](https://github.com/Palakis/obs-websocket). Select the required option (recording or broadcasting). With this program you will be able to start/stop broadcasting or start/pause/resume/stop video recording. File names and folders are defined in `OBS-studio`.
    - _Note: `ppink` is now compatible with release 4.8 of `OBS-websocket`. This should be fixed in very next release. For the moment, prefer to stop recording when stopping `Ink` mode._

-   **UI customisation**
    - You add `arrow.ani/cur/ico` and `eraser.ani/cur/ico` to put your own cursors. If you use ico file the cursor is down with the file sized (you can then put a bigger or smaller image).
    - Toolbar Background Color can be changed in the `Options`. Currently a draw pickup makes the background color incorrect during opening. transparency is currenly ignored.
    - Button Images can be customized putting Png files in the `ppink` exe folder. The name to be used are the same as the one from the `src` folder.
    - When checked in the `Options`, a secondary toolbar will open when selected some tools to access all functions/filling immediately:
      ![image](https://user-images.githubusercontent.com/4083478/120102486-8dc2e480-c14b-11eb-86e8-90e4c6750405.png)
    - The example above shows also an example with the pens on two lines (setup through `Options` dialog box).

-   **Toolbar orientation**
    - You can now select how the toolbar will be deployed: to left/ to right or vertically to top/ to bottom.

-   **`Alt+Tab` engaging Pointer**
    - When the option is set in the `Options`, switching application (with `Alt+Tab`) will engage `Pointer` mode. 
    - Also, when `Pointer` mode is activated (by any means, i.e., button click, `Alt+Tab`, global short cut), the toolbar is folded automatically, and when pressing `Undock` button, `Alt+Tab`, or global shortcut,the `Inking` mode is restored and the toolbar is unfolded.
    - Note that you can still fold toolbar when drawing without engaging `Pointer` mode with the `Dock` button.

-   **Measurement tool**
    - When enabled, in `Move one/Copy one` or `Erase` tool, the length of the selected object is provided in a tooltip.
      ![image](https://user-images.githubusercontent.com/4083478/120104195-8dc6e280-c153-11eb-958c-6816f73a5b00.png)
    - The example shows also a very specific case where the object is a 3 point polyline, the angle is also computed.

-   **Window mode**
    - You can now run `ppInk` in `Window` mode (engaged through Long/Right Click on `Pointer` icon). In this mode `ppInk` is run in a window and you can access clicks or mousewheel applications out of the window:
      https://user-images.githubusercontent.com/4083478/112311221-c656c580-8ca5-11eb-895b-2279366c0fc4.mp4
    - _Note: The border color can be changed directly in `config.ini`._

-   **snapshots in `Pointer` mode**
    - When trying to annotate menu opened with mouse click / contextual menus, you can configure shortcuts with `Shift/Ctrl/Alt` with a press and hold and tap twice keys to prevent menu to close.
        https://user-images.githubusercontent.com/61389799/111090958-1d3bfc80-853a-11eb-91fc-04e85ed18454.mp4
        (demo from @eamayreh)
    - Multiple snapshots can be captured, they are pasted one over the other, in the reverse order to make a full sequence.


### Rest API
-   In order to allow customisation, `ppInk` provides now a REST API allowing control from an external program/device such as a `streamdesk` from `Elgato` or `touchPortal`:
-   Example with StreamDesk :
    ![image](https://user-images.githubusercontent.com/4083478/120103114-5a358980-c14e-11eb-9456-3b20e4ecc827.png)

-   Example with touchportal:
    ![image](https://user-images.githubusercontent.com/4083478/120103293-3a529580-c14f-11eb-9682-33eafa4cfaea.png)
(thanks to @NOVAinc)

-   Ensure you are working with http protocol
-   All the API is described in the https://github.com/pubpub-zz/ppInk/raw/master/ppInk/httpRequests.rtf (provided next to `ppink.exe` in each release)
-   Note that this API returns results in `JSON` format that can be used for further extension.


### Download

<https://github.com/PubPub-zz/ppInk/releases/>


### Change log

<https://github.com/pubpub-zz/ppInk/blob/master/changelog.txt>


### How to use

-   Start `ppInk.exe` and an icon will appear in the system tray and possible a floating window(\*)
(which can be moved using RightClick) to start drawing on screen.    
    (\*) Activation and position saving are available in `Options`.
-   Inking is started :
    - clicking on floating icon.
    - clicking on the icon in the system tray.
    - using the global shortcut (`Ctr+Alt+G` by default).
    - immediately after start Pping if "`--startInking`" (case insensitive) has been added to command line.
    - `ppInk` is run once more (no extra instance is started).
-   Click the `Exit` button or press `ESC` to exit drawing.


### Features

-   Compact and intuitive interface with customizable hotkeys

-   Inks rendered on dynamic desktops

-   Drawing tools
    Hand Writing, Line, Rectangular, Ellipsis, Arrow, Numbering Tag, Text Left/Right aligned.

-   Stylus with eraser, touch screen and mouse compatible

-   Click-through mode
    (Note: once inking is engaged, global shortcut enters and exits this mode).

-   Multiple displays support

-   Pen pressure support

-   Snapshot support

-   Hotkey support
    * Includes hotkeys with `Del`, `BackSpace`
    * In `Options` use `Ctrl+Shift+Del` or `Ctrl+Shift+Backspace` to delete the current hotkey.

-   Magnetic effect when drawing shapes

-   Filled shapes

-   Video recording

-   Load/Save stroke

-   Zoom (2 versions)


### Tips

-   **There is a known issue for multiple displays of unmatched DPI settings (100%, 125%, 150%, etc.). If you use `ppInk` on a computer with multiple displays of unmatched DPI settings, or you encounter problems such as incorrect snapshot position, unable to drag toolbar to locations etc., please do the following as a workaround (in Windows 10 version 1903 as an example): right-click `ppInk.exe` -> Properties -> Compatibility -> Change high DPI settings -> Enable override high DPI scaling behavior scaling performed by: Application.**

-   There is a very few hidden `Options` you can tweak in `config.ini` that are not shown in the `Options` window.


### How to contribute translation

`gInk/ppInk` supports multiple languages now (`ppInk` introduces a few new sentences where internationalization has not be implemented.) Here is how you can contribute translation. Simply create a duplication of the file "`en-us.txt`" in "`bin/lang`" folder, rename it and then translate the strings in the file. Check in `ppInk` to make sure your translation shows correctly, and then you can make a pull request or use https://github.com/pubpub-zz/ppInk/issues/17 to propose your translation for the next version of release for others to use.

_Arabic_ available


### Copyrights

`gInk` (https://github.com/geovens/gInk), &copy; Weizhi Nai &copy; 2019
`ppInk` (https://github.com/pubpub-zz/ppInk), &copy; Pubpub-ZZ 2020-2021

