using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectOutputCSharpWrapper;

namespace Elite_GPS
{
    class X52 : IDisposable
    {
        const int DEFAULT_PAGE = 0;

        DirectOutput DeviceInterface;
        IntPtr device;

        String Line1;
        String Line2;
        String Line3;

        public X52()
        {
            DeviceInterface = new DirectOutput();
            DeviceInterface.Initialize("ED GPS");
            DeviceInterface.Enumerate(DirectOutputDeviceEnumerate);
            DeviceInterface.RegisterDeviceCallback(DirectOutputDeviceChanged);
        }

        public void Dispose()
        {
            DeviceInterface.Deinitialize();
        }

        private void DirectOutputDeviceEnumerate(IntPtr dev, IntPtr target)
        {
            if (this.device != new IntPtr(0))
            {
                throw new Exception("Attempting to initialize DirectOutput device when it is alrady initialized.");
            }

            Console.WriteLine(String.Format("Adding new DirectOutput device {0} of type: {1}", dev, DeviceInterface.GetDeviceType(dev)));

            this.device = dev;
            DeviceInterface.AddPage(device, DEFAULT_PAGE, DirectOutput.IsActive);
            DeviceInterface.RegisterPageCallback(this.device, DirectOutputDevicePageChanged);
            RefreshDeviceData();
        }

        private void DirectOutputDeviceChanged(IntPtr dev, bool added, IntPtr target)
        {
            if (added)
            {
                DirectOutputDeviceEnumerate(dev, target);
            }
            else
            {
                Console.WriteLine(String.Format("Device {0} removed from the system.", dev));
                if (dev == this.device)
                {
                    this.device = new IntPtr(0);
                }
            }
        }

        private void DirectOutputDevicePageChanged(IntPtr dev, Int32 page, bool activated, IntPtr target)
        {
            if (page == DEFAULT_PAGE && activated == true)
            {
                RefreshDeviceData();
            }
        }

        public bool SetText(int line, String text)
        {
            bool result = false;
            switch(line)
            {
                case 1:
                    if(Line1 != text)
                    {
                        Line1 = text;
                        if (device != new IntPtr(0))
                        {
                            DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.FirstLine, text);
                        }
                        result = true;
                    }
                    break;
                case 2:
                    if (Line2 != text)
                    {
                        Line2 = text;
                        if (device != new IntPtr(0))
                        {
                            DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.SecondLine, text);
                        }
                        result = true;
                    }
                    break;
                default:
                    if (Line3 != text)
                    {
                        Line3 = text;
                        if (device != new IntPtr(0))
                        {
                            DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.ThirdLine, text);
                        }
                        result = true;
                    }
                    break;
            }

            return result;
        }

        public void RefreshDeviceData()
        {
            if (Line1 != null)
            {
                DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.FirstLine, Line1);
            }
            if (Line2 != null)
            {
                DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.SecondLine, Line2);
            }
            if (Line3 != null)
            {
                DeviceInterface.SetString(device, DEFAULT_PAGE, (int)Strings.ThirdLine, Line3);
            }
        }
    }
}