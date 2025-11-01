#region Usings
using System;
using System.Runtime.Versioning;
using mRemoteNG.Resources.Language;
using mRemoteNG.UI;
using mRemoteNG.UI.Forms;
using mRemoteNG.UI.Window;
#endregion

namespace mRemoteNG.App
{
    [SupportedOSPlatform("windows")]
    public static class WindowsUI
    {
        private static ExternalToolsWindow _externalappsForm;
        private static ConnectionTreeWindow _treeForm;

        internal static ConnectionTreeWindow TreeForm
        {
            get => _treeForm ?? (_treeForm = new ConnectionTreeWindow());
            set => _treeForm = value;
        }

        internal static ConfigWindow ConfigForm { get; set; } = new ConfigWindow();
        internal static ErrorAndInfoWindow ErrorsForm { get; set; } = new ErrorAndInfoWindow();
        private static UpdateWindow UpdateForm { get; set; } = new UpdateWindow();

        public static void Show(WindowType windowType)
        {
            try
            {
                WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel = FrmMain.Default.pnlDock;
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (windowType)
                {
                    case WindowType.Options:
                        FrmMain.OptionsForm.SetActivatedPage(Language.StartupExit);
                        FrmMain.OptionsForm.Visible = true;
                        break;
                    case WindowType.Update:
                        if (UpdateForm == null || UpdateForm.IsDisposed)
                            UpdateForm = new UpdateWindow();
                        UpdateForm.Show(dockPanel);
                        break;
                    case WindowType.ExternalApps:
                        if (_externalappsForm == null || _externalappsForm.IsDisposed)
                            _externalappsForm = new ExternalToolsWindow();
                        _externalappsForm.Show(dockPanel);
                        break;
                }
            }
            catch (Exception ex)
            {
                Runtime.MessageCollector.AddExceptionStackTrace("App.Runtime.Windows.Show() failed.", ex);
            }
        }
    }
}