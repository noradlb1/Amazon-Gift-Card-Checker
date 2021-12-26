using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace GiftCardBot.Properties
{
	// Token: 0x02000007 RID: 7
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000028 RID: 40 RVA: 0x000050A0 File Offset: 0x000032A0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400003E RID: 62
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
