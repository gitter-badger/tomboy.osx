// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Macboy
{
	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}

	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSButton newNoteButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (newNoteButton != null) {
				newNoteButton.Dispose ();
				newNoteButton = null;
			}
		}
	}
}
