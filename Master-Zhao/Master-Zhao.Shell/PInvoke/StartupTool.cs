﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Master_Zhao.Shell.PInvoke
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct tagSTARTUPITEM
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szPath;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDescription;
        public IntPtr hKey;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szRegPath;
        public uint samDesired;
        public bool bEnabled;
        public int type;
    }


    public class StartupTool
    {
        [DllImport("MasterZhaoCore.dll")]
        public static extern bool CreateStartupRun(string lpszPath);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool RemoveStartupRun(string lpszPath);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool GetStartupItems(IntPtr buffer, int nSizeTarget, ref int count);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool GetStartupDisabledItems(IntPtr buffer, int nSizeTarget, ref int count);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool DisableStartupItem(IntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)] string szRegPath, uint samDesired, [MarshalAs(UnmanagedType.LPWStr)] string szName, int type);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool EnableStartupItem(IntPtr hKey, [MarshalAs(UnmanagedType.LPWStr)] string szRegPath, uint samDesired, [MarshalAs(UnmanagedType.LPWStr)] string szName, int type);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool DisableShellStartupItem([MarshalAs(UnmanagedType.LPWStr)]string szName, [MarshalAs(UnmanagedType.LPWStr)]string szPath);

        [DllImport("MasterZhaoCore.dll")]
        public static extern bool EnableShellStartupItem( [MarshalAs(UnmanagedType.LPWStr)] string szName, [MarshalAs(UnmanagedType.LPWStr)] string szPath);
    }
}
