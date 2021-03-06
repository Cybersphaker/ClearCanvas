#region License

// Copyright (c) 2013, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This file is part of the ClearCanvas RIS/PACS open source project.
//
// The ClearCanvas RIS/PACS open source project is free software: you can
// redistribute it and/or modify it under the terms of the GNU General Public
// License as published by the Free Software Foundation, either version 3 of the
// License, or (at your option) any later version.
//
// The ClearCanvas RIS/PACS open source project is distributed in the hope that it
// will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General
// Public License for more details.
//
// You should have received a copy of the GNU General Public License along with
// the ClearCanvas RIS/PACS open source project.  If not, see
// <http://www.gnu.org/licenses/>.

#endregion

using ClearCanvas.Common;
using ClearCanvas.Common.Authorization;
using ClearCanvas.Desktop.Explorer;
using ClearCanvas.Desktop;

namespace ClearCanvas.ImageViewer.Explorer.Local
{
	public static class AuthorityTokens
	{
		[AuthorityToken(Description = "Grant access to the 'My Computer' explorer.")]
		public const string MyComputer = "Viewer/Explorer/My Computer";
	}

	[ExtensionOf(typeof(HealthcareArtifactExplorerExtensionPoint))]
	public class LocalImageExplorer : IHealthcareArtifactExplorer
	{
		LocalImageExplorerComponent _component;

		public LocalImageExplorer()
		{

		}

		#region IHealthcareArtifactExplorer Members

		public string Name
		{
			get { return SR.MyComputer; }
		}

		public bool IsAvailable
		{
			get { return PermissionsHelper.IsInRole(AuthorityTokens.MyComputer); }
		}

		public IApplicationComponent Component
		{
			get
			{
				if (_component == null && IsAvailable)
					_component = new LocalImageExplorerComponent();

				return _component;
			}
		}

		#endregion

	}
}
