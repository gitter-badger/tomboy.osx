// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace Tomboy
{
	[Register ("ControlCenterController")]
	partial class ControlCenterController
	{
		[Outlet]
		MonoMac.AppKit.NSTableView _notesTableView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTableView _notebooksTableView { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSearchFieldCell _searchNotesInControlCenter { get; set; }

		[Outlet]
		MonoMac.AppKit.NSSearchField _searchNotes { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_notesTableView != null) {
				_notesTableView.Dispose ();
				_notesTableView = null;
			}

			if (_notebooksTableView != null) {
				_notebooksTableView.Dispose ();
				_notebooksTableView = null;
			}

			if (_searchNotesInControlCenter != null) {
				_searchNotesInControlCenter.Dispose ();
				_searchNotesInControlCenter = null;
			}

			if (_searchNotes != null) {
				_searchNotes.Dispose ();
				_searchNotes = null;
			}
		}
	}

	[Register ("ControlCenter")]
	partial class ControlCenter
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
