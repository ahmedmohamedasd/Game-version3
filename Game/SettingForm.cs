using AForge.Video.DirectShow;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Game
{
    public partial class SettingForm : Form
    {
        FilterInfoCollection filterInfoCollection;
        int counter = 0;
        PrivateFontCollection mediamFont;
        PrivateFontCollection boldFont;
        ApiService apiService;
        string fontPathMediam = Path.Combine(Application.StartupPath, @"F37BlankaArabic-Medium.ttf");
        string fontPathBold = Path.Combine(Application.StartupPath, @"F37Wicklow-Bold.otf");
        public SettingForm()
        {

             mediamFont = new PrivateFontCollection();
            boldFont = new PrivateFontCollection();
            apiService = new ApiService();
            mediamFont.AddFontFile(fontPathMediam);
            boldFont.AddFontFile(fontPathBold);
            InitializeComponent();
        }
        public FilterInfo GetCameraDevice()
        {
            FilterInfo filterInfo = (FilterInfo)cboDevice.Items[0];
            return filterInfo;
        }

        string path = Path.Combine(Application.StartupPath, @"machineDB.json");

        Color newColour = Color.FromArgb(119, 2, 110);


        private void SettingForm_Load(object sender, EventArgs e)
        {
            int left = Screen.PrimaryScreen.Bounds.Left;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(left, top);
            if (width > 1920)
            {
                width = 1920;
            }
            if (height > 2880)
            {
                height = 2880;
            }



            this.Size = new Size(width, height);
            pictureBox1.Width = width; 
            btn_closing.Left = width - btn_closing.Width - btn_closing.Width;
            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboDevice.Items.Add(filterInfo.Name);
            ListofRotateTypes();

            var model = getMachineModelFromJsonfile();
            txt_ip.Text = model.ip;
            txt_game_id.Text = model.game_id;

            if(model.cameraDeviceIndex != -1)
            {
                cboDevice.SelectedIndex = model.cameraDeviceIndex;
            }
            else
            {
                cboDevice.SelectedIndex = 0;
            }

            panel_container.Left = (this.ClientSize.Width -  panel_container.Width) / 2;
            this.StartPosition = FormStartPosition.CenterScreen;
            panel_add.Visible = true;
          
            #region Styling Form

            lbl_ip.ForeColor = newColour;
            txt_ip.ForeColor = newColour;
            lbl_game_id.ForeColor = newColour;
            btn_Save_camera.ForeColor = newColour;
            txt_game_id.ForeColor = newColour;
            btn_endGame.ForeColor = newColour;
            btn_add.ForeColor = newColour;
            btn_closing.BackColor = newColour;
            btn_closing.ForeColor = Color.White;
            btn_closing.Font = new Font(boldFont.Families[0], 20);
            lbl_rotate.ForeColor = newColour;
            lbl_rotate.Font = new Font(boldFont.Families[0], 20);
            comboBox_rotate.ForeColor = newColour;

            lbl_ip.Font = new Font(boldFont.Families[0], 20);
            txt_ip.Font = new Font(boldFont.Families[0], 15);
            lbl_game_id.Font = new Font(boldFont.Families[0], 20);
            btn_endGame.Font = new Font(mediamFont.Families[0], 20);
            btn_Save_camera.Font = new Font(mediamFont.Families[0], 20);
            txt_game_id.Font = new Font(boldFont.Families[0], 15);

            btn_add.Font = new Font(mediamFont.Families[0], 20);
       
            lbl_Camera2.Font = new Font(boldFont.Families[0], 20);
            lbl_Camera2.ForeColor = newColour;

            #endregion

        }
        public machineDbModel getMachineModelFromJsonfile()
        {
            var jsondata = File.ReadAllText(path);
            machineDbModel model = JsonConvert.DeserializeObject<machineDbModel>(jsondata);
            return model;
        }

        #region old Setting
        //private void SetComboList()
        //{
        //    combo_list_machine.Items.Clear();
        //    var model = getMachineModelFromJsonfile();
        //    if (model.currentMachine.game_id != "")
        //    {
        //        combo_list_machine.Items.Add(model.currentMachine.game_id);
        //        combo_list_machine.SelectedIndex = 0;
        //    }
        //    else
        //    {
        //        combo_list_machine.Items.Add("Select Game");
        //        combo_list_machine.SelectedIndex = 0;
        //    }
        //    if (model.allMachine.Length > 0)
        //    {
        //        for (int i = 0; i < model.allMachine.Length; i++)
        //        {
        //            if (model.currentMachine.game_id != model.allMachine[i].game_id)
        //            {
        //                combo_list_machine.Items.Add(model.allMachine[i].game_id);
        //            }
        //        }
        //    }
        //}
        //private void updateGridView()
        //{
        //  var model = getMachineModelFromJsonfile();

        //    DataTable dataTable = new DataTable();
        //    dataTable.Columns.Add("Game ID");
        //    dataTable.Columns.Add("Machine ID");

        //    foreach (var item in model.allMachine)
        //    {
        //        dataTable.Rows.Add(item.game_id, item.machine_id);
        //    }
        //    dataGridView1.DataSource = dataTable;

        //    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        //    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    dataGridView1.Columns["Game ID"].ReadOnly = true;
        //    dataGridView1.Columns["Machine ID"].ReadOnly = true;

        //    // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
        //    for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
        //    {
        //        // Store Auto Sized Widths:
        //        int colw = dataGridView1.Columns[i].Width;

        //        // Remove AutoSizing:
        //        dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

        //        // Set Width to calculated AutoSize value:
        //        dataGridView1.Columns[i].Width = colw;
        //    }
        //    dataGridView1.Refresh();

        //    SetComboList();
        //}
        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    dataGridView1.CurrentRow.Selected = true;
        //    panel_edit.Visible = true;
        //    panel_add.Visible = true;
        //    txt_edit_gameId.Text = dataGridView1.Rows[e.RowIndex].Cells["Game ID"].Value.ToString();
        //    txt_edit_machineId.Text = dataGridView1.Rows[e.RowIndex].Cells["Machine ID"].Value.ToString();
        //    txt_edit_gameId.ReadOnly = true;
        //}

        //private void btn_cancel_Click(object sender, EventArgs e)
        //{
        //    panel_edit.Visible = false;
        //    panel_add.Visible = true;
        //    txt_edit_gameId.Text = "";
        //    txt_edit_machineId.Text = "";
        //}

        //private void btn_edit_Click(object sender, EventArgs e)
        //{
        //    var model = getMachineModelFromJsonfile();
        //    try
        //    {
        //        if (model.allMachine.Length > 0)
        //        {
        //            BasicMachineModel md = new BasicMachineModel()
        //            {
        //                game_id = txt_edit_gameId.Text,
        //                machine_id = txt_edit_machineId.Text
        //            };
        //            for (int i = 0; i < model.allMachine.Length; i++)
        //            {
        //                if (model.allMachine[i].game_id == md.game_id)
        //                {
        //                    model.allMachine[i].machine_id = md.machine_id;
        //                }
        //            }
        //            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
        //            File.WriteAllText(path, json);
        //            MessageBox.Show("Game Edit Sucessfully");
        //            txt_edit_gameId.Text = "";
        //            txt_edit_machineId.Text ="";
        //            panel_edit.Visible = false;

        //            updateGridView();
        //        }

        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);

        //    }

        //}

        //private void btn_delete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var model = getMachineModelFromJsonfile();
        //        if (model.allMachine.Length > 0)
        //        {
        //            BasicMachineModel md = new BasicMachineModel()
        //            {
        //                game_id = txt_edit_gameId.Text,
        //                machine_id = txt_edit_machineId.Text
        //            };

        //            List<BasicMachineModel> list = new List<BasicMachineModel>();
        //            for (int i = 0; i < model.allMachine.Length; i++)
        //            {
        //                if (model.allMachine[i].game_id != md.game_id)
        //                {
        //                    list.Add(model.allMachine[i]);
        //                }
        //            }
        //            model.allMachine = list.ToArray();
        //            string json = JsonConvert.SerializeObject(model, Formatting.Indented);
        //            File.WriteAllText(path, json);
        //            MessageBox.Show("Game deleted Sucessfully");
        //            txt_edit_gameId.Text = "";
        //            txt_edit_machineId.Text = "";
        //            panel_edit.Visible = false;
        //            updateGridView();
        //        }

        //    }catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
        #endregion


        private void btn_add_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_game_id.Text) || string.IsNullOrWhiteSpace(txt_ip.Text))
            {
                MessageBox.Show("Game id and IP Can not be empty");
            }
            else
            {
                try
                {
                    var jsondata = File.ReadAllText(path);
                    machineDbModel model = JsonConvert.DeserializeObject<machineDbModel>(jsondata);
                    model.ip = txt_ip.Text;
                    model.game_id = txt_game_id.Text;
                    string json = JsonConvert.SerializeObject(model, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MessageBox.Show("Setting Saved Sucessfully");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Closed += (s, args) => this.Close();
            form1.Show();
            this.Hide();
           
        }

        private void btn_Save_camera_Click(object sender, EventArgs e)
        {
            var model = getMachineModelFromJsonfile();
            if (cboDevice.Items[0] != null)
            {
                try
                {
                    var index = cboDevice.SelectedIndex;
                    model.cameraDeviceIndex = index;
                    var rotateIndex = comboBox_rotate.SelectedIndex;   
                    model.cameraRotate = rotateIndex;
                    string json = JsonConvert.SerializeObject(model, Formatting.Indented);
                    File.WriteAllText(path, json);
                    MessageBox.Show("Camera Saved Successfully");
                }catch(Exception ex)
                {
                    MessageBox.Show("Un expected error : " + ex.Message);
                }
              


            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter == 1)
            {
                Close_Timer.Start();
            }
        }

        private void Close_Timer_Tick(object sender, EventArgs e)
        {
            if (counter >= 5)
            {
                Form1 form = new Form1();
                form.Closed += (s, args) => this.Close();
                form.Show();
                this.Hide();
                counter = 0;
            }
            else
            {
                counter = 0;
            }
            Close_Timer.Stop();
        }

        private void btn_closing_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Closed += (s, args) => this.Close();
            form.Show();
            this.Hide();
        }
    

        // btn Current Camera Color
        private void btn_Save_camera_MouseEnter(object sender, EventArgs e)
        {
            btn_Save_camera.BackColor = newColour;
            btn_Save_camera.ForeColor = Color.White;
        }
        private void btn_Save_camera_MouseLeave(object sender, EventArgs e)
        {
            btn_Save_camera.BackColor = Color.White;
            btn_Save_camera.ForeColor = newColour;
        }
        // Add button 
        private void btn_add_MouseEnter(object sender, EventArgs e)
        {
            btn_add.BackColor = newColour;
            btn_add.ForeColor = Color.White;
        }
        private void btn_add_MouseLeave(object sender, EventArgs e)
        {
            btn_add.BackColor = Color.White;
            btn_add.ForeColor = newColour;
        }

        // Edit Button 

        private void btn_closing_MouseEnter(object sender, EventArgs e)
        {
            btn_closing.BackColor = Color.White;
            btn_closing.ForeColor = newColour;
         
        }
        private void btn_closing_MouseLeave(object sender, EventArgs e)
        {
            btn_closing.BackColor = newColour;
            btn_closing.ForeColor = Color.White;
        }

        private void btn_endGame_MouseEnter(object sender, EventArgs e)
        {
            btn_endGame.BackColor = Color.White;
            btn_endGame.ForeColor = newColour;

        }
        private void btn_endGame_MouseLeave(object sender, EventArgs e)
        {
            btn_endGame.BackColor = newColour;
            btn_endGame.ForeColor = Color.White;
        }

        private string GetMachineId()
        {
            string machineId = string.Empty;

            try
            {
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystemProduct"))
                {
                    ManagementObjectCollection collection = searcher.Get();
                    foreach (ManagementObject obj in collection)
                    {
                        machineId = obj["UUID"].ToString();
                        break; // Only retrieve the first machine ID
                    }
                }
            }
            catch (ManagementException)
            {
                // Handle exception if necessary
            }

            return machineId;
        }

        private async void btn_endGame_Click(object sender, EventArgs e)
        {
            var settingModel = getMachineModelFromJsonfile();

            string machineId = GetMachineId();
            var gameFormData = new Dictionary<string, string>
                {
                    {"machine_id", machineId},
                    {"game_id", settingModel.game_id},
                    {"user_id", "1"}
                };
            var forceGameFormData = new Dictionary<string, string>
                {
                    {"game_id",settingModel.game_id }
                };
          
          
            var endGame = await apiService.EndGame(settingModel.ip + "?action=", "end", gameFormData);
            if (endGame.Errors != null )
            {
                MessageBox.Show("Un Expected Error in Ending Game " + endGame.Errors);
            }
            var result = await apiService.ForceEndGame(settingModel.ip + "?action=", "force_game_end", forceGameFormData);
            if (result.Errors == null)
            {
                MessageBox.Show("Game Ended Successfully");
            }
            else
            {
                MessageBox.Show("Un Expected Error " + result.Errors);
            }
        }

        private void ListofRotateTypes()
        {

            foreach (RotateFlipType rotateFlipType in Enum.GetValues(typeof(RotateFlipType)))
            {
                comboBox_rotate.Items.Add(rotateFlipType);
            }
            var model = getMachineModelFromJsonfile();
            if (model.cameraRotate != -1)
            {
                comboBox_rotate.SelectedIndex = model.cameraRotate;
            }
            else
            {
                comboBox_rotate.SelectedIndex = 0;
            }

        }

    }
}
