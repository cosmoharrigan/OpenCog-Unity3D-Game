
/// Unity3D OpenCog World Embodiment Program
/// Copyright (C) 2013  Novamente
///
/// This program is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Affero General Public License as
/// published by the Free Software Foundation, either version 3 of the
/// License, or (at your option) any later version.
///
/// This program is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Affero General Public License for more details.
///
/// You should have received a copy of the GNU Affero General Public License
/// along with this program.  If not, see <http://www.gnu.org/licenses/>.
using UnityEngine;
using System.Collections;
using ProtoBuf;
using UnityEditor;

namespace OpenCog
{

namespace Automation
{

/// <summary>
/// The OpenCog Automated Player Builder.  Builds standalone players and allows for unit testing.
/// Example commandline usage:
/// "C:\Program Files (x86)\Unity\Editor\Unity.exe" -batchMode -quit -nographics -projectPath C:\project -executeMethod OCAutomatedPlayerBuilder.BuildAll
/// </summary>
#region Class Attributes

#endregion
public class OCAutomatedPlayerBuilder
{

  /////////////////////////////////////////////////////////////////////////////

  #region Private Member Data

  /////////////////////////////////////////////////////////////////////////////

  

  /////////////////////////////////////////////////////////////////////////////

  #endregion

  /////////////////////////////////////////////////////////////////////////////

  #region Accessors and Mutators

  /////////////////////////////////////////////////////////////////////////////

  

  /////////////////////////////////////////////////////////////////////////////

  #endregion

  /////////////////////////////////////////////////////////////////////////////

  #region Public Member Functions

  /////////////////////////////////////////////////////////////////////////////

  [MenuItem ("Build/BuildAll")]
	static void BuildAll()
	{
		BuildStandaloneLinuxPlayer();
		BuildStandaloneLinux64Player();
		BuildStandaloneWindowsPlayer();
		BuildStandaloneWindows64Player();
	}
	
	[MenuItem ("Build/BuildStandaloneLinux64Player")]
	static void BuildStandaloneLinux64Player()
	{
		string[] scenes = { "Assets/Scenes/Game/Game.unity", "Assets/Scenes/MainMenu/MainMenu.unity", "Assets/Scenes/BlockSetViewer/BlockSetViewer.unity" };
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneLinux64);
		BuildPipeline.BuildPlayer(scenes
								  , "../Players/Unity3DGameWorldPlayer_Linux64"
								  , BuildTarget.StandaloneLinux64, BuildOptions.None );
	}
	
	[MenuItem ("Build/BuildStandaloneLinuxPlayer")]
	static void BuildStandaloneLinuxPlayer()
	{
		string[] scenes = { "Assets/Scenes/Game/Game.unity", "Assets/Scenes/MainMenu/MainMenu.unity", "Assets/Scenes/BlockSetViewer/BlockSetViewer.unity" };
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneLinux);
		BuildPipeline.BuildPlayer(scenes
								  , "../Players/Unity3DGameWorldPlayer_Linux"
								  , BuildTarget.StandaloneLinux, BuildOptions.None );
	}
	
	[MenuItem ("Build/BuildStandaloneWindowsPlayer")]
	static void BuildStandaloneWindowsPlayer()
	{
		string[] scenes = { "Assets/Scenes/Game/Game.unity", "Assets/Scenes/MainMenu/MainMenu.unity", "Assets/Scenes/BlockSetViewer/BlockSetViewer.unity" };
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneWindows);
		BuildPipeline.BuildPlayer(scenes
								  , "../Players/Unity3DGameWorldPlayer_Windows.exe"
								  , BuildTarget.StandaloneWindows, BuildOptions.None );
	}
	
	[MenuItem ("Build/BuildStandaloneWindows64Player")]
	static void BuildStandaloneWindows64Player()
	{
		string[] scenes = { "Assets/Scenes/Game/Game.unity", "Assets/Scenes/MainMenu/MainMenu.unity", "Assets/Scenes/BlockSetViewer/BlockSetViewer.unity" };
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.StandaloneWindows64);
		BuildPipeline.BuildPlayer(scenes
								  , "../Players/Unity3DGameWorldPlayer_Windows64.exe"
								  , BuildTarget.StandaloneWindows64, BuildOptions.None );
	}

  /////////////////////////////////////////////////////////////////////////////

  #endregion

  /////////////////////////////////////////////////////////////////////////////

  #region Private Member Functions

  /////////////////////////////////////////////////////////////////////////////

  /////////////////////////////////////////////////////////////////////////////

  #endregion

  /////////////////////////////////////////////////////////////////////////////

}// class OCAutomatedPlayerBuilder

}// namespace Automation

}// namespace OpenCog



