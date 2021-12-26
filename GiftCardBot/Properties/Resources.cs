using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GiftCardBot.Properties
{
	// Token: 0x02000006 RID: 6
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x06000024 RID: 36 RVA: 0x0000502B File Offset: 0x0000322B
		internal Resources()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000025 RID: 37 RVA: 0x00005038 File Offset: 0x00003238
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceMan == null)
				{
					ResourceManager resourceManager = new ResourceManager("GiftCardBot.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000026 RID: 38 RVA: 0x00005080 File Offset: 0x00003280
		// (set) Token: 0x06000027 RID: 39 RVA: 0x00005097 File Offset: 0x00003297
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400003C RID: 60
		private static ResourceManager resourceMan;

		// Token: 0x0400003D RID: 61
		private static CultureInfo resourceCulture;
	}
}
