using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

using static Hermes.QuickUtils;



namespace Hermes
{
    public partial class AccessForm : Form
    {
        // Private variables initialization
        private string userCredentialsPath = Path.Combine(dirPath, Path.Combine("data", "credentials.xml"));
        private XmlSerializer xmlSerializer;
        private List<UserModel> users;

        public AccessForm()
        {
            // Initialize the form
            InitializeComponent();

            // Initialize the XmlSerializer
            xmlSerializer = new XmlSerializer(typeof(List<UserModel>));

            try
            {
               readUserCredentials();
            }
            catch
            {
                // If the file doesn't exist, create an empty list of users for starters
                users = new List<UserModel>();

                FileStream fileStream = new FileStream(userCredentialsPath, FileMode.Create, FileAccess.Write);
                UserModel newUser = new UserModel();

                // adding the details of the admin account
                newUser.username = "admin";
                newUser.password = "admin";
                newUser.name = newUser.username;
                newUser.profilePicture = "default.png";
                newUser.userType = "Admin";
                newUser.created = DateTime.Now;

                // adding the admin to the empty list of users
                users.Add(newUser);

                // updating the credentials file
                xmlSerializer.Serialize(fileStream, users);
            }

            // Prepare the form for the first time
            loginErrorLabel.Text = "";
            signupErrorLabel.Text = "";

            // Rounding the form edges
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

            // Custom customization for the components of the form
            addCustomization();

        }

        private void addCustomization()
        {
            // Custom background color
            copyrightLabel.Parent = pictureBox1;
            copyrightLabel.Location = new Point(320, 255);
            copyrightLabel.BackColor = Color.Transparent;

            // Adding custom font
            loginLabel.Font = formTitleFont;
            loginUsernameLabel.Font = heading2;
            loginPasswordLabel.Font = heading2;
            loginUsernameTextBox.Font = heading2;
            loginPasswordTextBox.Font = heading2;
            signupLabel.Font = formTitleFont;
            signupUsernameLabel.Font = heading2;
            signupPasswordLabel.Font = heading2;
            signupRepasswordLabel.Font = heading2;
            signupUsernameTextBox.Font = heading2;
            signupPasswordTextBox.Font = heading2;
            signupRepasswordTextBox.Font = heading2;
            accessButton.Font = buttonFont;
            switchAccessLabel.Font = heading2;
            copyrightLabel.Font = heading3;

            // Adding custom border
            loginUsernameTextBox.BorderStyle = BorderStyle.None;
            loginUsernameTextBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
            loginPasswordTextBox.BorderStyle = BorderStyle.None;
            loginPasswordTextBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
            signupUsernameTextBox.BorderStyle = BorderStyle.None;
            signupUsernameTextBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
            signupPasswordTextBox.BorderStyle = BorderStyle.None;
            signupPasswordTextBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
            signupRepasswordTextBox.BorderStyle = BorderStyle.None;
            signupRepasswordTextBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
            accessButton.FlatAppearance.BorderSize = 0;
            accessButton.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);

            // Altering the height
            loginUsernameTextBox.AutoSize = false;
            loginPasswordTextBox.AutoSize = false;
            signupUsernameTextBox.AutoSize = false;
            signupPasswordTextBox.AutoSize = false;
            signupRepasswordTextBox.AutoSize = false;
            accessButton.AutoSize = false;
            loginUsernameTextBox.Height = 22;
            loginPasswordTextBox.Height = 22;
            signupUsernameTextBox.Height = 22;
            signupPasswordTextBox.Height = 22;
            signupRepasswordTextBox.Height = 22;
            accessButton.Height = 40;

            // Customizing button
            GraphicsPath ellipseRadius = new GraphicsPath();
            ellipseRadius.StartFigure();
            ellipseRadius.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
            ellipseRadius.AddLine(10, 0, accessButton.Width - 10, 0);
            ellipseRadius.AddArc(new Rectangle(accessButton.Width - 10, 0, 10, 10), -90, 90);
            ellipseRadius.AddLine(accessButton.Width, 10, accessButton.Width, accessButton.Height - 10);
            ellipseRadius.AddArc(new Rectangle(accessButton.Width - 10, accessButton.Height - 10, 10, 10), 0, 90);
            ellipseRadius.AddLine(accessButton.Width - 10, accessButton.Height, 10, accessButton.Height);
            ellipseRadius.AddArc(new Rectangle(0, accessButton.Height - 10, 10, 10), 90, 90);
            ellipseRadius.CloseFigure();
            accessButton.Region = new Region(ellipseRadius);
        }

        private void readUserCredentials()
        {
            // Deserialize the users from the credentials file
            FileStream fileStream = new FileStream(userCredentialsPath, FileMode.Open, FileAccess.Read);
            users = (List<UserModel>)xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
        }

        private void resetFields()
        {
            // Resetting the text fields
            loginUsernameTextBox.Text = "";
            loginPasswordTextBox.Text = "";
            loginErrorLabel.Text = "";
            signupUsernameTextBox.Text = "";
            signupPasswordTextBox.Text = "";
            signupRepasswordTextBox.Text = "";
            signupErrorLabel.Text = "";
        }

        private void switchAccessLabel_Click(object sender, EventArgs e)
        {
            // Switching between the login and signup panels
            if (accessPageControl.SelectedIndex == 0)
            {
                // Switching to the signup panel
                accessButton.Text = "Sign up";
                switchAccessLabel.Text = "Already have account? Login here";
                accessPageControl.SelectedIndex = 1;
            }
            else
            {
                // Switching to the login panel
                accessButton.Text = "Log in";
                switchAccessLabel.Text = "Not Registered Yet? Register Here";
                accessPageControl.SelectedIndex = 0;
            }

            // Resetting the text fields
            resetFields();
        }

        private void closeButtonPicture_Click(object sender, EventArgs e)
        {
            // Closing the form
            this.Close();
        }

        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow user to login when enter key is pressed from password text field
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                accessButton_Click(sender, e);
            }
        }

        private int checkCredentials(string username, string password, bool exists)
        {
            // Checking if the credentials are correct or exists depending on the value of exists

            // for each user in list of users
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].username.Equals(username))
                {
                    // if exists is true, check if the user exists
                    if (exists)
                    {
                        return i;
                    }
                    // if exists is false, check if the password is correct
                    else if (users[i].password.Equals(password))
                    {
                        return i;
                    }
                    // if the username is correct but the password is incorrect
                    else
                    {
                        return -1;
                    }
                }
            }

            // default return value
            return -1;
        }

        private void accessButton_Click(object sender, EventArgs e)
        {
            // Checking if the login or signup panel is visible
            if (accessPageControl.SelectedIndex == 0)
            {
                // finding the user
                int userPosition = checkCredentials(loginUsernameTextBox.Text, loginPasswordTextBox.Text, false);

                // Checking if the credentials are correct
                if (userPosition != -1)
                {
                    // If the credentials are correct, open the main form
                    UserModel curUser = users[userPosition];

                    // Checking if the user can access the system at this hour
                    if (checkWorkingHour() || curUser.userType.Equals("Admin"))
                    {
                        this.Hide();
                        MainForm newMain = new MainForm(users[userPosition]);
                        newMain.ShowDialog();

                        // Unhide if the user logged out from the account, else close
                        if (newMain.logoutForm)
                        {
                            // resetting the fields
                            resetFields();
                            readUserCredentials();
                            
                            // Show the hidden form
                            this.Show();
                        }
                        else
                        {
                            closeButtonPicture_Click(sender, e);
                        }
                    }
                    else
                    {
                        // Showing the error message
                        loginErrorLabel.Text = "You are not allowed to login at this hour";
                    }

                }
                else
                {
                    // If the credentials are incorrect, show the error label
                    loginErrorLabel.Text = "Please check your credentials!";
                }
            }
            else
            {
                // finding the user
                int userPosition = checkCredentials(signupUsernameTextBox.Text, "", true);

                // Checking if the username is already taken
                if (userPosition != -1)
                {
                    signupErrorLabel.Text = "The username already exists!";
                }
                // Checking if the passwords match
                else if (!signupPasswordTextBox.Text.Equals(signupRepasswordTextBox.Text))
                {
                    signupErrorLabel.Text = "Please ensure that both password match!";
                }
                // if the credentials are correct
                else
                {
                    // initializing a new user
                    FileStream fileStream = new FileStream(userCredentialsPath, FileMode.Create, FileAccess.Write);
                    UserModel newUser = new UserModel();

                    // adding the details of the new user
                    newUser.username = signupUsernameTextBox.Text;
                    newUser.password = signupPasswordTextBox.Text;
                    newUser.name = newUser.username;
                    newUser.profilePicture = "default.png";
                    newUser.userType = "Staff";
                    newUser.created = DateTime.Now;

                    // adding the new user to the list of users
                    users.Add(newUser);
                    // updating the credentials file
                    xmlSerializer.Serialize(fileStream, users);
                    fileStream.Close();

                    // pop up a message box to show the user was created and switch to the login panel
                    MessageBox.Show("Your new accocunt has been created!");
                    switchAccessLabel_Click(sender, e);
                }
            }
        }
    }
}
