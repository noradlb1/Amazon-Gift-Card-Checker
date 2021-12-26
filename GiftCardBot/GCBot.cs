using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using DeathByCaptcha;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace GiftCardBot
{
	// Token: 0x02000002 RID: 2
	public partial class GCBot : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public GCBot()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000206C File Offset: 0x0000026C
		private void GCBot_Load(object sender, EventArgs e)
		{
			Control.CheckForIllegalCrossThreadCalls = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			Control.CheckForIllegalCrossThreadCalls = false;
			this.delay = 1000;
			this.checkedGC = 0;
			this.validCount = 0;
			this.notValidCount = 0;
			this.totalValue = 0.0;
			this.redeemedCount = 0;
			this.rand = new Random();
			this.drivers = new List<ChromeDriver>();
			this.multiThreads = new List<Thread>();
			this.gcs = new List<string>();
			this.mainThread = null;
			this.invalidLock = new object();
			this.LVLock = new object();
			this.statusLock = new object();
			this.semaphoreLock = new object();
			this.logLock = new object();
			this.alert = false;
			this.error = false;
			this.client = null;
			this.semaphore = "";
			this.fileName = "";
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("GiftCardBot.white-gift-card-icon-6906.ico"))
			{
				this.normal = new Icon(manifestResourceStream);
			}
			using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream("GiftCardBot.Error-128.ico"))
			{
				this.action = new Icon(manifestResourceStream);
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000021D4 File Offset: 0x000003D4
		private void GCBot_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.drivers != null)
			{
				foreach (ChromeDriver chromeDriver in this.drivers)
				{
					if (chromeDriver != null)
					{
						chromeDriver.Quit();
					}
				}
			}
			Environment.Exit(0);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002250 File Offset: 0x00000450
		private void loadConfig()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(File.ReadAllText("config.xml"));
			XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("config");
			this.TBAEmail.Text = elementsByTagName[0]["aemail"].InnerText;
			this.TBAPassword.Text = elementsByTagName[0]["apassword"].InnerText;
			this.TBDBCEmail.Text = elementsByTagName[0]["dbcemail"].InnerText;
			this.TBDBCPassword.Text = elementsByTagName[0]["dbcpassword"].InnerText;
			this.TBGiftCards.Text = elementsByTagName[0]["giftcards"].InnerText;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000232C File Offset: 0x0000052C
		private void saveConfig()
		{
			using (StreamWriter streamWriter = new StreamWriter("config.xml"))
			{
				streamWriter.WriteLine("<config>");
				streamWriter.WriteLine("\t<aemail>" + this.TBAEmail.Text + "</aemail>");
				streamWriter.WriteLine("\t<apassword>" + this.TBAPassword.Text + "</apassword>");
				streamWriter.WriteLine("\t<dbcemail>" + this.TBDBCEmail.Text + "</dbcemail>");
				streamWriter.WriteLine("\t<dbcpassword>" + this.TBDBCPassword.Text + "</dbcpassword>");
				streamWriter.WriteLine("\t<giftcards>" + this.TBGiftCards.Text + "</giftcards>");
				streamWriter.WriteLine("</config>");
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002428 File Offset: 0x00000628
		private void TBThreads_Scroll(object sender, EventArgs e)
		{
			this.LThreads.Text = this.TBThreads.Value + " Thread(s)";
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002454 File Offset: 0x00000654
		private void BExport_Click(object sender, EventArgs e)
		{
			using (StreamWriter streamWriter = new StreamWriter("export_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".txt"))
			{
				foreach (object obj in this.LVCards.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (listViewItem.SubItems[1].Text != "INVALID" && listViewItem.SubItems[1].Text != "REDEEMED")
					{
						streamWriter.WriteLine(listViewItem.SubItems[0].Text + ":" + listViewItem.SubItems[1].Text);
					}
				}
			}
			MessageBox.Show("Done!", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x0000259C File Offset: 0x0000079C
		private void BImport_Click(object sender, EventArgs e)
		{
			if (this.OFDInput.ShowDialog() == DialogResult.OK)
			{
				this.fileName = this.OFDInput.FileName;
				this.LStatus.Text = "File Imported!";
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000025E4 File Offset: 0x000007E4
		private void BClear_Click(object sender, EventArgs e)
		{
			this.LVCards.Items.Clear();
			this.checkedGC = 0;
			this.validCount = 0;
			this.notValidCount = 0;
			this.totalValue = 0.0;
			this.redeemedCount = 0;
			this.LStatus.Text = "Checked: 0 Per Minute";
			this.LValid.Text = "# Of Valid Cards: 0 Cards";
			this.LNotValid.Text = "# Of Invalid Cards: 0 Cards";
			this.LRedeemed.Text = "# Of Redeemed Cards: 0 Cards";
			this.LValue.Text = "Total Value: 00.00";
			this.LStatus.Text = "";
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002694 File Offset: 0x00000894
		private void BGo_Click(object sender, EventArgs e)
		{
			this.mainThread = new Thread(new ThreadStart(this.processData));
			this.mainThread.Start();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000026BA File Offset: 0x000008BA
		private void BPause_Click(object sender, EventArgs e)
		{
			this.togglePause();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000026C4 File Offset: 0x000008C4
		private void togglePause()
		{
			if (this.BPause.Text == "Pause")
			{
				this.BPause.Text = "Resume";
				this.GBDBC.Enabled = true;
				foreach (Thread thread in this.multiThreads)
				{
					if (thread != null && thread.IsAlive)
					{
						thread.Suspend();
					}
				}
				this.mainThread.Suspend();
			}
			else
			{
				this.BPause.Text = "Pause";
				this.GBDBC.Enabled = false;
				this.mainThread.Resume();
				foreach (Thread thread in this.multiThreads)
				{
					if (thread != null && thread.IsAlive)
					{
						thread.Resume();
					}
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002808 File Offset: 0x00000A08
		private void TChangeIcon_Tick(object sender, EventArgs e)
		{
			if (this.alert)
			{
				if (this.error)
				{
					base.Icon = this.action;
					this.error = false;
				}
				else
				{
					base.Icon = this.normal;
					this.error = true;
				}
			}
			else
			{
				base.Icon = this.normal;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000028B8 File Offset: 0x00000AB8
		private void processData()
		{
			this.LVCards.Enabled = false;
			this.BGo.Enabled = false;
			this.TBThreads.Enabled = false;
			this.BExport.Enabled = false;
			this.BImport.Enabled = false;
			this.BClear.Enabled = false;
			this.GBAmazon.Enabled = false;
			this.GBDBC.Enabled = false;
			this.GBGiftCards.Enabled = false;
			this.RBAmazonCom.Enabled = false;
			this.RBAmazonCoUK.Enabled = false;
			this.BPause.Enabled = true;
			try
			{
				this.client = new SocketClient(this.TBDBCEmail.Text, this.TBDBCPassword.Text);
				this.LDBCBalance.Text = "DBC Balance " + this.client.Balance.ToString("00.00") + "$";
				this.getData();
				this.LStatus.Text = "Initializing browsers!";
				int value = this.TBThreads.Value;
				this.multiThreads.Clear();
				this.semaphore = "";
				this.drivers.Clear();
				for (int i = 0; i < value; i++)
				{
					this.drivers.Add(this.initDriver());
					this.multiThreads.Add(null);
					this.semaphore += "0";
				}
				this.checkedGC = 0;
				this.start = new DateTime(DateTime.Now.Ticks);
				for (int i = 0; i < this.gcs.Count; i++)
				{
					int x = i;
					int y;
					for (y = this.semaphore.IndexOf("0"); y == -1; y = this.semaphore.IndexOf("0"))
					{
						Thread.Sleep(this.delay);
					}
					Thread.Sleep(this.delay);
					this.setSemaphore(y, '1');
					this.LDBCBalance.Text = "DBC Balance " + this.checkDBCBalance().ToString("00.00") + "$";
					this.multiThreads[y] = new Thread(delegate()
					{
						this.checkCard(this.drivers[y], this.gcs[x], y);
					});
					this.multiThreads[y].Start();
				}
				foreach (Thread thread in this.multiThreads)
				{
					if (thread != null && thread.IsAlive)
					{
						thread.Join();
					}
				}
				for (int i = 0; i < this.drivers.Count; i++)
				{
					if (this.drivers[i] != null)
					{
						this.drivers[i].Quit();
					}
					this.drivers[i] = null;
				}
			}
			catch (System.Exception ex)
			{
				this.logThis(ex);
			}
			this.LVCards.Enabled = true;
			this.BGo.Enabled = true;
			this.TBThreads.Enabled = true;
			this.BExport.Enabled = true;
			this.BImport.Enabled = true;
			this.BClear.Enabled = true;
			this.GBAmazon.Enabled = true;
			this.GBDBC.Enabled = true;
			this.GBGiftCards.Enabled = true;
			this.RBAmazonCom.Enabled = true;
			this.RBAmazonCoUK.Enabled = true;
			this.BPause.Enabled = false;
			Label lstatus = this.LStatus;
			lstatus.Text += " [Finished!]";
			this.fileName = "";
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002D24 File Offset: 0x00000F24
		private void getData()
		{
			this.gcs.Clear();
			string[] collection = null;
			if (this.fileName != "")
			{
				using (StreamReader streamReader = new StreamReader(this.fileName))
				{
					collection = streamReader.ReadToEnd().Replace("\r\n", "\n").Split(new char[]
					{
						'\n'
					});
				}
			}
			else
			{
				collection = this.TBGiftCards.Text.Replace("\r\n", "\n").Split(new char[]
				{
					'\n'
				});
			}
			this.gcs = new List<string>(collection);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002DF0 File Offset: 0x00000FF0
		private ChromeDriver initDriver()
		{
			GCBot.ChromeOptionsWithPrefs chromeOptionsWithPrefs = new GCBot.ChromeOptionsWithPrefs();
			chromeOptionsWithPrefs.AddExtension("blockimg.crx");
			chromeOptionsWithPrefs.prefs = new Dictionary<string, object>
			{
				{
					"profile.managed_default_content_settings.notifications",
					2
				}
			};
			ChromeDriverService chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;
			ChromeDriver chromeDriver = new ChromeDriver(chromeDriverService, chromeOptionsWithPrefs, new TimeSpan(0, 1, 0));
			this.login(chromeDriver, true);
			return chromeDriver;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002E60 File Offset: 0x00001060
		private void setSemaphore(int index, char value)
		{
			lock (this.semaphoreLock)
			{
				char[] array = this.semaphore.ToCharArray();
				array[index] = value;
				this.semaphore = new string(array);
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002EC4 File Offset: 0x000010C4
		private string solveCaptcha()
		{
			string text = "";
			try
			{
				this.checkDBCBalance();
				this.client = new SocketClient(this.TBDBCEmail.Text, this.TBDBCPassword.Text);
				int num = 5;
				while (text == "" && num-- > 0)
				{
					Captcha captcha = this.client.Decode("captcha.jpg", 20, null);
					if (captcha != null && captcha.Solved && captcha.Correct)
					{
						text = captcha.Text;
					}
				}
			}
			catch (System.Exception ex)
			{
				this.logThis(ex);
			}
			return text;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002F88 File Offset: 0x00001188
		private double checkDBCBalance()
		{
			double num = 0.0;
			try
			{
				this.client = new SocketClient(this.TBDBCEmail.Text, this.TBDBCPassword.Text);
				for (num = this.client.Balance; num <= 0.0; num = this.client.Balance)
				{
					this.LStatus.Text = "Insufficient DBC Balance!";
					this.togglePause();
					Thread.Sleep(this.delay * 2);
					this.client = new SocketClient(this.TBDBCEmail.Text, this.TBDBCPassword.Text);
				}
			}
			catch (System.Exception ex)
			{
				this.logThis(ex);
			}
			this.LStatus.Text = "Balance Checked!";
			return num;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003070 File Offset: 0x00001270
		private void login(ChromeDriver driver, bool first)
		{
			if (first)
			{
				if (this.RBAmazonCom.Checked)
				{
					driver.Navigate().GoToUrl("https://www.amazon.com/gc/redeem/ref=gc_redeem_new_exp_DesktopRedirect");
				}
				else
				{
					driver.Navigate().GoToUrl("https://www.amazon.co.uk/gc/redeem/ref=gc_redeem_new_exp_DesktopRedirect");
				}
				Thread.Sleep(this.delay * 3);
			}
			try
			{
				driver.FindElement(By.Id("ap_email")).Clear();
				Thread.Sleep(this.delay);
				this.typeSlowly(this.TBAEmail.Text, driver.FindElement(By.Id("ap_email")));
				Thread.Sleep(this.delay);
				this.typeSlowly(this.TBAPassword.Text, driver.FindElement(By.Id("ap_password")));
				Thread.Sleep(this.delay);
				driver.FindElement(By.Id("signInSubmit")).Click();
				Thread.Sleep(this.delay * 3);
				int num = 5;
				while (this.tryFindElement(driver, "auth-captcha-image", new GCBot.SearchBy(By.Id)) != null && num-- > 0)
				{
					driver.FindElement(By.Id("ap_password")).Clear();
					Thread.Sleep(this.delay);
					this.typeSlowly(this.TBAPassword.Text, driver.FindElement(By.Id("ap_password")));
					Thread.Sleep(this.delay);
					string attribute = driver.FindElement(By.Id("auth-captcha-image")).GetAttribute("src");
					using (WebClient webClient = new WebClient())
					{
						webClient.DownloadFile(attribute, "captcha.jpg");
					}
					string word = this.solveCaptcha();
					this.typeSlowly(word, driver.FindElement(By.Id("auth-captcha-guess")));
					Thread.Sleep(this.delay);
					driver.FindElement(By.Id("signInSubmit")).Click();
					Thread.Sleep(this.delay * 3);
				}
			}
			catch (System.Exception ex)
			{
				this.logThis(ex);
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000032D8 File Offset: 0x000014D8
		private void checkCard(ChromeDriver driver, string card, int threadId)
		{
			for (;;)
			{
				try
				{
					if (this.tryFindElement(driver, "signInSubmit", new GCBot.SearchBy(By.Id)) != null)
					{
						this.login(driver, false);
						Thread.Sleep(this.delay);
					}
					string text = "";
					driver.FindElement(By.Name("claimCode")).Clear();
					Thread.Sleep(this.delay);
					driver.FindElement(By.Name("claimCode")).SendKeys(card);
					Thread.Sleep(this.delay);
					if (this.tryFindElement(driver, "gc-captcha-image", new GCBot.SearchBy(By.Id)) != null)
					{
						string attribute = driver.FindElement(By.Id("gc-captcha-image")).GetAttribute("src");
						for (;;)
						{
							try
							{
								using (WebClient webClient = new WebClient())
								{
									webClient.DownloadFile(attribute, "captcha.jpg");
								}
								break;
							}
							catch (System.Exception ex)
							{
								Thread.Sleep(this.delay * 2);
							}
						}
						string word = this.solveCaptcha();
						driver.FindElement(By.Id("gc-captcha-code-input")).Clear();
						Thread.Sleep(this.delay);
						this.typeSlowly(word, driver.FindElement(By.Id("gc-captcha-code-input")));
						Thread.Sleep(this.delay);
					}
					driver.FindElement(By.Id("gc-redemption-check-value-button")).Click();
					Thread.Sleep(this.delay * 3);
					if (this.tryFindElement(driver, "a-alert-content", new GCBot.SearchBy(By.ClassName)) != null && driver.FindElement(By.ClassName("a-alert-content")).Displayed)
					{
						if (driver.FindElement(By.ClassName("a-alert-content")).Text.ToLower().Contains("the characters you entered did not match"))
						{
							continue;
						}
						if (driver.FindElement(By.ClassName("a-alert-content")).Text.ToLower().Contains("redeemed to another account"))
						{
							text = "REDEEMED";
							lock (this.invalidLock)
							{
								using (StreamWriter streamWriter = new StreamWriter("redeemed.txt", true))
								{
									streamWriter.WriteLine(card);
								}
							}
							this.redeemedCount++;
						}
					}
					else if (this.tryFindElement(driver, "gc-redemption-check-value-heading", new GCBot.SearchBy(By.Id)) != null)
					{
						text = driver.FindElement(By.Id("gc-redemption-check-value-heading")).Text;
						text = text.Substring(1, text.IndexOf(" ") - 1);
						this.totalValue += double.Parse(text);
						this.validCount++;
					}
					if (text == "")
					{
						text = "INVALID";
						lock (this.invalidLock)
						{
							using (StreamWriter streamWriter = new StreamWriter("invalid.txt", true))
							{
								streamWriter.WriteLine(card);
							}
						}
						this.notValidCount++;
					}
					lock (this.LVLock)
					{
						ListViewItem listViewItem = new ListViewItem(new string[]
						{
							card,
							text
						});
						listViewItem.Name = listViewItem.SubItems[0].Text;
						this.LVCards.Items.Add(listViewItem);
					}
					lock (this.statusLock)
					{
						if (DateTime.Now.Subtract(this.start).Minutes > 0)
						{
							this.LStatus.Text = string.Concat(new object[]
							{
								"Checked: ",
								card,
								" (",
								++this.checkedGC,
								"\\",
								this.gcs.Count,
								") ",
								((double)this.checkedGC / (double)DateTime.Now.Subtract(this.start).Minutes).ToString("0.00"),
								" Per Minute"
							});
						}
						else
						{
							this.LStatus.Text = string.Concat(new object[]
							{
								"Checked: ",
								card,
								" (",
								++this.checkedGC,
								"\\",
								this.gcs.Count,
								") ",
								((double)this.checkedGC).ToString("0.00"),
								" Per Minute"
							});
						}
						this.LValid.Text = "# Of Valid Cards: " + this.validCount + " Cards";
						this.LNotValid.Text = "# Of Invalid Cards: " + this.notValidCount + " Cards";
						this.LRedeemed.Text = "# Of Redeemed Cards: " + this.redeemedCount + " Cards";
						this.LValue.Text = "Total Value: " + this.totalValue.ToString("0.00");
					}
				}
				catch (System.Exception ex)
				{
					try
					{
						driver.Navigate().Refresh();
					}
					catch (System.Exception ex2)
					{
					}
					this.logThis(ex);
				}
				break;
			}
			this.setSemaphore(threadId, '0');
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00003A60 File Offset: 0x00001C60
		private void waitForElement(IWebDriver driver, string elementName, GCBot.SearchBy by)
		{
			try
			{
				WebDriverWait webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15.0));
				IWebElement webElement = webDriverWait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(by(elementName)));
			}
			catch
			{
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00003AB0 File Offset: 0x00001CB0
		private IWebElement tryFindElement(IWebDriver driver, string query, GCBot.SearchBy by)
		{
			IWebElement result = null;
			try
			{
				result = driver.FindElement(by(query));
			}
			catch
			{
			}
			return result;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00003AF0 File Offset: 0x00001CF0
		private void typeSlowly(string word, IWebElement box)
		{
			int minValue = 2;
			int maxValue = 10;
			for (int i = 0; i < word.Length; i++)
			{
				if (this.rand.Next(1, 30) == 1)
				{
					box.SendKeys(string.Concat(word[this.rand.Next(0, word.Length - 1)]));
					Thread.Sleep(this.delay / this.rand.Next(minValue, maxValue));
					box.SendKeys(OpenQA.Selenium.Keys.Backspace);
					Thread.Sleep(this.delay / this.rand.Next(minValue, maxValue));
					box.SendKeys(string.Concat(word[i]));
					Thread.Sleep(this.delay / this.rand.Next(minValue, maxValue));
				}
				else
				{
					box.SendKeys(string.Concat(word[i]));
					Thread.Sleep(this.delay / this.rand.Next(minValue, maxValue));
				}
			}
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00003C10 File Offset: 0x00001E10
		private void logThis(System.Exception ex)
		{
			lock (this.logLock)
			{
				using (StreamWriter streamWriter = new StreamWriter("log.txt", true))
				{
					streamWriter.WriteLine("Time\r\n\r\n" + DateTime.Now.ToString("yyyy/MM/dd-HH:mm") + "\r\n\r\n");
					streamWriter.WriteLine("Message\r\n\r\n" + ex.Message + "\r\n\r\n");
					streamWriter.WriteLine("Data\r\n\r\n" + ex.Data + "\r\n\r\n");
					streamWriter.WriteLine("String\r\n\r\n" + ex.ToString() + "\r\n\r\n");
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private int delay;

		// Token: 0x04000002 RID: 2
		private int checkedGC;

		// Token: 0x04000003 RID: 3
		private int validCount;

		// Token: 0x04000004 RID: 4
		private int notValidCount;

		// Token: 0x04000005 RID: 5
		private int redeemedCount;

		// Token: 0x04000006 RID: 6
		private double totalValue;

		// Token: 0x04000007 RID: 7
		private Random rand;

		// Token: 0x04000008 RID: 8
		private List<ChromeDriver> drivers;

		// Token: 0x04000009 RID: 9
		private Thread mainThread;

		// Token: 0x0400000A RID: 10
		private List<Thread> multiThreads;

		// Token: 0x0400000B RID: 11
		private string semaphore;

		// Token: 0x0400000C RID: 12
		private string fileName;

		// Token: 0x0400000D RID: 13
		private object invalidLock;

		// Token: 0x0400000E RID: 14
		private object LVLock;

		// Token: 0x0400000F RID: 15
		private object statusLock;

		// Token: 0x04000010 RID: 16
		private object semaphoreLock;

		// Token: 0x04000011 RID: 17
		private object logLock;

		// Token: 0x04000012 RID: 18
		private bool alert;

		// Token: 0x04000013 RID: 19
		private bool error;

		// Token: 0x04000014 RID: 20
		private Icon normal;

		// Token: 0x04000015 RID: 21
		private Icon action;

		// Token: 0x04000016 RID: 22
		private List<string> gcs;

		// Token: 0x04000017 RID: 23
		private DateTime start;

		// Token: 0x04000018 RID: 24
		private Client client;

		// Token: 0x02000003 RID: 3
		// (Invoke) Token: 0x0600001D RID: 29
		public delegate By SearchBy(string query);

		// Token: 0x02000004 RID: 4
		public class ChromeOptionsWithPrefs : ChromeOptions
		{
			// Token: 0x17000001 RID: 1
			// (get) Token: 0x06000020 RID: 32 RVA: 0x00004FE8 File Offset: 0x000031E8
			// (set) Token: 0x06000021 RID: 33 RVA: 0x00004FFF File Offset: 0x000031FF
			public Dictionary<string, object> prefs { get; set; }
		}
	}
}
