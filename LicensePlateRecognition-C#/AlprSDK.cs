using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace KBYAIALPR
{
    enum SDK_ERROR
    {
        SDK_SUCCESS = 0,
        SDK_LICENSE_KEY_ERROR = -1,
        SDK_LICENSE_APPID_ERROR = -2,
        SDK_LICENSE_EXPIRED = -3,
        SDK_NO_ACTIVATED = -4,
        SDK_INIT_ERROR = -5,
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ALPR_RESULT
    {
        public int lp_x1, lp_y1, lp_x2, lp_y2;			//license plate rect;
        public int vl_x1, vl_y1, vl_x2, vl_y2;			//vehicle rect
        public float score;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
        public string number;

        public ALPR_RESULT(int n)
        {
            lp_x1 = lp_x2 = lp_y1 = lp_y2 = 0;
            vl_x1 = vl_x2 = vl_y1 = vl_y2 = 0;
            score = 0;
            number = String.Empty;
        }
    };

    class AlprSDK
    {
        [DllImport("kbyai_alpr.dll")]

        public static extern IntPtr kbyai_alpr_getMachineCode();

        public static String GetMachineCode()
        {
            try
            {
                IntPtr machineCode = kbyai_alpr_getMachineCode();
                if (machineCode == null)
                    throw new Exception("Failed to retrieve machine code.");

                string strMachineCode = Marshal.PtrToStringAnsi(machineCode);
                return strMachineCode;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        [DllImport("kbyai_alpr.dll")]
        public static extern int kbyai_alpr_setActivation(IntPtr license);

        public static int SetActivation(String license)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(license);

            try
            {
                return kbyai_alpr_setActivation(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);
            }
        }

        [DllImport("kbyai_alpr.dll")]
        public static extern int kbyai_alpr_initSDK(IntPtr modelPath);

        public static int InitSDK(String modelPath)
        {
            IntPtr ptr = Marshal.StringToHGlobalAnsi(modelPath);

            try
            {
                return kbyai_alpr_initSDK(ptr);
            }
            finally
            {
                // Free the unmanaged memory when done
                Marshal.FreeHGlobal(ptr);
            }
        }

        [DllImport("kbyai_alpr.dll")]
        public static extern int kbyai_alpr_detection(
            IntPtr rgbData, // Pointer to the RGB data
            int width,      // Width of the image
            int height,     // Height of the image
            [In, Out] ALPR_RESULT[] alprResults, // Array of ALPR_RESULT
            int resultCount// Number of alpr result
        );

        public static int Detection(byte[] rgbData, int width, int height, [In, Out] ALPR_RESULT[] alprResults, int resultCount)
        {
            IntPtr imgPtr = Marshal.AllocHGlobal(rgbData.Length);
            Marshal.Copy(rgbData, 0, imgPtr, rgbData.Length);

            try
            {
                int ret = kbyai_alpr_detection(imgPtr, width, height, alprResults, resultCount);
                return ret;
            }
            finally
            {
                Marshal.FreeHGlobal(imgPtr);
            }
        }
    }
}
