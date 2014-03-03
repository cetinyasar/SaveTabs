using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using EnvDTE;
using EnvDTE80;

namespace SaveTabs
{
	public partial class UserControl1 : UserControl
	{
		private DTE2 _applicationObject;
		private string dosyaAdi = "Tabs.txt";
		private string _projeDizini = "";
		private Events2 m_events;
		private SolutionEvents m_solutionEvents;

		public UserControl1()
		{
			InitializeComponent();
			treeListe.Nodes.Clear();
		}

		private void btnYeniCalismaAlani_Click(object sender, EventArgs e)
		{
			treeListe.Nodes.Add(txtYeniCalismaAlani.Text);
		}

		private void acikPencereyiEkleToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!DizinVeDokumanSecili()) return;

			TreeNode treeNode = treeListe.SelectedNode.Nodes.Add(_applicationObject.ActiveDocument.ActiveWindow.Caption);
			treeNode.Tag = _applicationObject.ActiveDocument.ActiveWindow.Document.FullName;
			treeNode.ToolTipText = _applicationObject.ActiveDocument.ActiveWindow.Document.FullName;
			export(treeListe, Path.Combine(_projeDizini, dosyaAdi));
		}

		private bool DizinVeDokumanSecili()
		{
			if (treeListe.SelectedNode == null || treeListe.SelectedNode.Parent != null)
			{
				MessageBox.Show("Ana dizin seçin");
				return false;
			}
			if (_applicationObject.ActiveDocument == null)
			{
				MessageBox.Show("Açık döküman seçilemedi");
				return false;
			}
			return true;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="applicationObject"></param>
		public void Initialize(DTE2 applicationObject)
		{
			_applicationObject = applicationObject;
			m_events = (Events2)_applicationObject.Events;
			m_solutionEvents = m_events.SolutionEvents;
			m_solutionEvents.Opened += SolutionEvents_Opened;
			m_solutionEvents.BeforeClosing += m_solutionEvents_BeforeClosing;

			if (_applicationObject.Solution.FullName != "")
			{
				ProjeAcildiIlkAyarlariYap(Path.GetDirectoryName(_applicationObject.Solution.FullName));
			}
		}

		void m_solutionEvents_BeforeClosing()
		{
			treeListe.Nodes.Clear();
		}

		void SolutionEvents_Opened()
		{
			//MessageBox.Show("SolutionEvents_Opened");
			ProjeAcildiIlkAyarlariYap(Path.GetDirectoryName(_applicationObject.Solution.FullName));
		}

		public void ProjeAcildiIlkAyarlariYap(string getDirectoryName)
		{
			treeListe.Nodes.Clear();
			_projeDizini = getDirectoryName;
			string dosya = Path.Combine(getDirectoryName, dosyaAdi);
			TreeNode sonNode = null;
			if (File.Exists(dosya))
			{
				try
				{
					this.Cursor = Cursors.WaitCursor;
					StreamReader sr = new StreamReader(dosya);
					string satir = sr.ReadLine();
					Dictionary<string, TreeNode> eklenenler = new Dictionary<string, TreeNode>();
					while (satir != null)
					{
						string[] tokens = satir.Split(new char[] { '~' }, StringSplitOptions.RemoveEmptyEntries);
						
						if (tokens.Length == 1)
						{
							TreeNode treeNode = treeListe.Nodes.Add(tokens[0]);
							eklenenler.Add(tokens[0], treeNode);
						}
						else
						{
							//string[] adi = tokens[1].Split('|');
							TreeNode eklenen = eklenenler[tokens[0]].Nodes.Add(tokens[1]);
							eklenen.Tag = tokens[2];
							eklenen.ToolTipText = tokens[2];
							//eklenenler.Add(tokens[0], treeNode);

						}

						satir = sr.ReadLine();
					}


					treeListe.ExpandAll();
				}
				catch (XmlException xExc)
				//Exception is thrown is there is an error in the Xml
				{
					MessageBox.Show(xExc.Message);
				}
				catch (Exception ex) //General exception
				{
					MessageBox.Show(ex.Message);
				}
				finally
				{
					this.Cursor = Cursors.Default; //Change the cursor back
				}
			}
		}

		public void export(TreeView tv, string filename)
		{
			StreamWriter tr = new StreamWriter(filename);
			foreach (TreeNode node in tv.Nodes)
			{
				tr.WriteLine(node.FullPath + "~" + node.Tag);
				saveNode2(node.Nodes, tr);
			}
			tr.Close();
		}

		private void saveNode2(TreeNodeCollection tnc, StreamWriter tr)
		{
			foreach (TreeNode node in tnc)
			{
				if (node.Nodes.Count > 0)
				{
					tr.WriteLine(node.FullPath + "~" + node.Tag);
					saveNode2(node.Nodes, tr);
				}
				else //No child nodes, so we just write the text
				{
					tr.WriteLine(node.FullPath + "~" + node.Tag);
				}
			}
		}

		private void btnAcikTekPencereEkle_Click(object sender, EventArgs e)
		{
			if (!DizinVeDokumanSecili()) return;
			acikPencereyiEkleToolStripMenuItem_Click(sender, e);
		}

		private void btnTumAciklariEkle_Click(object sender, EventArgs e)
		{
			if (!DizinVeDokumanSecili()) return;
			foreach (Document doc in _applicationObject.Documents)
			{
				TreeNode treeNode = treeListe.SelectedNode.Nodes.Add(doc.ActiveWindow.Caption);
				treeNode.Tag = doc.FullName;
				treeNode.ToolTipText = doc.FullName;
			}
			export(treeListe, Path.Combine(_projeDizini, dosyaAdi));
		}

		private void treeListe_DoubleClick(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeListe.SelectedNode;
			if (selectedNode.Nodes.Count > 0)
			{
				foreach (TreeNode tn in selectedNode.Nodes)
				{
					if (tn.Tag.ToString() != "")
					{
						_applicationObject.ItemOperations.OpenFile(tn.Tag.ToString());
					}
				}
			}
			else
			{
				if (selectedNode.Tag.ToString() != "")
				{
					_applicationObject.ItemOperations.OpenFile(selectedNode.Tag.ToString());
				}
			}
		}


		private void silToolStripMenuItem_Click(object sender, EventArgs e)
		{
			treeListe.SelectedNode.Remove();
			export(treeListe, Path.Combine(_projeDizini, dosyaAdi));
		}
	}
}
