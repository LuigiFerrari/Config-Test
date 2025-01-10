namespace UniqueID
{
    public static class UHWIDEngine
    {
        public static string SimpleUid { get; private set; }

        public static string AdvancedUid { get; private set; }

        public static void setUniqueID()
        {
            var volumeSerial = DiskId.GetDiskId();
            var cpuId = CpuId.GetCpuId();
            var windowsId = WindowsId.GetWindowsId();
            SimpleUid = volumeSerial + cpuId;
            AdvancedUid = SimpleUid + windowsId;
        }

        public static string getSimpleUid()
        { 
            return SimpleUid; 
        }

    }
}