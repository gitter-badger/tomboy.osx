//
//  NoteLegacyTranslator.cs
//
//  Author:
//       Jared Jennings <jjennings@gnome.org>
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
using System.Text;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Tomboy
{
	/// <summary>
	/// Note legacy translator which handles text formating between Pango and othe formats.
	/// </summary>
	public class NoteLegacyTranslator
	{

		public NoteLegacyTranslator ()
		{
		}

		public List<LinkItem> Find (string text)
		{
			List<LinkItem> list = new List<LinkItem> ();

			// 1.
			// Find all matches in file.
			MatchCollection m1 = Regex.Matches (text, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);

			// 2.
			// Loop over each match.
			foreach (Match m in m1) {
				string value = m.Groups [1].Value;
				LinkItem i = new LinkItem ();
				i.WholeHREF = m.Value;

				// 3.
				// Get href attribute.
				Match m2 = Regex.Match (value, @"href=\""(.*?)\""", RegexOptions.Singleline);
				if (m2.Success) {
					i.Href = m2.Groups [1].Value;
				}

				// 4.
				// Remove inner tags from text.
				string t = Regex.Replace (value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
				i.Text = t;

				list.Add (i);
			}
			return list;
		}

		public String TranslateHtml (string html)
		{
			/* begin: strip <br> tags from HTML */

			string pattern = @"(<br *\>)";
			Regex r = new Regex(pattern);
			string result = r.Replace (html, System.Environment.NewLine);

			/* end: strip <br> tags from HTML */

			/* Begin handling other internal PANGO types */
			foreach (LinkItem i in Find (html)) {
				result = result.Replace (i.WholeHREF, "<link:url>" + i.Href + "</link:url>");
			}

			/* end of handling PANGO formating */

			return result;

			/* StringBuilder sb = new StringBuilder (html);

			for (int ctr = 0; ctr < sb.Length; ctr++) {
				char ch = sb[ctr];

				if (char.ToUpperInvariant (ch) == char.ToUpperInvariant (Convert.ToChar ("<"))) {
					Console.WriteLine ("Found a match for <");
				}
			}
			return sb.ToString ();
			 */
		}
	}
}

