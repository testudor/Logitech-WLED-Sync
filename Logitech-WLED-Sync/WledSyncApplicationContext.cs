using Config.Net;
using LedCSharp;
using Logitech_WLED_Sync.Properties;
using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logitech_WLED_Sync
{
    internal class WledSyncApplicationContext : ApplicationContext
    {
        private IWledSyncAppSettings settings;

        private NotifyIcon trayIcon;
        private bool isRunning;

        private ColorS targetColor;
        private ColorS currentColor;
        private ColorS startColor;

        private float t = 0;
        private long startTime = 0;
        private long time = 0;

        public WledSyncApplicationContext()
        {
            settings = new ConfigurationBuilder<IWledSyncAppSettings>().UseIniFile(Resources.SETTINGS_FILE).Build();

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Text = Resources.APP_NAME,
                Icon = Resources.IconRunning,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem(Resources.SETTINGS, EditConfig),
                    new MenuItem(Resources.PAUSE, ChangeState),
                    new MenuItem(Resources.EXIT, Exit),
                    new MenuItem("-"),
                    new MenuItem(Resources.APP_NAME+" "+Resources.APP_VERSION),
                }),
                Visible = true
            };

            if (settings.StartEnabled)
            {
                Activate();
            }
            else
            {
                Deactivate();
            }

            _ = UDPLoop();
            _ = ControlLoop();

            Console.WriteLine("Init finished");
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        void EditConfig(object sender, EventArgs e)
        {
            ConfigurationForm configForm = new ConfigurationForm();

            if (configForm.ShowDialog() == DialogResult.OK)
            {
                //Config might have changed, restart
                trayIcon.Visible = false;
                Application.Restart();
            }
        }

        void ChangeState(object sender, EventArgs e)
        {
            if (isRunning)
            {
                Deactivate();
            }
            else
            {
                Activate();
            }
        }

        private async Task UDPLoop()
        {
            using (UdpClient client = new UdpClient(settings.UDPPort))
            {
                while (true)
                {
                    // Wait for packet
                    UdpReceiveResult result = await client.ReceiveAsync();

                    byte[] data = result.Buffer;

                    // Extract data from UDP packet
                    targetColor.Br = data[2];
                    targetColor.R = data[3];
                    targetColor.G = data[4];
                    targetColor.B = data[5];

                    Console.WriteLine("New Color!");
                    ResetLerp();
                }
            }
        }

        private async Task ControlLoop()
        {
            while (true)
            {
                if (isRunning && currentColor != targetColor)
                {
                    if (settings.CrossfadeEnabled && settings.TransitionTime > 0)
                    {
                        if (t < 1)
                        {
                            t = ((float)time / settings.TransitionTime).Clamp(0f, 1f);

                            // Interpolate between start and target based on t
                            currentColor = ColorS.Lerp(startColor, targetColor, t);

                            time = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime;

                            SetColor(currentColor);
                        }
                    }
                    else
                    {
                        currentColor = targetColor;
                        SetColor(currentColor);
                    }
                }

                await Task.Delay(1);
            }
        }

        private void SetColor(ColorS color)
        {
            LogitechGSDK.LogiLedSetLighting(color.R_100, color.G_100, color.B_100);
        }

        private void Activate()
        {
            isRunning = true;
            trayIcon.ContextMenu.MenuItems[1].Text = Resources.PAUSE;
            trayIcon.Icon = Resources.IconRunning;

            LogitechGSDK.LogiLedInitWithName(Resources.APP_NAME);

            SetColor(targetColor);
        }
        private void Deactivate()
        {
            isRunning = false;
            trayIcon.ContextMenu.MenuItems[1].Text = Resources.RESUME;
            trayIcon.Icon = Resources.IconPaused;

            LogitechGSDK.LogiLedShutdown();
        }

        private void ResetLerp()
        {
            t = 0;
            startColor = currentColor;
            startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            time = 0;
        }
    }
}