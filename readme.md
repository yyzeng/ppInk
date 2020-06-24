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

-   Arrow :  
    Arrow draw at the beginning -\> Arrow draw at the end

-   Text:  
    Text left aligned -\> Text Right aligned

-   Move:  
    Move 1 drawing -\> Move all drawings.

The magnet activates some magnetic effect:

-   Find a point on the drawing next to the cursor. For rectangles, magnetic
    effect is available to vertices, and also to the middle of sides.

-   The 8 points of the bounding rectangle

-   On the line from the origin. The lines are horizontal,vertical and every 15°

#### Screen Shots

![](media/ba61e8105d09bfcd20a138929ab1961c.png)

screenshot

#### Download

<https://github.com/PubPub-zz/ppInk/releases/>

#### How to use

Start gInk and an icon will appear in the system tray. Or a floating window
(which can be moved using RightClick) to start drawing on screen.  
Click the exit button or press ESC to exit drawing.

#### Features

-   Compact and intuitive interface.

-   Inks rendered on dynamic desktops.

-   Drawing tools: Hand Writing, Line, Rectangular, Ellipsis, Arrow, Numbering
    Tag, Text Left/Right aligned

-   Stylus with eraser, touch screen and mouse compatible.

-   Click-through mode.

-   Multiple displays support.

-   Pen pressure support.

-   Snapshot support.

-   Hotkey support.

-   Magnetic effect when drawing shapes

-   Filled shapes

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

<https://github.com/pubpub-zz/ppInk>
