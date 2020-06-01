using Config.Net;

namespace Logitech_WLED_Sync
{
    public interface IWledSyncAppSettings
    {
        [Option(DefaultValue = "true")]
        bool StartEnabled { get; set; }
        [Option(DefaultValue = "true")]
        bool CrossfadeEnabled { get; set; }
        [Option(DefaultValue = "750")]
        int TransitionTime { get; set; }
        [Option(DefaultValue = "21324")]
        int UDPPort { get; set; }
    }
}
