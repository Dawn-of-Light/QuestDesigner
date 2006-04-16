==================================
    The NETXP Component Suite
        Version 3.0 SP2
 Copyright © 2004 Dacris Software
==================================

VERSION
3.0 Service Pack 2
Build 5600 Revision 2205
August 16, 2004

TABLE OF CONTENTS
1. Package Contents
2. Known Issues
3. Change Log

=====================
 1. PACKAGE CONTENTS
=====================
The package should contain the following:

FILE / FOLDER NAME	DESCRIPTION
----------------------------------------------------------------
Assembly		Contains the NetXP assemblies.
Help			Contains documentation for NetXP.
Help\Reference.chm	NetXP reference documentation.
Help\NetXP.chm		NetXP main documentation.
Samples			Contains sample programs.
Loader.exe		The .NET application loader.
Loader.ini		Sample configuration for Loader.
Readme.txt		This file.
License.txt		License agreement. Please read this!

=================
 2. KNOWN ISSUES
=================
The ContextMenu property of NotifyIconEx does not appear to work with
the context menus provided by other component manufacturers such as
Infragistics. In such a case, you should use the default Windows Forms
NotifyIcon component.

=================
 3. CHANGE LOG
=================
SERVICE PACK 2
--------------
Bug Fixes:
- HotTrack property of TabControl is not working.

Changes:
- Properties for tab control for 1px borders: PixelBorder and PixelArea.
- BeginUpdate and EndUpdate functions for TabControl.
- CenterColorChanged event for ColorButton.

SERVICE PACK 1
--------------
Bug Fixes:
- TaskPane with DockPadding other than zero has black border around it.
- XPGroupBox has a problem rendering the last character in the Text Property.
- Label/PictureBox/Panel inside XPGroupBox gets distorted.
- CommandBar Cursor setting resets to default when clicking buttons in design mode.
- ShowClose and ShowArrows properties for TabControl do not persist when False.
- When Localizable property of a form is True, XPButton has errors with hidden properties.
- Localized text in languages such as Thai does not appear on command bar items.
- Multiple monitor issues with command context menu.*
- DesktopAlert does not take into account the size or location of the taskbar.

Changes:
- Ability to turn off fade effect in XPButtons.
- Support TextAlign, ImageAlign, and FlatStyle in XPButton.
- CommandBar manager has new AutoPersist property to match the Dock Manager's.
- HideTreeView function for drop-down tree view.
- Property for command bar button items called DefaultItem (bold text).
- TabControl now allows custom fonts.
- EnableCustomize property for command bars shows/hides Customize functionality.
- Auto-hide docking tabs are now themed in Windows XP.
- Events to detect whether DesktopAlert closes by itself or X button was clicked.
- Property to change line thickness in Graph control.
- TabControl: 'TabPosition' property has been renamed to 'Appearance'.
- Support changing DesktopAlert's timeout.

* Fixed only for users of .NET 1.1 SP1.