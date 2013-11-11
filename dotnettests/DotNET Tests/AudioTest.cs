using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Media;
/*using Microsoft.DirectX; // DirectSound stuff not working :(
using Microsoft.DirectX.DirectSound;*/

namespace DotNET_Tests
{
    public partial class AudioTest : Form
    {
        SoundPlayer player = new SoundPlayer();

        // DirectSound stuff
        /*private Device ApplicationDevice = null;
        private DevicesCollection DevicesCollection = null;
        private SecondaryBuffer ApplicationBuffer = null;*/

        private string original;

        // DLL Imports
        [System.Runtime.InteropServices.DllImport("winmm.DLL", EntryPoint = "PlaySound", SetLastError = true)]
        private static extern bool PlaySound(string szSound, System.IntPtr hMod, PlaySoundFlags flags);

        [System.Flags]
        public enum PlaySoundFlags : int
        {
            SND_SYNC = 0x0000,
            SND_ASYNC = 0x0001,
            SND_NODEFAULT = 0x0002,
            SND_LOOP = 0x0008,
            SND_NOSTOP = 0x0010,
            SND_NOWAIT = 0x00002000,
            SND_FILENAME = 0x00020000,
            SND_RESOURCE = 0x00040004
        }

        // DirectSound device description
        /*private struct DeviceDescription
        {
            public DeviceInformation info;
            public override string ToString()
            {
                return info.Description;
            }
            public DeviceDescription(DeviceInformation d)
            {
                info = d;
            }
        }*/

        // Loading

        public AudioTest()
        {
            InitializeComponent();
        }

        private void AudioTest_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            labelWMPVersion.Text = "Windows Media Player Version: " + axWindowsMediaPlayer.versionInfo;
            labelWMPStatus.Text = "WMP Status: " + axWindowsMediaPlayer.status;

            // Retrieve the DirectSound Devices first.
            /*DevicesCollection = new DevicesCollection();

            foreach (DeviceInformation dev in DevicesCollection)
            {
                DeviceDescription dd = new DeviceDescription(dev);
                comboBoxDXDevice.Items.Add(dd);
            }

            // Select the first item in the combobox
            if (0 < comboBoxDXDevice.Items.Count)
                comboBoxDXDevice.SelectedIndex = 0;*/
        }

        // Basic tab

        private void buttonBasicBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogWave.ShowDialog() == DialogResult.OK)
                textBoxBasicFileName.Text = openFileDialogWave.FileName;
        }

        private void buttonPlaySoundSync_Click(object sender, EventArgs e)
        {
            if (!PlaySound(textBoxBasicFileName.Text, new IntPtr(), PlaySoundFlags.SND_SYNC))
                Tools.Error("Could not play sound");
        }

        private void buttonPlaySoundAsync_Click(object sender, EventArgs e)
        {
            if (!PlaySound(textBoxBasicFileName.Text, new IntPtr(), PlaySoundFlags.SND_ASYNC | (checkBoxLoopAsync.Checked ? PlaySoundFlags.SND_LOOP : 0)))
                Tools.Error("Could not play sound");
        }

        private void buttonStopAsync_Click(object sender, EventArgs e)
        {
            PlaySound(null, new IntPtr(), 0);
        }

        private void buttonSoundPlayerSync_Click(object sender, EventArgs e)
        {
            player.SoundLocation = textBoxBasicFileName.Text;

            player.PlaySync();
        }

        private void buttonSoundPlayerAsync_Click(object sender, EventArgs e)
        {
            player.SoundLocation = textBoxBasicFileName.Text;

            if (checkBoxLoopAsync.Checked)
                player.PlayLooping();
            else
                player.Play();
        }

        private void buttonSoundPlayerStopAsync_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void buttonSoundPlayerPlayResource_Click(object sender, EventArgs e)
        {
            player.Stream = DotNET_Tests.Properties.Resources.winAquariumSysStart;

            if (checkBoxLoopAsync.Checked)
                player.PlayLooping();
            else
                player.Play();
        }

        // WMP tab

        private void buttonWMPBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;

            textBoxWMPFileName.Text = openFileDialog.FileName;
            axWindowsMediaPlayer.URL = textBoxWMPFileName.Text;
        }

        private void buttonPlaylist_Click(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylistArray array = axWindowsMediaPlayer.playlistCollection.getAll();
            contextMenuStripPlaylist.Items.Clear();
            for (int x = 0; x < array.count; x++)
            {
                WMPLib.IWMPPlaylist playlist = array.Item(x);
                contextMenuStripPlaylist.Items.Add(playlist.name, null, contextMenuStripPlaylist_Click);
            }
            contextMenuStripPlaylist.Show(PointToScreen(new Point(buttonPlaylist.Left, buttonPlaylist.Bottom)));
        }

        private void contextMenuStripPlaylist_Click(object sender, EventArgs e)
        {
            WMPLib.IWMPPlaylistArray array = axWindowsMediaPlayer.playlistCollection.getAll();
            for (int x = 0; x < array.count; x++)
            {
                WMPLib.IWMPPlaylist playlist = array.Item(x);
                if (sender.ToString() == playlist.name)
                    axWindowsMediaPlayer.currentPlaylist = playlist;
            }
        }

        private void axWindowsMediaPlayer_StatusChange(object sender, EventArgs e)
        {
            labelWMPStatus.Text = "WMP Status: " + axWindowsMediaPlayer.status;
        }

        // DXAudio tab

        private void buttonDXBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialogWave.ShowDialog() == DialogResult.OK)
                textBoxDXFileName.Text = openFileDialogWave.FileName;
        }

        private void buttonDXPlay_Click(object sender, EventArgs e)
        {
            // Check to see if there is a device
            /*if (comboBoxDXDevice.Items.Count == 0)
            {
                Tools.Error("No devices are available");
                return;
            }

            // Stop the sound if it's already playing before you open the the dialog
            if (ApplicationBuffer != null)
            {
                ApplicationBuffer.Stop();
            }

            try
            {
                DeviceDescription itemSelect = (DeviceDescription)comboBoxDXDevice.Items[comboBoxDXDevice.SelectedIndex];
                if (Guid.Empty == itemSelect.info.DriverGuid)
                    ApplicationDevice = new Device();
                else
                    ApplicationDevice = new Device(itemSelect.info.DriverGuid);

                ApplicationDevice.SetCooperativeLevel(this, CooperativeLevel.Priority);
            }
            catch (Exception)
            {
                Tools.Error("Unable to create device");
                return;
            }

            try
            {
                ApplicationBuffer = new SecondaryBuffer(textBoxDXFileName.Text, ApplicationDevice);
            }
            catch (Exception)
            {
                Tools.Error("Unable to create buffer");
                return;
            }

            if (ApplicationBuffer != null)
                ApplicationBuffer.Play(0, BufferPlayFlags.Default);*/
        }

        private void AudioTest_Deactivate(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
                original = textBoxWMPFileName.Text;
                axWindowsMediaPlayer.URL = "";
                axWindowsMediaPlayer.Visible = false;
                textBoxWMPFileName.Text = "";
            }
        }

        private void labelWMPStatus_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer.Visible = true;
        }
    }
}