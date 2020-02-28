using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logitech_WLED_Sync
{
    class WledSyncAppSettings : ApplicationSettingsBase
    {
        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool StartEnabled
        {
            get
            {
                return ((bool)this["StartEnabled"]);
            }
            set
            {
                this["StartEnabled"] = (bool)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("true")]
        public bool CrossfadeEnabled
        {
            get
            {
                return ((bool)this["CrossfadeEnabled"]);
            }
            set
            {
                this["CrossfadeEnabled"] = (bool)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("750")]
        public int TransitionTime
        {
            get
            {
                return ((int)this["TransitionTime"]);
            }
            set
            {
                this["TransitionTime"] = (int)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("21324")]
        public int UDPPort
        {
            get
            {
                return ((int)this["UDPPort"]);
            }
            set
            {
                this["UDPPort"] = (int)value;
            }
        }
    }
}
