// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;
using System.CodeDom.Compiler;

namespace Tomboy
{
	[Register ("SyncPrefDialogController")]
	partial class SyncPrefDialogController
	{
		[Outlet]
		MonoMac.AppKit.NSButton EnableAutoSyncing { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField ExportPathTextField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField ExportStatusField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField statusField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SyncPathTextField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSProgressIndicator syncProgressIndicator { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField SyncURL { get; set; }

		[Action ("Authenticate:")]
		partial void Authenticate (MonoMac.Foundation.NSObject sender);

		[Action ("EnableAutoSyncingAction:")]
		partial void EnableAutoSyncingAction (MonoMac.Foundation.NSObject sender);

		[Action ("exportNotes:")]
		partial void exportNotes (MonoMac.Foundation.NSObject sender);

		[Action ("ExportNotesAction:")]
		partial void ExportNotesAction (MonoMac.Foundation.NSObject sender);

		[Action ("setExportNotesPath:")]
		partial void setExportNotesPath (MonoMac.Foundation.NSObject sender);

		[Action ("SetExportNotesPath:")]
		partial void SetExportNotesPath (MonoMac.AppKit.NSButton sender);

		[Action ("SetSyncPath:")]
		partial void SetSyncPath (MonoMac.Foundation.NSObject sender);

		[Action ("StartFileSync:")]
		partial void StartFileSync (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (EnableAutoSyncing != null) {
				EnableAutoSyncing.Dispose ();
				EnableAutoSyncing = null;
			}

			if (ExportPathTextField != null) {
				ExportPathTextField.Dispose ();
				ExportPathTextField = null;
			}

			if (ExportStatusField != null) {
				ExportStatusField.Dispose ();
				ExportStatusField = null;
			}

			if (statusField != null) {
				statusField.Dispose ();
				statusField = null;
			}

			if (SyncPathTextField != null) {
				SyncPathTextField.Dispose ();
				SyncPathTextField = null;
			}

			if (syncProgressIndicator != null) {
				syncProgressIndicator.Dispose ();
				syncProgressIndicator = null;
			}

			if (SyncURL != null) {
				SyncURL.Dispose ();
				SyncURL = null;
			}
		}
	}

	[Register ("SyncPrefDialog")]
	partial class SyncPrefDialog
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
