using System;
using System.IO;
using System.Windows.Forms;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;
using System.Resources;
using System.Reflection;
using System.Globalization;

namespace SaveTabs
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		private DTE2 _applicationObject;
		private AddIn _addInInstance;
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
            //yey

			//ali - çetin'in github repository sine direk commit denemesi
		}

		//

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
			_applicationObject = (DTE2)application;
			_addInInstance = (AddIn)addInInst;
			switch (connectMode)
			{
				case ext_ConnectMode.ext_cm_UISetup:
					//MessageBox.Show("UISetup");
					// Do nothing for this add-in with temporary user interface
					break;
					 
				case ext_ConnectMode.ext_cm_Startup:
					//MessageBox.Show("Startup");
					// The add-in was marked to load on startup
					// Do nothing at this point because the IDE may not be fully initialized
					// Visual Studio will call OnStartupComplete when fully initialized
					break;

				case ext_ConnectMode.ext_cm_AfterStartup:
					//MessageBox.Show("AfterStartup"); 
					// The add-in was loaded by hand after startup using the Add-In Manager
					// Initialize it in the same way that when is loaded on startup
					olustur();
					//_applicationObject.Events.SolutionEvents.Opened += SolutionEvents_Opened;
					//m_solutionEvents.AfterClosing += m_closeSolution;

					break;
			}

		}

		private const int ToolwindowInvisible = 0;
		private const int ToolwindowDockStyle = 0;
		private const int ToolwindowVisible = 1;
		private const string MyCommandName = "MyCommand";
		private const string MyCommandCaption = "Tablar";
		private const string MyCommandTooltip = "Show the toolwindow of the add-in";

		private CommandBarButton _myStandardCommandBarButton;
		private EnvDTE.Window _myToolWindow;
		private UserControl1 _myUserControl;
		private void olustur()
		{
			const string vsStandardCommandbarName = "Standard";
			Command myCommand = null;
			object[] contextUiGuids = new object[] { };

			try
			{
				// Try to retrieve the command, just in case it was already created, ignoring the 
				// exception that would happen if the command was not created yet.
				try
				{
					myCommand = _applicationObject.Commands.Item(_addInInstance.ProgID + "." + MyCommandName, -1);
				}
				catch
				{
				}

				// Add the command if it does not exist
				if (myCommand == null)
				{
					myCommand = _applicationObject.Commands.AddNamedCommand(_addInInstance,
					   MyCommandName, MyCommandCaption, MyCommandTooltip, true, 59, ref contextUiGuids,
					   (int)(vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled));
				}

				// Retrieve the collection of commandbars
				CommandBars commandBars = (CommandBars)_applicationObject.CommandBars;

				// Retrieve some built-in commandbars
				CommandBar standardCommandBar = commandBars[vsStandardCommandbarName];

				// Add a button on the "Standard" toolbar
				_myStandardCommandBarButton = (CommandBarButton)myCommand.AddControl(standardCommandBar,
				   standardCommandBar.Controls.Count + 1);

				// Change some button properties
				_myStandardCommandBarButton.Caption = MyCommandCaption;
				_myStandardCommandBarButton.BeginGroup = true;

				// Get if the toolwindow was visible when the add-in was unloaded last time to show it
				Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\SaveTabs");
				if (registryKey != null)
				{
					if ((int)registryKey.GetValue("SaveTabsVisible") == ToolwindowVisible)
					{
						showToolWindow();
					}
					registryKey.Close();
				}

			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
			}

		}
		private void showToolWindow()
		{
			const string toolwindowGuid = "{6CCD0EE9-20DB-4636-9149-665A958D8A9A}";
			object myUserControlObject = null;
			try
			{
				if (_myToolWindow == null) // First time, create it
				{
					EnvDTE80.Windows2 windows2 = (EnvDTE80.Windows2)_applicationObject.Windows;

					string assembly = System.Reflection.Assembly.GetExecutingAssembly().Location;

					_myToolWindow = windows2.CreateToolWindow2(_addInInstance, assembly, typeof(UserControl1).FullName, "Tablar", toolwindowGuid, ref myUserControlObject);
					_myUserControl = (UserControl1)myUserControlObject;
					_myUserControl.Width = 310;
					_myUserControl.Height = 800;
					//_myUserControl.Dock = DockStyle.Right;


				}
				_myToolWindow.Visible = true;
				_myUserControl.Initialize(_applicationObject);
				
			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
			}

		}

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <param name="disconnectMode"></param>
		/// <param name="custom"></param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
			try
			{
				switch (disconnectMode)
				{
					case ext_DisconnectMode.ext_dm_HostShutdown:
					case ext_DisconnectMode.ext_dm_UserClosed:

						if ((_myStandardCommandBarButton != null))
						{
							_myStandardCommandBarButton.Delete(true);
						}

						// Store in the Windows Registry if the toolwindow was visible when unloading the add-in
						int myToolWindowVisible = ToolwindowInvisible;
						int dockStyle = ToolwindowDockStyle;
						if (_myToolWindow != null)
						{
							if (_myToolWindow.Visible)
							{
								myToolWindowVisible = ToolwindowVisible;
							}
							//_myToolWindow.
						}

						Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"Software\SaveTabs");
						registryKey.SetValue("SaveTabsVisible", myToolWindowVisible);
						registryKey.SetValue("SaveTabsVisible", myToolWindowVisible);
						registryKey.Close();

						break;
				}
			}
			catch (System.Exception e)
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
			}

		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
			olustur();

		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		/// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		/// <param term='commandName'>The name of the command to determine state for.</param>
		/// <param term='neededText'>Text that is needed for the command.</param>
		/// <param term='status'>The state of the command in the user interface.</param>
		/// <param term='commandText'>Text requested by the neededText parameter.</param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
			if (neededText == vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
			{
				if (commandName == _addInInstance.ProgID + "." + MyCommandName)
				{
					status = (vsCommandStatus)(vsCommandStatus.vsCommandStatusEnabled | vsCommandStatus.vsCommandStatusSupported);
				}
				else
				{
					status = vsCommandStatus.vsCommandStatusUnsupported;
				}
			}

		}

		/// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		/// <param term='commandName'>The name of the command to execute.</param>
		/// <param term='executeOption'>Describes how the command should be run.</param>
		/// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		/// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		/// <param term='handled'>Informs the caller if the command was handled or not.</param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
			handled = false;
			if ((executeOption == vsCommandExecOption.vsCommandExecOptionDoDefault))
			{
				if (commandName == _addInInstance.ProgID + "." + MyCommandName)
				{
					handled = true;
					showToolWindow();
				}
			}
		}
	}
}