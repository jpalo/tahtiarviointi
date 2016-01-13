/*
    Taitoluistelun tähtiarviointi
    Copyright(C) 2016 Jussi Palo, jussi@jussipalo.com

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.If not, see<http://www.gnu.org/licenses/>.
*/
using com.jussipalo.tahti.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace com.jussipalo.tahti
{
    public partial class Form1 : Form
    {
        private List<Skater> _finalSkaters;
        private string _generatedFile;
        private int _prevDdlTulospohjaSelectedIndex = 0;
        private Event _event;

        public Form1()
        {
            InitializeComponent();

            _event = new Event();


            RevertDefaultSettings(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            // Fetch default settings
            GetAppSettings();

            txtAikaPaikka.Text = DateTime.Now.ToShortDateString() + ", Porvoo";
            txtTapahtumaSarja.Text = "PTL kuukausikilpailu";
            ddlTulospohja.SelectedIndex = 0;

            base.OnLoad(e);
        }

        private void SelectTemplate(string settingsName, TextBox templateTextBox, string filter)
        {
            // Set filter options and filter index.
            openFileDialog1.Filter = filter;

            // Call the ShowDialog method to show the dialog box.
            DialogResult dr = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (dr == DialogResult.OK)
            {
                Settings.Default[settingsName] = templateTextBox.Text = openFileDialog1.FileName;
                Settings.Default.Save();
            }
        }

        private void btnOpenResultFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(_generatedFile))
            {
                System.Diagnostics.Process.Start(_generatedFile);
            }
        }

        private void SaveChangesToFile()
        {
            string path = "";

            try
            {
                System.Xml.Serialization.XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Event));

                path = Path.Combine(txtOutputFolder.Text, txtAikaPaikka.Text + "_" + txtTapahtumaSarja.Text + "_" + ddlTulospohja.Items[ddlTulospohja.SelectedIndex] + ".xml");
                FileStream file = File.Create(path);

                writer.Serialize(file, _event);
                file.Close();

                toolStripStatusLabel.Text = "Tiedosto tallennettu: ";
                toolStripStatusLink.Text = path;
                toolStripStatusLabel.Visible = toolStripStatusLink.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tiedoston '" + path + "' tallentamisessa tapahtui virhe: " + ex.Message);
            }
        }

        private void UpdateRowStorage(int rowIndex, bool updatedSkater)
        {
            // If coming from last newline row, no need to do anything
            if (rowIndex > -1 && dgvSkaters.Rows[rowIndex].IsNewRow)
            {
                return;
            }

            dgvSkaters.CommitEdit(0);

            // Validate all rows
            foreach (DataGridViewRow row in dgvSkaters.Rows)
            {
                if (row.IsNewRow)
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(row.Cells[0].Value?.ToString()) || string.IsNullOrWhiteSpace(row.Cells[1].Value?.ToString()) || string.IsNullOrWhiteSpace(row.Cells[2].Value?.ToString()))
                {
                    row.ErrorText = "Luistelijan luistelujärjestys, nimi tai seura puuttuu.";
                }
                else
                {
                    row.ErrorText = "";

                    // Add skater if not already exists
                    if (!updatedSkater)
                    {
                        var currSkater = _event.Skaters.Find(s => s.SkatingOrder.Equals(int.Parse(row.Cells[0].Value.ToString())) && s.Name.Equals(row.Cells[1].Value.ToString()) && s.Team.Equals(row.Cells[2].Value.ToString()));
                        if (currSkater == null)
                        {
                            _event.Skaters.Add(new Skater
                            {
                                SkatingOrder = int.Parse(row.Cells[0].Value.ToString()),
                                Name = row.Cells[1].Value.ToString(),
                                Team = row.Cells[2].Value.ToString()
                            });
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Calculates all points for skaters based on individual judges' points
        /// </summary>
        /// <param name="skaters"></param>
        private void CalculatePoints(List<Skater> skaters)
        {
            try
            {
                foreach (var skater in skaters)
                {
                    skater.AveragePointsPerArea.Clear();
                    skater.CircledPoints.Clear();

                    // Average points per area
                    for (int i = 0; i < skater.PointsJudge1.Count; i++)
                    {
                        skater.AveragePointsPerArea.Add((decimal)(skater.PointsJudge1[i] + skater.PointsJudge2[i] + skater.PointsJudge3[i]) / 3);
                    }

                    // Circled points
                    for (int i = 0; i < skater.PointsJudge1.Count; i++)
                    {
                        skater.CircledPoints.Add((int)Math.Round(skater.AveragePointsPerArea[i]));
                    }

                    skater.TotalPoints = Math.Round(skater.AveragePointsPerArea.Sum() - skater.Deductions.Sum(), 2, MidpointRounding.AwayFromZero);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Pisteiden laskussa tapahtui virhe. Tarkista, että kaikilla luistelijoilla on kaikkien tuomareiden pisteet syötettynä.");
            }
        }

        private void InitPointsTable()
        {
            dgvSkaterPoints.RowLeave -= dgvSkaterPoints_RowLeave;
            txtSpiralDeduction.TextChanged -= Deduction_TextChanged;
            txtDressDeduction.TextChanged -= Deduction_TextChanged;
            txtTimeDeduction.TextChanged -= Deduction_TextChanged;
            txtMention.TextChanged -= txtMention_TextChanged;

            dgvSkaterPoints.Rows.Clear();

            if (_event.Skaters.Count == 0)
            {
                return;
            }

            switch (ddlTulospohja.SelectedIndex)
            {
                // Laaja
                case (0):
                case (2):
                    dgvSkaterPoints.Rows.Add("Perusluistelu");
                    dgvSkaterPoints.Rows.Add("Askeleet, liu'ut ja siirtymiset");
                    dgvSkaterPoints.Rows.Add("Hypyt: Vaikeus ja monipuolisuus");
                    dgvSkaterPoints.Rows.Add("Hypyt: Laatu");
                    dgvSkaterPoints.Rows.Add("Piruetit: Vaikeus ja monipuolisuus");
                    dgvSkaterPoints.Rows.Add("Piruetit: Laatu");
                    dgvSkaterPoints.Rows.Add("Esittäminen ja suoritusvarmuus");
                    dgvSkaterPoints.Rows.Add("Musiikkiin luistelu");
                    break;

                //Suppea
                case (1):
                case (3):
                    dgvSkaterPoints.Rows.Add("Perusluistelu ja askeleet");
                    dgvSkaterPoints.Rows.Add("Liu'ut");
                    dgvSkaterPoints.Rows.Add("Hypyt");
                    dgvSkaterPoints.Rows.Add("Piruetit");
                    dgvSkaterPoints.Rows.Add("Esittäminen");
                    break;
            }

            AddSkaterPoints();

            dgvSkaterPoints.RowLeave += dgvSkaterPoints_RowLeave;
            txtSpiralDeduction.TextChanged += Deduction_TextChanged;
            txtDressDeduction.TextChanged += Deduction_TextChanged;
            txtTimeDeduction.TextChanged += Deduction_TextChanged;
            txtMention.TextChanged += txtMention_TextChanged;
        }

        private void AddSkaterPoints()
        {
            if (ddlSkaters.SelectedItem == null && ddlSkaters.Items.Count > 0)
            {
                ddlSkaters.SelectedIndex = 0;
            }

            // If skater points already exists, add points to datagridview
            var currSkater = _event.Skaters.Find(s => s.Name.Equals(((Skater)ddlSkaters.SelectedItem).Name));

            switch (ddlTulospohja.SelectedIndex)
            {
                // Laaja
                case (0):
                case (2):
                    PopulatePointsForArea(8, dgvSkaterPoints, currSkater);
                    break;

                //Suppea
                case (1):
                case (3):
                    PopulatePointsForArea(5, dgvSkaterPoints, currSkater);
                    break;
            }

            if (currSkater.Deductions.Count == 3)
            {
                txtSpiralDeduction.Text = currSkater.Deductions[0] == 0 ? "" : currSkater.Deductions[0].ToString();
                txtTimeDeduction.Text = currSkater.Deductions[1] == 0 ? "" : currSkater.Deductions[1].ToString();
                txtDressDeduction.Text = currSkater.Deductions[2] == 0 ? "" : currSkater.Deductions[2].ToString();
            }
            else
            {
                txtSpiralDeduction.Text = txtTimeDeduction.Text = txtDressDeduction.Text = "";
            }

            txtMention.Text = currSkater.Mention.ToString();
        }

        private void PopulatePointsForArea(int areaCount, DataGridView dgv, Skater currSkater)
        {
            for (int i = 0; i < areaCount; i++)
            {
                if (currSkater.PointsJudge1.Count > i)
                {
                    dgv.Rows[i].Cells[1].Value = currSkater.PointsJudge1[i];
                }

                if (currSkater.PointsJudge2.Count > i)
                {
                    dgv.Rows[i].Cells[2].Value = currSkater.PointsJudge2[i];
                }

                if (currSkater.PointsJudge3.Count > i)
                {
                    dgv.Rows[i].Cells[3].Value = currSkater.PointsJudge3[i];
                }
            }
        }

        #region Event handlerss       
        //private void dgvSkaters_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        //{            
        //    UpdateRowStorage(e.Row.Index, false);
        //}

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog1.Filter = "Excel Template (.xltx)|*.xltx";

            // Call the ShowDialog method to show the dialog box.
            DialogResult dr = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (dr == DialogResult.OK)
            {
                txtTemplateGirlsExtended.Text = openFileDialog1.FileName;
            }
        }
        private void btnSelectTemplate_Click_2(object sender, EventArgs e)
        {
            SelectTemplate("TemplateGirlsExtended", txtTemplateGirlsExtended, "Excel worksheet (.xltx)|*.xltx");
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            SelectTemplate("TemplateBoysExtended", txtTemplateBoysExtended, "Excel worksheet (.xltx)|*.xltx");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectTemplate("TemplateGirlsBasic", txtTemplateGirlsBasic, "Excel worksheet (.xltx)|*.xltx");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectTemplate("TemplateBoysBasic", txtTemplateBoysBasic, "Excel worksheet (.xltx)|*.xltx");
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            SelectTemplate("OutputFolder", txtOutputFolder, "Excel worksheet (.xlsx)|*.xlsx");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog1.Filter = "Excel worksheet (.xlsx)|*.xlsx";

            // Call the ShowDialog method to show the dialog box.
            DialogResult dr = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (dr == DialogResult.OK)
            {
                txtOutputFolder.Text = openFileDialog1.FileName;
            }
        }

        private void dgvSkaterPoints_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ddlSkaters.SelectedItem == null)
                {
                    return;
                }

                dgvSkaterPoints.CommitEdit(0);

                // Save skater points whenever row is edited            
                var currSkater = _event.Skaters.Find(s => s.Name.Equals(((Skater)ddlSkaters.SelectedItem).Name));
                currSkater.PointsJudge1.Clear();
                currSkater.PointsJudge2.Clear();
                currSkater.PointsJudge3.Clear();

                foreach (DataGridViewRow row in dgvSkaterPoints.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        currSkater.PointsJudge1.Add(int.Parse(row.Cells[1].Value.ToString()));
                    }

                    if (row.Cells[2].Value != null)
                    {
                        currSkater.PointsJudge2.Add(int.Parse(row.Cells[2].Value.ToString()));
                    }

                    if (row.Cells[3].Value != null)
                    {
                        currSkater.PointsJudge3.Add(int.Parse(row.Cells[3].Value.ToString()));
                    }
                }
            }
            catch (Exception)
            {
                // This is anyway handled in row validation
            }
        }

        private void Deduction_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                return;
            }

            // Save skater deductions whenever value is edited            
            var currSkater = _event.Skaters.Find(s => s.Name.Equals(((Skater)ddlSkaters.SelectedItem).Name));

            currSkater.Deductions = new List<decimal> {
                decimal.Parse(string.IsNullOrWhiteSpace(txtSpiralDeduction.Text) ? "0": txtSpiralDeduction.Text),
                decimal.Parse(string.IsNullOrWhiteSpace(txtTimeDeduction.Text) ? "0": txtTimeDeduction.Text),
                decimal.Parse(string.IsNullOrWhiteSpace(txtDressDeduction.Text) ? "0": txtDressDeduction.Text) };

            //SaveChangesToFile();
        }

        private void txtMention_TextChanged(object sender, EventArgs e)
        {
            // Save skater mention whenever value is edited            
            var currSkater = _event.Skaters.Find(s => s.Name.Equals(((Skater)ddlSkaters.SelectedItem).Name));

            currSkater.Mention = txtMention.Text;
        }

        private void dgvSkaters_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            _event.Skaters.RemoveAll(s => s.SkatingOrder.Equals(e.Row.Cells[0].Value) && s.Name.Equals(e.Row.Cells[1].Value) && s.Team.Equals(e.Row.Cells[2].Value));
        }

        private void ddlSkaters_SelectionChangeCommitted(object sender, EventArgs e)
        {
            // Init points table for the skater
            InitPointsTable();
        }

        private void txtTemplate_TextChanged(object sender, EventArgs e)
        {
            SaveAppSettings();
        }

        private void btnOletusarvot_Click(object sender, EventArgs e)
        {
            RevertDefaultSettings(true);
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl.SelectedIndex)
            {
                // Kilpailijat
                case (0):
                    InitSkatersTable();
                    break;

                // Pisteet
                case (1):
                    // Fetch skaters                    
                    ddlSkaters.DataSource = null;
                    ddlSkaters.DataSource = _event.Skaters;
                    ddlSkaters.DisplayMember = "Name";


                    InitPointsTable();
                    break;

                // Tulokset
                case (2):

                    if (_event.Skaters.Count == 0)
                    {
                        txtAllFoundSkaters.Text = "";
                        break;
                    }

                    _finalSkaters = _event.Skaters.ToList();

                    CalculatePoints(_finalSkaters);

                    // Sort by points
                    _finalSkaters.Sort((x, y) => SkaterPointCompare(x, y));

                    for (int p = 0; p < _finalSkaters.Count; p++)
                    {
                        if (ddlTulospohja.SelectedItem.ToString().Contains("suppea") && p > 2)
                        {
                            _finalSkaters[p].Position = 0;
                        }
                        else
                        {
                            _finalSkaters[p].Position = p + 1;
                        }
                    }

                    // Re-sort positions 4+ for basic series according to original skating order instead of points
                    _finalSkaters.Sort(3, _finalSkaters.Count - 3, Comparer<Skater>.Create((x, y) => x.SkatingOrder.CompareTo(y.SkatingOrder)));

                    txtAllFoundSkaters.Text = string.Join(Environment.NewLine, _finalSkaters.Select(s => s.Position + ". " + s.Name + " (" + Math.Round(s.TotalPoints, 2, MidpointRounding.AwayFromZero) + ")"));

                    btnSaveOutputFiles.Enabled = btnSaveOutputFiles.Enabled = true;

                    btnSaveOutputFiles.Text = "Luo tulostiedosto";
                    break;
            }
        }

        /// <summary>
        /// Compares skaters based on original skating order.
        /// </summary>
        /// <param name="skaterY"></param>
        /// <param name="skaterX"></param>
        /// <returns></returns>
        //private int SkaterOrderCompare(Skater skaterY, Skater skaterX)
        //{

        //}

        /// <summary>
        /// Compares skaters based on total points. If total points are equal, then "basic skating" defines order, if that is same too, then "presentation" defines order
        /// </summary>
        /// <param name="skaterY"></param>
        /// <param name="skaterX"></param>
        /// <returns></returns>
        private int SkaterPointCompare(Skater skaterX, Skater skaterY)
        {
            if (skaterY.TotalPoints == 0 && skaterX.TotalPoints == 0)
            {
                return 0;
            }

            if (skaterY.TotalPoints == skaterX.TotalPoints)
            {
                if (skaterY.AveragePointsPerArea[0] == skaterX.AveragePointsPerArea[0])
                {
                    int presentationSlot = 4;

                    if (ddlTulospohja.SelectedItem.ToString().ToLower().Contains("laaja"))
                    {
                        presentationSlot = 6;
                    }
                    // Presentation
                    return decimal.Compare(skaterY.AveragePointsPerArea[presentationSlot], skaterX.AveragePointsPerArea[presentationSlot]);
                }
                else {
                    // Basic skating
                    return decimal.Compare(skaterY.AveragePointsPerArea[0], skaterX.AveragePointsPerArea[0]);
                }
            }
            else
            {
                return decimal.Compare(skaterY.TotalPoints, skaterX.TotalPoints);
            }
        }

        private void InitSkatersTable()
        {
            dgvSkaters.RowValidating -= dgvSkaters_RowValidating;
            dgvSkaters.CellValidating -= dgvSkaters_CellValidating;

            dgvSkaters.Rows.Clear();
            dgvSkaters.CommitEdit(0);

            dgvSkaters.RowValidating += dgvSkaters_RowValidating;
            dgvSkaters.CellValidating += dgvSkaters_CellValidating;

            if (_event.Skaters.Count == 0)
            {
                return;
            }

            foreach (var skater in _event.Skaters)
            {
                var row = new DataGridViewRow();
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = skater.SkatingOrder });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = skater.Name });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = skater.Team });

                dgvSkaters.Rows.Add(row);
            }
        }

        private async void btnSaveOutputFiles_Click(object sender, EventArgs e)
        {
            btnSaveOutputFiles.Enabled = btnOpenResultFile.Enabled = false;
            btnSaveOutputFiles.Text = "Odota...";
            _generatedFile = "";

            if (_finalSkaters.Count == 0)
            {
                MessageBox.Show("Luistelijoita ei löytynyt!");
            }

            string tulosPohja = ddlTulospohja.SelectedItem.ToString().ToLower();
            string templateFile = "";

            switch (tulosPohja)
            {
                case ("tytöt laaja"):
                    templateFile = txtTemplateGirlsExtended.Text;
                    break;

                case ("tytöt suppea"):
                    templateFile = txtTemplateGirlsBasic.Text;
                    break;

                case ("pojat laaja"):
                    templateFile = txtTemplateBoysExtended.Text;
                    break;

                case ("pojat suppea"):
                    templateFile = txtTemplateBoysBasic.Text;
                    break;
            }

            Task<string> test = Task<string>.Factory.StartNew(() =>
            {
                return ExcelWorker.GenerateResultFile(tulosPohja, templateFile, txtTapahtumaSarja.Text, txtAikaPaikka.Text, _finalSkaters, txtOutputFolder.Text);
            });

            _generatedFile = test.Result;

            btnSaveOutputFiles.Enabled = true;
            btnSaveOutputFiles.Text = "Luo tulostiedosto";

            if (File.Exists(_generatedFile))
            {
                btnOpenResultFile.Enabled = true;
            }
        }

        #endregion

        #region Settings
        private void GetAppSettings()
        {
            if (string.IsNullOrWhiteSpace(Settings.Default.OutputFolder) &&
               string.IsNullOrWhiteSpace(Settings.Default.TemplateBoysExtended) &&
               string.IsNullOrWhiteSpace(Settings.Default.TemplateGirlsExtended) &&
               string.IsNullOrWhiteSpace(Settings.Default.TemplateBoysBasic) &&
               string.IsNullOrWhiteSpace(Settings.Default.TemplateGirlsBasic))
            {
                RevertDefaultSettings(true);
            }

            txtOutputFolder.Text = Settings.Default.OutputFolder;
            txtTemplateBoysExtended.Text = Settings.Default.TemplateBoysExtended;
            txtTemplateGirlsExtended.Text = Settings.Default.TemplateGirlsExtended;
            txtTemplateBoysBasic.Text = Settings.Default.TemplateBoysBasic;
            txtTemplateGirlsBasic.Text = Settings.Default.TemplateGirlsBasic;
        }

        private void SaveAppSettings()
        {
            Settings.Default.TemplateBoysBasic = txtTemplateBoysBasic.Text;
            Settings.Default.TemplateBoysExtended = txtTemplateBoysExtended.Text;
            Settings.Default.TemplateGirlsBasic = txtTemplateGirlsBasic.Text;
            Settings.Default.TemplateGirlsExtended = txtTemplateGirlsExtended.Text;
            Settings.Default.OutputFolder = txtOutputFolder.Text;

            Settings.Default.Save();
        }

        /// <summary>
        /// Reverts all settings to default values
        /// </summary>
        /// <param name="force"></param>
        private void RevertDefaultSettings(bool force)
        {
            txtTemplateBoysBasic.TextChanged -= txtTemplate_TextChanged;
            txtTemplateBoysExtended.TextChanged -= txtTemplate_TextChanged;
            txtTemplateGirlsBasic.TextChanged -= txtTemplate_TextChanged;
            txtTemplateGirlsBasic.TextChanged -= txtTemplate_TextChanged;
            txtTemplateGirlsExtended.TextChanged -= txtTemplate_TextChanged;
            txtOutputFolder.TextChanged -= txtTemplate_TextChanged;

            if (string.IsNullOrWhiteSpace(txtTemplateBoysBasic.Text + Settings.Default.TemplateBoysBasic) || force)
            {
                Settings.Default.TemplateBoysBasic = Path.Combine(Application.StartupPath, "Resources\\lta_template_boys_basic.xltx");
            }

            if (string.IsNullOrWhiteSpace(txtTemplateBoysExtended.Text + Settings.Default.TemplateBoysExtended) || force)
            {
                Settings.Default.TemplateBoysExtended = Path.Combine(Application.StartupPath, "Resources\\lta_template_boys_extended.xltx");
            }

            if (string.IsNullOrWhiteSpace(txtTemplateGirlsBasic.Text + Settings.Default.TemplateGirlsBasic) || force)
            {
                Settings.Default.TemplateGirlsBasic = Path.Combine(Application.StartupPath, "Resources\\lta_template_girls_basic.xltx");
            }

            if (string.IsNullOrWhiteSpace(txtTemplateGirlsExtended.Text + Settings.Default.TemplateGirlsExtended) || force)
            {
                Settings.Default.TemplateGirlsExtended = Path.Combine(Application.StartupPath, "Resources\\lta_template_girls_extended.xltx");
            }

            if (string.IsNullOrWhiteSpace(txtOutputFolder.Text + Settings.Default.OutputFolder) || force)
            {
                Settings.Default.OutputFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }

            Settings.Default.Save();
            Settings.Default.Reload();

            txtTemplateBoysBasic.Text = Settings.Default.TemplateBoysBasic;
            txtTemplateBoysExtended.Text = Settings.Default.TemplateBoysExtended;
            txtTemplateGirlsBasic.Text = Settings.Default.TemplateGirlsBasic;
            txtTemplateGirlsExtended.Text = Settings.Default.TemplateGirlsExtended;
            txtOutputFolder.Text = Settings.Default.OutputFolder;

            txtTemplateBoysBasic.TextChanged += txtTemplate_TextChanged;
            txtTemplateBoysExtended.TextChanged += txtTemplate_TextChanged;
            txtTemplateGirlsBasic.TextChanged += txtTemplate_TextChanged;
            txtTemplateGirlsBasic.TextChanged += txtTemplate_TextChanged;
            txtTemplateGirlsExtended.TextChanged += txtTemplate_TextChanged;
            txtOutputFolder.TextChanged += txtTemplate_TextChanged;
        }
        #endregion

        private void dgvSkaters_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var oldValue = ((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            string newValue = e.FormattedValue.ToString();

            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
            var currSkater = _event.Skaters.Find(s => s.SkatingOrder.Equals(row.Cells[0].Value) && s.Name.Equals(row.Cells[1].Value.ToString()) && s.Team.Equals(row.Cells[2].Value.ToString()));

            if (oldValue == null || oldValue.Equals(newValue) || currSkater == null)
            {
                return;
            }
            
            switch (e.ColumnIndex)
            {
                case (0):
                    currSkater.SkatingOrder = int.Parse(newValue);
                    break;

                case (1):
                    currSkater.Name = newValue;
                    break;

                case (2):
                    currSkater.Team = newValue;
                    break;
            }

            UpdateRowStorage(e.RowIndex, true);
        }

        private void dgvSkaters_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            UpdateRowStorage(e.RowIndex, false);
        }

        private void ddlTulospohja_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_prevDdlTulospohjaSelectedIndex > -1 && ddlTulospohja.SelectedIndex != _prevDdlTulospohjaSelectedIndex)
            {
                if (MessageBox.Show("Tulospohjan vaihtaminen poistaa kaikki luistelijat tapahtumasta.\n\nValitse Kyllä, jos olet varma ja haluat vaihtaa tulospohjaa.", "Huomautus", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    _event.Type = ddlTulospohja.SelectedItem.ToString();
                    dgvSkaters.Rows.Clear();
                    _event.Skaters.Clear();
                    InitPointsTable();

                    _prevDdlTulospohjaSelectedIndex = ddlTulospohja.SelectedIndex;
                }
                else
                {
                    ddlTulospohja.SelectedIndex = _prevDdlTulospohjaSelectedIndex;
                }
            }
            else
            {
                _event.Type = ddlTulospohja.SelectedItem.ToString();
            }
        }

        private void avaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set filter options and filter index.
            openFileDialog1.Filter = "Pistetiedosto (.xml)|*.xml";

            // Call the ShowDialog method to show the dialog box.
            DialogResult dr = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (dr == DialogResult.OK)
            {
                // Load event data
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(Event));

                StreamReader reader = new StreamReader(openFileDialog1.FileName);
                _event = (Event)serializer.Deserialize(reader);
                reader.Close();

                tabControl.SelectedIndex = 0;

                txtTapahtumaSarja.Text = _event.NameAndSeries;
                txtAikaPaikka.Text = _event.TimeAndPlace;

                ddlTulospohja.SelectedIndexChanged -= ddlTulospohja_SelectedIndexChanged;
                ddlTulospohja.SelectedItem = _event.Type;
                _prevDdlTulospohjaSelectedIndex = ddlTulospohja.SelectedIndex;
                ddlTulospohja.SelectedIndexChanged += ddlTulospohja_SelectedIndexChanged;

                InitSkatersTable();
            }
        }

        private void txtTapahtumaSarja_TextChanged(object sender, EventArgs e)
        {
            _event.NameAndSeries = txtTapahtumaSarja.Text;
        }

        private void txtAikaPaikka_TextChanged(object sender, EventArgs e)
        {
            _event.TimeAndPlace = txtAikaPaikka.Text;
        }

        private void tallennaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChangesToFile();
        }

        private void dgvSkaters_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //string titleText = dgvSkaters.Columns[1].HeaderText;
            //if (titleText.Equals("Seura"))
            //{
            //    TextBox autoText = e.Control as TextBox;
            //    if (autoText != null)
            //    {
            //        autoText.AutoCompleteMode = AutoCompleteMode.Suggest;
            //        autoText.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //        autoText.AutoCompleteCustomSource = AddItems(dgvSkaters);
            //    }
            //}
        }

        private AutoCompleteStringCollection AddItems(DataGridView dgv)
        {
            AutoCompleteStringCollection dataCollection = new AutoCompleteStringCollection();

            dataCollection.AddRange(dgv.Rows.Cast<DataGridViewRow>().Select(r => r.Cells[1]).Cast<string>().ToArray());

            return dataCollection;
        }

        private void dgvSkaterPoints_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 0 || string.IsNullOrEmpty(e.FormattedValue.ToString()))
            {
                return;
            }

            e.Cancel = !ValidateNumberCell(e.FormattedValue.ToString());
        }

        /// <summary>
        /// Validates row cells when leaving row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dgvSkaterPoints_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        //{
        //    for (int i = 1; i < dgvSkaterPoints.Rows[e.RowIndex].Cells.Count; i++)
        //    {
        //        if (!ValidateNumberCell(dgvSkaterPoints.Rows[e.RowIndex].Cells[i].Value.ToString()))
        //        {
        //            e.Cancel = true;
        //            break;
        //        }
        //    }
        //}

        /// <summary>
        /// Validates cell value is betwen valid values for the series
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool ValidateNumberCell(string value)
        {
            int points;

            if (!int.TryParse(value, out points))
            {
                return false;
            }

            if (ddlTulospohja.SelectedItem.ToString().ToLower().Contains("laaja"))
            {
                if (points < 1 || points > 8)
                {
                    return false;
                }
            }
            else
            {
                if (points < 1 || points > 6)
                {
                    return false;
                }
            }

            return true;
        }
    }
}