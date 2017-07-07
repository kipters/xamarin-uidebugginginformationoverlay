using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Kipters.Helpers.iOS
{
    public class UIDebuggingInformationOverlay
    {
        [DllImport(Constants.ObjectiveCLibrary, EntryPoint = "objc_msgSend")]
        private static extern IntPtr objc_msgSend(IntPtr target, IntPtr selector);

        private static readonly IntPtr OverlayClass = Class.GetHandle("UIDebuggingInformationOverlay");
        private static readonly Selector PrepareSelector = new Selector("prepareDebuggingOverlay");
        private static readonly Selector OverlaySelector = new Selector("overlay");
        private static readonly Selector ToggleSelector = new Selector("toggleVisibility");

        private readonly IntPtr _overlay;

        public UIDebuggingInformationOverlay() => _overlay = objc_msgSend(OverlayClass, OverlaySelector.Handle);
        public static void PrepareDebuggingOverlay() => objc_msgSend(OverlayClass, PrepareSelector.Handle);
        public void ToggleVisibility() => objc_msgSend(_overlay, ToggleSelector.Handle);
    }
}
