using Windows.System.Profile;
using Microsoft.UI.Xaml;

namespace WinUIGallery
{
	// https://learn.microsoft.com/windows/apps/design/devices/designing-for-tv#custom-visual-state-trigger-for-xbox
	class DeviceFamilyTrigger : StateTriggerBase
	{
		string _actualDeviceFamily, _triggerDeviceFamily;

		public string DeviceFamily
		{
			get { return _triggerDeviceFamily; }
			set
			{
				_triggerDeviceFamily = value;
				_actualDeviceFamily = AnalyticsInfo.VersionInfo.DeviceFamily;
				SetActive(_triggerDeviceFamily == _actualDeviceFamily);
			}
		}
	}
}
