using System;
using System.Runtime.Versioning;
using System.Windows.Forms;
using mRemoteNG.App;
using mRemoteNG.Resources.Language;

namespace mRemoteNG.UI.Menu
{
    [SupportedOSPlatform("windows")]
    public class ToolsMenu : ToolStripMenuItem
    {
        private ToolStripMenuItem _mMenToolsExternalApps;

        public Form MainForm { get; set; }

        public ToolsMenu()
        {
            Initialize();
        }

        private void Initialize()
        {
            _mMenToolsExternalApps = new ToolStripMenuItem();
            // 
            // mMenTools
            // 
            DropDownItems.AddRange(new ToolStripItem[]
            {
                _mMenToolsExternalApps,
            });
            Name = "mMenTools";
            Size = new System.Drawing.Size(48, 20);
            Text = Language._Tools;
            // 
            // mMenToolsExternalApps
            // 
            _mMenToolsExternalApps.Image = Properties.Resources.Console_16x;
            _mMenToolsExternalApps.Name = "mMenToolsExternalApps";
            _mMenToolsExternalApps.Size = new System.Drawing.Size(184, 22);
            _mMenToolsExternalApps.Text = Language.ExternalTool;
            _mMenToolsExternalApps.Click += mMenToolsExternalApps_Click;
        }

        public void ApplyLanguage()
        {
            Text = Language._Tools;
            _mMenToolsExternalApps.Text = Language.ExternalTool;
        }

        #region Tools

        private void mMenToolsExternalApps_Click(object sender, EventArgs e)
        {
            WindowsUI.Show(WindowType.ExternalApps);
        }

        private void mMenToolsOptions_Click(object sender, EventArgs e)
        {
            WindowsUI.Show(WindowType.Options);
        }

        #endregion
    }
}