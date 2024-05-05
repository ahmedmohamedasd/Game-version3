using AForge.Controls;
using AForge.Video;
using AForge.Video.DirectShow;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Game
{
    public partial class Form1 : Form
    {
        PrivateFontCollection mediamFont;
        PrivateFontCollection boldFont;
        List<RotateFlipType> listOftypes;
        //private IAMCameraControl cameraControl;
        string fontPathMediam = Path.Combine(Application.StartupPath, @"F37BlankaArabic-Medium.ttf");
        string fontPathBold = Path.Combine(Application.StartupPath, @"F37Wicklow-Bold.otf");
        string machinId = string.Empty;
        RotateFlipType fotateFlipe;
        ApiService apiService = new ApiService();
        bool isUserLogged = false;
        public Form1()
        {
            mediamFont = new PrivateFontCollection();
            boldFont = new PrivateFontCollection();
            mediamFont.AddFontFile(fontPathMediam);
            boldFont.AddFontFile(fontPathBold);
            machinId = GetMachineId();
            InitializeComponent();
            //this.Resize += Form_Load;

      
        }

        string phUserName = "Your Name";
        string phUserEmail = "Your Email";
        string qrCode = "";
        
        Color farbe;
        Color newColour = Color.FromArgb(119, 2, 110);
        FilterInfoCollection filterInfoCollection;
        VideoCaptureDevice captureDevice;
        private VideoCapabilities[] videoCapabilities;
        string apiUrl = string.Empty;

        ApiService service = new ApiService();
        private int counter = 0;
        private DateTime _lastClickedAt = DateTime.MinValue;
        UserModel currentUser = new UserModel();
        SettingForm settingForm = new SettingForm();
        int currentZoomIndex = 0;
        private int closingCounter = 0;
       

        private async void Form1_Load(object sender, EventArgs e)
        {
            #region Font Type 
            pictureBox_Scanning.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox_Scanning.Dock = DockStyle.Fill;
            pictureBox_Scanning.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            Scan_Message1.Font = new Font(boldFont.Families[0], 20);
            Scan_Message2.Font = new Font(boldFont.Families[0], 20);

            lbl_loading.Font = new Font(boldFont.Families[0], 48);
            UserName.Font = new Font(mediamFont.Families[0], 20);
            UserEmail.Font = new Font(mediamFont.Families[0], 20);
            StartGame_Logged.Font = new Font(boldFont.Families[0], 20);
            StartGame_newUser.Font = new Font(boldFont.Families[0], 20);
            WelcomeMessage.Font = new Font(boldFont.Families[0], 48);
            Welcome_Back.Font = new Font(boldFont.Families[0], 20);
            Logged_User.Font = new Font(boldFont.Families[0], 20);
            Session_Message.Font = new Font(boldFont.Families[0], 20);
            Session_Message2.Font = new Font(boldFont.Families[0], 20);
           

            #endregion

            var machineModel = settingForm.getMachineModelFromJsonfile();
            comboBox_rotateTypes.Visible = false;


            foreach (RotateFlipType rotateFlipType in Enum.GetValues(typeof(RotateFlipType)))
            {
                comboBox_rotateTypes.Items.Add(rotateFlipType);
               
            }
            if(machineModel.cameraRotate != -1)
            {
                comboBox_rotateTypes.SelectedIndex = machineModel.cameraRotate;
            }
            else
            {
                comboBox_rotateTypes.SelectedIndex = 0;
            }
            listOftypes = ListofRotateTypes();
            fotateFlipe = listOftypes[comboBox_rotateTypes.SelectedIndex];


            apiUrl = machineModel.ip + "?action=";
            int left = Screen.PrimaryScreen.Bounds.Left;
            int top = Screen.PrimaryScreen.Bounds.Top;
            int width = Screen.PrimaryScreen.Bounds.Width;
            int height = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(left, top);
            if(width>1920)
            {
                width = 1920;
            }
            if(height > 2880)
            {
                height = 2880;
            }
             panel1.Width = width;
             panel1.Height = height;
            pictureBox1.Width = width;
            this.Size = new Size(width, height);

            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            panel_Scan.Width = width;
            panel_logged.Width = width;
            panel_newRegister.Width = width;
            panel_logged.Width = width;
            panel_logged.Width = width;
            panel_Scan.Height = height - pictureBox1.Height - Logo.Height - pictureBox1.Height;

            // Height 
            panel_newRegister.Height = height - pictureBox1.Height - Logo.Height;
            panel_Session.Height = height - pictureBox1.Height - Logo.Height;
            panel_logged.Height = height - pictureBox1.Height - Logo.Height;
            panel_Scan.Height = height - pictureBox1.Height - Logo.Height;
            panel_Loading.Height = height - pictureBox1.Height - Logo.Height;


            #region styling
                img_close.Left = width - img_close.Width - img_close.Width;

                WelcomeMessage.ForeColor = newColour;
                UserName.ForeColor = newColour;
                UserEmail.ForeColor = newColour;

                StartGame_newUser.ForeColor = newColour;
                Session_Message.ForeColor = newColour;
                Session_Message2.ForeColor = newColour;
                Scan_Message1.ForeColor = newColour;
                Scan_Message2.ForeColor = newColour;
                Logged_User.Text = "";
                Logged_User.ForeColor = newColour;
                Welcome_Back.Left = (this.ClientSize.Width - Welcome_Back.Width) / 2;
                //Scanning Panel
                Scan_Message1.Left = (this.ClientSize.Width - Scan_Message1.Width) / 2;
                Scan_Message2.Left = (this.ClientSize.Width - Scan_Message2.Width) / 2;
                lbl_loading.Left = (this.ClientSize.Width - lbl_loading.Width) / 2;
                lbl_loading.ForeColor = newColour;
            
                //pictureBox_Scanning.Left = (this.ClientSize.Width - pictureBox_Scanning.Width) / 2;

                Logo.Left = (this.ClientSize.Width - Logo.Width) / 2;
                Session_Message.Left = (this.ClientSize.Width - Session_Message.Width) / 2;
                Session_Message2.Left = (this.ClientSize.Width - Session_Message2.Width) / 2;

                WelcomeMessage.Left = (this.ClientSize.Width - WelcomeMessage.Width) / 2;
                UserName.Left = (this.ClientSize.Width - UserName.Width) / 2;
                UserEmail.Left = (this.ClientSize.Width - UserEmail.Width) / 2;
                lbl_loading.Left = (this.ClientSize.Width - lbl_loading.Width) / 2;
               
                imgBox_newUser.Left = (this.ClientSize.Width - imgBox_newUser.Width - StartGame_newUser.Width) / 2;
                StartGame_newUser.Left = ((this.ClientSize.Width - imgBox_newUser.Width - StartGame_newUser.Width) / 2) + imgBox_newUser.Width;

                startGame_imgbox.Left = (this.ClientSize.Width - startGame_imgbox.Width - StartGame_Logged.Width) / 2;
                StartGame_Logged.Left = ((this.ClientSize.Width - startGame_imgbox.Width - StartGame_Logged.Width) / 2) + startGame_imgbox.Width;
                   //Cancel Button and Images
                StartGame_Logged.ForeColor = newColour;

                pic_scan.Left = (this.ClientSize.Width - pic_scan.Width) / 2;
                Panel_Camera.Left = (this.ClientSize.Width - Panel_Camera.Width) / 2;

                Panel_Camera.Height = pic_scan.Height - 30;
                pictureBox_Scanning.Height = panel_Scan.Height;
                Panel_Camera.SizeChanged += Panel1_SizeChanged;

                  //pictureBox_Scanning.SizeMode = PictureBoxSizeMode.StretchImage;

            if (UserEmail.Text == "Your Email")
                {
                    UserEmail.ForeColor = Color.Gray;
                }
                else
                {
                    UserEmail.ForeColor = newColour;
                }

                if (UserName.Text == "Your Name")
                {
                    UserName.ForeColor = Color.Gray;
                }
                else
                {
                    UserName.ForeColor = newColour;

                }
                farbe = newColour;
                UserName.GotFocus += RemoveText;
                UserName.LostFocus += AddText;
                UserName.Text = phUserName;


                UserEmail.GotFocus += RemoveEmailText;
                UserEmail.LostFocus += AddEmailText;
                UserEmail.Text = phUserEmail;

            #endregion

            #region Scanning

            // Selecting Camera
            var model = settingForm.getMachineModelFromJsonfile();

            filterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo filterInfo in filterInfoCollection)
                cboDevice.Items.Add(filterInfo.Name);
            if(model.cameraDeviceIndex != -1)
            {
             cboDevice.SelectedIndex = model.cameraDeviceIndex;

            }
            else
            {
                cboDevice.SelectedIndex = 0;
            }
            cboDevice.Visible = false;
            //End Of Selecting Camera


            #endregion

                 displayLoadingPanel();

                var checkcFormdata = new Dictionary<string, string>() {

                {"machine_id",machinId},
                {"game_id",machineModel.game_id }

                };
           
                var checkingGame = await service.CheckingGame(apiUrl, "check", checkcFormdata);
                if (checkingGame.Errors == null)
                {
                    if (checkingGame.running == 1)
                    {
                        displaySessionPanel();
                        checking_Game_timer.Start();
                    }
                    else
                    {
                        Panel_Camera.Visible = true;
                        displayScanPanel();

                        startCamera();
                        checking_Game_timer.Stop();
                    }
                }
           
              
          
        }
        private void Panel1_SizeChanged(object sender, EventArgs e)
        {
            // Adjust the size of the PictureBox to match the size of the panel
            pictureBox_Scanning.Size = Panel_Camera.ClientSize;
        }
        private void Form_Load(object sender, EventArgs e)
        {
            pictureBox_Scanning.Width = Panel_Camera.Width;
            pictureBox_Scanning.Height = Panel_Camera.Height;
        }
        #region Methoud Styling
        public void RemoveText(object sender, EventArgs e)
        {
            UserName.ForeColor = farbe;
            if (UserName.Text == phUserName)
            {
                UserName.Text = "";

            }

        }

        public void RemoveEmailText(object sender, EventArgs e)
        {
            UserEmail.ForeColor = farbe;

            if (UserEmail.Text == phUserEmail)
                UserEmail.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UserName.Text))
            {
                UserName.ForeColor = Color.Gray;
                UserName.Text = phUserName;
            }

        }
        public void AddEmailText(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(UserEmail.Text))
            {
                UserEmail.ForeColor = Color.Gray;
                UserEmail.Text = phUserEmail;
            }
        }
        #endregion

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox_Scanning.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                barcodeReader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE };
                Result result = barcodeReader.Decode((Bitmap)pictureBox_Scanning.Image);
                if (result != null)
                {
                   qrCode = result.ToString();

                    if (captureDevice.IsRunning)
                    {
                        captureDevice.Stop();
                        captureDevice.SignalToStop();
                        captureDevice.WaitForStop();
                        captureDevice = null;
                    }
                    var formData = new Dictionary<string, string>
                    {
                        {"qr_code",qrCode }
                    };
                    timer1.Stop();
                    endCamera();
                    var scannedQrcode = await service.ScanQrcode(apiUrl, "scan", formData);
                    if (scannedQrcode.user == null)
                    {
                        displayNewRegisterPanel();
                        isUserLogged = false;
                    }
                    else
                    {
                        displayloggedPanel();
                        currentUser = scannedQrcode.user;
                        Logged_User.Text = currentUser.name;
                        Logged_User.Left = (this.ClientSize.Width - Logged_User.Width) / 2;
                        isUserLogged = true;

                    }
                }
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {

            Bitmap frame = (Bitmap)eventArgs.Frame.Clone();

            int newWidth = frame.Width / 2;  // Adjust the width as per your requirement
            int newHeight = frame.Height / 2;  // Adjust the height as per your requirement

            // Create a new bitmap with the zoomed out dimensions
            Bitmap zoomedOutFrame = new Bitmap(newWidth, newHeight);

            using (Graphics graphics = Graphics.FromImage(zoomedOutFrame))
            {
                // Set the interpolation mode to achieve better image quality
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

                // Draw the zoomed out frame
                graphics.DrawImage(frame, new Rectangle(0, 0, newWidth, newHeight));
            }
            

            zoomedOutFrame.RotateFlip(fotateFlipe);
            pictureBox_Scanning.Image = zoomedOutFrame;
        }

        private void endCamera()
        {

            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (captureDevice != null && captureDevice.IsRunning)
            {
                captureDevice.Stop();
            }
        }
        private void startCamera()
        {
            if(panel_Scan.Visible == true)
            {
                var model = settingForm.getMachineModelFromJsonfile();
                if (model.cameraDeviceIndex == -1)
                {
                    MessageBox.Show("Choose camera in Setting First");
                }
                else
                {
                    Panel_Camera.Visible = true;
                    captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
                    captureDevice.NewFrame += CaptureDevice_NewFrame;
                    captureDevice.Start();
                    videoCapabilities = captureDevice.VideoCapabilities;
                    captureDevice.VideoResolution = videoCapabilities[2];
                    timer1.Start();
                }
            }
           
        }

        private void pic_scan_MouseClick(object sender, MouseEventArgs e)
        {

            //var model = settingForm.getMachineModelFromJsonfile();
            //if (model.cameraDeviceIndex == -1)
            //{
            //    MessageBox.Show("Choose camera in Setting First");
            //}
            //else
            //{
            //    Panel_Camera.Visible = true;
            //    captureDevice = new VideoCaptureDevice(filterInfoCollection[cboDevice.SelectedIndex].MonikerString);
            //    captureDevice.NewFrame += CaptureDevice_NewFrame;
            //    captureDevice.Start();
            //    videoCapabilities = captureDevice.VideoCapabilities;
            //    captureDevice.VideoResolution = videoCapabilities[2];
            //    timer1.Start();
            //}

        }

        private async void StartGame_newUser_Click(object sender, EventArgs e)
        {
            displayLoadingPanel();
            if(string.IsNullOrWhiteSpace(UserName.Text) || UserName.Text =="Your Name" || string.IsNullOrWhiteSpace(UserEmail.Text) || UserEmail.Text == "Your Email")
            {
                MessageBox.Show("User Name or Email can not be Null");
                displayNewRegisterPanel();
            }
            else
            {
                string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
                if (!System.Text.RegularExpressions.Regex.IsMatch(UserEmail.Text, emailPattern))
                {
                    displayNewRegisterPanel();
                    //UserEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    MessageBox.Show("Email Not Valid");
                }
                else
                {
                    displayloggedPanel();
                    Logged_User.Text = UserName.Text;
                    Logged_User.Left = (this.ClientSize.Width - Logged_User.Width) / 2;
                    isUserLogged = false;
                }
            }
        }
        #region Display Panel

        private void displayLoadingPanel()
        {
            panel_newRegister.Visible = true;
            panel_logged.Visible = true;
            panel_Scan.Visible = true;
            panel_Session.Visible = true;
            panel_Loading.Visible = true;
            img_close.Visible = false;
        }
        private void displayScanPanel()
        {
            panel_newRegister.Visible = true;
            panel_Session.Visible = true;
            panel_logged.Visible = true;
            panel_Scan.Visible = true;
            panel_Scan.Visible = true;
            Panel_Camera.Visible = true;
            panel_Loading.Visible = false;
            img_close.Visible = false;
            Panel_Camera.SizeChanged += Panel1_SizeChanged;
            pictureBox_Scanning.Height = Panel_Camera.Height;
            pictureBox_Scanning.SizeMode = PictureBoxSizeMode.Normal;
            pictureBox_Scanning.Dock = DockStyle.Fill;
            pictureBox_Scanning.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

        }
        private void displaySessionPanel()
        {
            panel_newRegister.Visible = true;
            panel_Session.Visible = true;
            panel_logged.Visible = false;
            panel_Scan.Visible = false;
            panel_Loading.Visible = false;
            img_close.Visible = false;

        }
        private void displayNewRegisterPanel()
        {
            panel_newRegister.Visible = true;
            panel_logged.Visible = false;
            panel_Scan.Visible = false;
            panel_Session.Visible = false;
            panel_Loading.Visible = false;
            img_close.Visible = true;


        }
        private void displayloggedPanel()
        {

            panel_newRegister.Visible = true;
            panel_Session.Visible = true;
            panel_logged.Visible = true;
            panel_Scan.Visible = false;
            panel_Loading.Visible = false;
            Logged_User.Left = (this.ClientSize.Width - Logged_User.Width) / 2;
            img_close.Visible = true;
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {
            counter++;
            if(counter == 1)
            {
                Setting_Timer.Start();
            }
        }

        private async void checking_Game_timer_Tick(object sender, EventArgs e)
        {
          
                var machineModel = settingForm.getMachineModelFromJsonfile();
                var checkcFormdata = new Dictionary<string, string>() {
                    {"machine_id",machinId},
                    {"game_id",machineModel.game_id }};

                var checkingGame = await service.CheckingGame(apiUrl, "check", checkcFormdata);
                if (checkingGame.Errors == null)
                {
                    if (checkingGame.running == 1)
                    {
                        displaySessionPanel();
                    }
                    else
                    {
                        displayScanPanel();
                    checking_Game_timer.Stop();
                    startCamera();
                    }
                }
        }

        private async void StartGame_Logged_Click(object sender, EventArgs e)
        {
            displayLoadingPanel();
            if(isUserLogged == false)
            {
                var formData = new Dictionary<string, string>
                     {
                         { "name", UserName.Text },
                         { "email", UserEmail.Text },
                         { "qr_code", qrCode }
                      };
                var register = await service.Register(apiUrl, "register", formData);
                if (register.Errors == null && register.user != null)
                {
                    currentUser = register.user;
                    UserName.Text = "Your Name";
                    UserEmail.Text = "Your Email";
                }
                else
                {
                    MessageBox.Show("Error : " + register.Errors);
                    displayNewRegisterPanel();
                }
            }
            var machineModel = settingForm.getMachineModelFromJsonfile();
            var gameFormData = new Dictionary<string, string>
            {
                {"machine_id", machinId},
                {"game_id", machineModel.game_id},
                {"user_id", currentUser.id.ToString()}
            };
            var startGame = await service.StartGame(apiUrl, "start", gameFormData);
            if (startGame.status == 200)
            {

                if (startGame.running == 1)
                {
                    displaySessionPanel();
                    checking_Game_timer.Start();

                }
                else
                {
                    displayScanPanel();
                    startCamera();
                    checking_Game_timer.Stop();

                    MessageBox.Show("Game is Available Now you can Scan to Play");
                }
            }
            else
            {
                MessageBox.Show("Un Expected error" + startGame.Errors);
                displayScanPanel();
                startCamera();
            }
           
        }

        private void Setting_Timer_Tick(object sender, EventArgs e)
        {
            if (counter >= 3)
            {
                settingForm.Closed += (s, args) => this.Close();
                settingForm.Show();
                this.Hide();
                counter = 0;
                endCamera();
            }
            else
            {
                counter = 0;
            }
            Setting_Timer.Stop();
        }


        private void closing_timer_Tick(object sender, EventArgs e)
        {
            if (closingCounter >= 5)
            {
                this.Close();
                closingCounter = 0;
            }
            else
            {
                closingCounter = 0;
            }
            closing_timer.Stop();
        }

        private void lbl_closing_Click(object sender, EventArgs e)
        {
            closingCounter++;
            if (closingCounter == 1)
            {
                closing_timer.Start();
            }
        }

        private void StartGame_Logged_MouseEnter(object sender, EventArgs e)
        {
            StartGame_Logged.BackColor = newColour;
            StartGame_Logged.ForeColor = Color.White;
        }
        private void StartGame_Logged_MouseLeave(object sender, EventArgs e)
        {
            StartGame_Logged.BackColor = Color.White;
            StartGame_Logged.ForeColor = newColour;
        }
        private void StartGame_newUser_MouseEnter(object sender, EventArgs e)
        {
            StartGame_newUser.BackColor = newColour;
            StartGame_newUser.ForeColor = Color.White;
        }
        private void StartGame_newUser_MouseLeave(object sender, EventArgs e)
        {
            StartGame_newUser.BackColor = Color.White;
            StartGame_newUser.ForeColor =newColour ;
        }

        private async void network_timer_Tick(object sender, EventArgs e)
        {
           
            network_timer.Stop();
            var machineModel = settingForm.getMachineModelFromJsonfile();

            var checkcFormdata = new Dictionary<string, string>() {
                    {"machine_id",machinId},
                    {"game_id",machineModel.game_id }
              };

            var checkingGame = await service.CheckingGame(apiUrl, "check", checkcFormdata);
            if (checkingGame.Errors == null)
            {
                if (checkingGame.running == 1)
                {
                    displaySessionPanel();
                    checking_Game_timer.Start();
                }
                else
                {
                    displayScanPanel();
                    startCamera();
                    checking_Game_timer.Stop();
                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void img_close_Click(object sender, EventArgs e)
        {
            displayScanPanel();
            UserName.Text = "Your Name";
            UserEmail.Text = "Your Email";
            startCamera();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       private List<RotateFlipType> ListofRotateTypes()
        {
            List<RotateFlipType> rotateFlipTypes = new List<RotateFlipType>();
            foreach (RotateFlipType rotateFlipType in Enum.GetValues(typeof(RotateFlipType)))
            {
                rotateFlipTypes.Add(rotateFlipType);
            }
          
            return rotateFlipTypes;

        }

        //private void UserName_txt_GotFocus(object sender, EventArgs e)
        //{
        //    Process.Start("osk.exe"); // Start the on-screen keyboard process
        //}

        //private void UserEmail_txt_GotFocus(object sender, EventArgs e)
        //{
        //    Process.Start("osk.exe"); // Start the on-screen keyboard process
        //}
    }
}
