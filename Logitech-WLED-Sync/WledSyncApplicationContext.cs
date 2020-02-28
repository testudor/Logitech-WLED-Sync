using LedCSharp;
using Logitech_WLED_Sync.Properties;
using System;
using System.Drawing;
using System.Net.Sockets;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logitech_WLED_Sync
{
    internal class WledSyncApplicationContext : ApplicationContext
    {
        private WledSyncAppSettings settings;

        private int port;

        private NotifyIcon trayIcon;
        private CancellationTokenSource cts;
        private bool isRunning = true;

        private int targetR, targetG, targetB;
        private int currentR, currentG, currentB;

        public WledSyncApplicationContext()
        {
            settings = new WledSyncAppSettings();

            Icon notifyIcon;
            string changeStateText;

            // Change variables depending on wether sync is enbaled on start or not
            if (settings.StartEnabled)
            {
                notifyIcon = Resources.IconRunning;
                changeStateText = Resources.PAUSE;
                isRunning = true;
            }
            else
            {
                notifyIcon = Resources.IconPaused;
                changeStateText = Resources.RESUME;
                isRunning = false;
            }

            port = settings.UDPPort;

            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = notifyIcon,
                ContextMenu = new ContextMenu(new MenuItem[] {
                    new MenuItem(Resources.SETTINGS, EditConfig),
                    new MenuItem(changeStateText, ChangeState),
                    new MenuItem(Resources.EXIT, Exit),
                }),
                Visible = true
            };

            cts = new CancellationTokenSource();

            if (isRunning)
            {
                LogitechGSDK.LogiLedInit();
            }

            UDPLoop(cts.Token);
        }

        void Exit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            cts.Cancel();
            Application.Exit();
        }

        void EditConfig(object sender, EventArgs e)
        {
            ConfigurationForm configForm = new ConfigurationForm();

            if (configForm.ShowDialog() == DialogResult.OK)
            {
                trayIcon.Visible = false;
                Application.Restart();
            }
        }

        void ChangeState(object sender, EventArgs e)
        {
            isRunning = !isRunning;

            var senderItem = (MenuItem)sender;

            if (isRunning)
            {
                senderItem.Text = Resources.PAUSE;
                trayIcon.Icon = Resources.IconRunning;
                LogitechGSDK.LogiLedInit();
                LogitechGSDK.LogiLedSetLighting(targetR, targetG, targetB);
            }
            else
            {
                senderItem.Text = Resources.RESUME;
                trayIcon.Icon = Resources.IconPaused;
                LogitechGSDK.LogiLedShutdown();
            }
        }

        private async Task UDPLoop(CancellationToken token)
        {
            using (UdpClient client = new UdpClient(settings.UDPPort))
            {
                while (!token.IsCancellationRequested)
                {
                    UdpReceiveResult result = await client.ReceiveAsync();

                    byte[] data = result.Buffer;

                    int brightness = data[2];
                    brightness = brightness.Remap(0, 255, 0, 100);
                    int r = data[3];
                    targetR = r.Remap(0, 255, 0, brightness);
                    int g = data[4];
                    targetG = g.Remap(0, 255, 0, brightness);
                    int b = data[5];
                    targetB = b.Remap(0, 255, 0, brightness);

                    if (isRunning)
                    {
                        if (settings.CrossfadeEnabled & settings.TransitionTime>0)
                        {
                            await FadeToTarget();
                        }
                        else
                        {
                            currentR = targetR;
                            currentG = targetG;
                            currentB = targetB;

                            LogitechGSDK.LogiLedSetLighting(currentR, currentG, currentB);
                        }
                    }
                }

                Console.WriteLine("Cancel");
            }
        }

        private async Task FadeToTarget()
        {
            int startR = currentR;
            int startG = currentG;
            int startB = currentB;

            long startTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            long time = 0;
            float t = 0;
            while (t < 1)
            {
                t = (float)time / settings.TransitionTime;
                t = t.Clamp(0f, 1f);

                currentR = startR + (int)Math.Round((targetR - startR) * t);
                currentG = startG + (int)Math.Round((targetG - startG) * t);
                currentB = startB + (int)Math.Round((targetB - startB) * t);

                time = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - startTime;

                LogitechGSDK.LogiLedSetLighting(currentR, currentG, currentB);

                await (Task.Delay(1));
            }
        }
    }
}