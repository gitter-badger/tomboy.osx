//
//  TableSourceNotes.cs
//
//  Author:
//       jjennings <jjennings@gnome.org>
//
//  Copyright (c) 2012 jjennings
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.WebKit;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Tomboy
{
	public class TableNotesDataSource : NSTableViewSource
	{

		
		private ArrayList notesList;
		private Dictionary <string, Note> notes;
		private NSTableView table;
		private NSSearchField searchField;
		private WebView webView;
		
		public TableNotesDataSource (NSTableView table, NSSearchField searchField, WebView webView) {
			this.table = table;
			this.searchField = searchField;
			this.webView = webView;
			LoadNotes ();
			//Handle Search Field
			this.searchField.Changed += SearchFieldChanged;

			AppDelegate.NoteEngine.NoteAdded += HandleNewNoteAdded;
			KeyboardListener.NoteContentChanged += HandleContentUpdate;
			DomDocumentListener.NoteContentChanged += HandleNoteContentClosing;
		}
		
		#region Delegates
		public delegate void SelectedNoteChangedEventHandler (Note note);
		
		#endregion Delegates
		
		#region Events
		public static event SelectedNoteChangedEventHandler SelectedNoteChanged;
		#endregion Events

		#region Private Methods
		private Note GetActiveNoteObj () {
			int rowID = table.SelectedRow;
			if (rowID == -1)
				return null;

			String noteName = notesList[rowID].ToString ();
			Note note = notes[noteName];
			return note;
		}

		private void HandleNoteContentClosing () {
			UpdateNote ();
		}

		private void HandleContentUpdate () {
			UpdateNote ();
		}

		private void UpdateNote () {
			DomDocument document = webView.MainFrameDocument;
			DomElement paraBlock = document.GetElementById("main_content");
			GetActiveNoteObj ().Text = paraBlock.InnerText;
			AppDelegate.NoteEngine.SaveNote (GetActiveNoteObj ());
		}

		/// <summary>
		/// Searchs for Notes based on what is in the Search Field
		/// </summary>
		/// <param name='sender'>
		/// Sender.
		/// </param>
		/// <param name='e'>
		/// E.
		/// </param>
		private void SearchFieldChanged (object sender, EventArgs e) {
			Console.WriteLine ("Searching for {0}", this.searchField.StringValue);
			LoadNotes (AppDelegate.NoteEngine.GetNotes (this.searchField.StringValue, true));
		}

		/// <summary>
		/// Loads the notes from the engine
		/// </summary>
		private void LoadNotes () {
			LoadNotes (AppDelegate.NoteEngine.GetNotes ());
		}

		private void LoadNotes (Dictionary<string, Tomboy.Note> notes) {
			this.notes = notes;
			notesList = new ArrayList (notes.Keys);
			Console.WriteLine ("Count in Notes {0}, Count in notesList {1}", this.notes.Count, notesList.Count);
			table.ReloadData ();
		}

		private void HandleNewNoteAdded (Note note) {
			/* insert into the first element of the array */
			//TODO: Make sure the arraylist is initiated and not a zero value
			this.notesList.Insert (0, note.Title);
			this.notes.Add (note.Title, note);
			table.ReloadData ();
		}

		#endregion Private Methods

		#region Public Methods

		// This method will be called by the NSTableView control to learn the number of rows to display.
		[Export ("numberOfRowsInTableView:")]
		public int NumberOfRowsInTableView (NSTableView table) {
			return notesList.Count;
		}
		
		/// <summary>
		/// Gets the object value. Hopefully this will handle the Notes into the view.
		/// </summary>
		/// <returns>
		/// The object value.
		/// </returns>
		/// <param name='tableView'>
		/// Table view.
		/// </param>
		/// <param name='tableColumn'>
		/// Table column.
		/// </param>
		/// <param name='row'>
		/// Row.
		/// </param>
		public override MonoMac.Foundation.NSObject GetObjectValue (MonoMac.AppKit.NSTableView tableView, 
		                                                            MonoMac.AppKit.NSTableColumn tableColumn, 
		                                                            int row)
		{
			//noteTitle
			NSString valueKey = null;
			String currNote = (String)notesList [row];
			Note note = notes [currNote];
			
			if (tableColumn.Identifier != null)
				valueKey = (NSString)tableColumn.Identifier.ToString ();
			
			
			switch (valueKey) {
			case "noteTitle":
				return (NSString)note.Title;
			case "colNoteModifiedDate":
				return (NSString)note.ChangeDate.ToString ();
				
			}
			throw new System.Exception (string.Format ("Incorrect value requested '{0}'", valueKey));
		}
		
		// This method will be called by the control for each column and each row.
		[Export ("tableView:objectValueForTableColumn:row:")]
		public NSObject ObjectValueForTableColumn (NSTableView table, NSTableColumn col, int row) {
			
			switch (row) {
			case 0:
				// We will write "Hello" in the first row...
				return new NSString ("Hello");
			case 1:
				// ...and "World" in the second.
				return new NSString ("World");
			// Note that NSTableView requires an NSString, which we create with new NSString("bla").
			default:
				// We need a default value.
				return null;
			}
		}

		/// <summary>
		/// Handle selection changes in the Notes TableView
		/// </summary>
		/// <param name='notification'>
		/// Notification.
		/// </param>
		public override void SelectionDidChange (NSNotification notification) {
			if (SelectedNoteChanged != null && GetActiveNoteObj () != null)
				SelectedNoteChanged (GetActiveNoteObj ());
		}
		#endregion Public Methods
	}
}

