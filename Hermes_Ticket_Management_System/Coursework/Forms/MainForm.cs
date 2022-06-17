using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Serialization;

using static Hermes.Algorithm;
using static Hermes.QuickUtils;



namespace Hermes
{
    public partial class MainForm : Form
    {
        // Declare a new instance of the User class
        private UserModel curUser;
        public bool logoutForm;

        // Initialize variables to store visitor and prices data from xml file
        private List<VisitorModel> visitors;
        private List<PriceModel> prices;
        private List<UserModel> users;
        private XmlSerializer visitorXmlSerializer;
        private XmlSerializer priceXmlSerializer;
        private XmlSerializer userXmlSerializer;

        // Initialization of path variables
        private string visitorDatasetPath = Path.Combine(dirPath, Path.Combine("data", "visitors.xml"));
        private string priceDatasetPath = Path.Combine(dirPath, Path.Combine("data", "prices.xml"));
        private string userDatasetPath = Path.Combine(dirPath, Path.Combine("data", "credentials.xml"));
        private DateTime emptyDate = new DateTime(1753, 1, 1);
        private DateTime emptyTime = new DateTime(1753, 1, 1, 1, 1, 1);


        public MainForm(UserModel user)
        {
            // Initialize the form
            InitializeComponent();
            logoutForm = false;

            // Set the current user to the user passed in
            curUser = user;

            // Set the current user's name
            userNameLabel.Text = curUser.name;
            // Set the profile image for the user
            Image profilePicture = Image.FromFile(Path.Combine(userPicturesPath, curUser.profilePicture));
            profilePicture = resizeImage(profilePicture, new Size(100, 100));
            profilePicture = RoundCorners(profilePicture, 45);
            profilePictureBox.Image = profilePicture;

            editUserProfileLabel.Hide();

            // Custom customization for the components of the form
            addCustomization();

            // Initialize the XmlSerializers
            visitorXmlSerializer = new XmlSerializer(typeof(List<VisitorModel>));
            priceXmlSerializer = new XmlSerializer(typeof(List<PriceModel>));
            userXmlSerializer = new XmlSerializer(typeof(List<UserModel>));

            try
            {
                // Deserialize the visitors from the dataset file
                FileStream fileStream = new FileStream(visitorDatasetPath, FileMode.Open, FileAccess.Read);
                visitors = (List<VisitorModel>)visitorXmlSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
            catch
            {
                // If the file doesn't exist, create an empty list of visitors for starters
                visitors = new List<VisitorModel>();
            }

            try
            {
                // Deserialize the prices from the dataset file
                FileStream fileStream = new FileStream(priceDatasetPath, FileMode.Open, FileAccess.Read);
                prices = (List<PriceModel>)priceXmlSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
            catch
            {
                // If the file doesn't exist, create an empty list of prices for starters
                prices = new List<PriceModel>();
            }

            
            try
            {
                // Deserialize the users from the dataset file
                FileStream fileStream = new FileStream(userDatasetPath, FileMode.Open, FileAccess.Read);
                users = (List<UserModel>)userXmlSerializer.Deserialize(fileStream);
                fileStream.Close();
            }
            catch
            {
                // If the file doesn't exist, create an empty list of users for starters
                users = new List<UserModel>();
            }

            updateVisitorID();
            updateGroupCountComboBox();
            updateVisitIDComboBox();

            // Remove visitors that are beeing checked in
            visitors.RemoveAll(visitor => visitor.vDate == emptyDate);

            // update data grid views
            updateVisitorDataBase(false);
            updatePriceDataBase(false);
            updateUserDataBase(false);

            plotDailySales(null, null);
            plotWeeklySales(null, null);

            eUpdateButton.Hide();

            // Hide buttons that the staff doesn't have access to
            if (curUser.userType.Equals("Staff"))
            {
                pricePageButton.Hide();
                dashboardPageButton.Hide();
                employeePageButton.Hide();
            }
            else if (curUser.userType.Equals("Admin"))
            {
                dashboardPageButton_Click(null, null);
            }

        }

        private void closeButtonPicture_Click(object sender, EventArgs e)
        {
            // Close the form
            this.Close();
        }

        private void addCustomization()
        {
            // Adding custom font
            userNameLabel.Font = highlightedFont;
            editUserProfileLabel.Font = heading1;

            copyrightLabel.Font = heading3;

            dashboardPageButton.Font = titleFont;
            visitorPageButton.Font = titleFont;
            pricePageButton.Font = titleFont;
            checkoutPageButton.Font = titleFont;
            employeePageButton.Font = titleFont;

            dailyTransactionLabel.Font = titleFont;
            weeklyTransactionLabel.Font = titleFont;

            dashboardPageLabel.Font = formTitleFont;
            visitorPageLabel.Font = formTitleFont;
            pricePageLabel.Font = formTitleFont;
            checkoutPageLabel.Font = formTitleFont;
            employeePageLabel.Font = formTitleFont;

            // Adding custom sytles to field labels
            List<Label> fieldLabels = new List<Label>() { vIDLabel, vNameLabel, vAgeLabel, vPhoneNumberLabel, groupCountLabel, visitorIDLabel, vDateLabel, vArrivalTimeLabel, cDepartureTimeLabel, cPriceLabel, pGroupCountLabel, pDurationLabel, pChildLabel, pAdultLabel, pAgedLabel, pWeekdayLabel, pWeekendLabel, cIDLabel, cGroupCountLabel, cDateLabel, cArrivalTimeLabel, cDepartureTimeLabel, cPriceLabel, eUsernameLabel, eNameLabel, eJoinDateLabel, eUserTypeLabel, dailyDatePickerLabel, weeklyDatePickerLabel, cColumnComboBoxLabel, cOrderComboBoxLabel, pColumnComboBoxLabel, pOrderComboBoxLabel, wColumnComboBoxLabel, wOrderComboBoxLabel};
            foreach (var label in fieldLabels)
            {
                label.Font = heading2;
            }
            groupCounterLabel.Font = heading3;
    

            // Adding custom sytles to texboxes
            List<TextBox> textBoxes = new List<TextBox>() { vIDTextBox, vNameTextBox, vAgeTextBox, vPhoneNumberTextBox, visitorIDTextBox, cPriceTextBox, pGroupCountTextBox, pDurationTextBox, pChildWeekdayTextBox, pChildWeekendTextBox, pAdultWeekdayTextBox, pAdultWeekendTextBox, pAgedWeekdayTextBox, pAgedWeekendTextBox, cGroupCountTextBox, cPriceTextBox, cDateTextBox, cArrivalTimeTextBox, eUsernameTextBox, eNameTextBox, eJoinDateTextBox };
            foreach (var textBox in textBoxes)
            {
                textBox.BorderStyle = BorderStyle.None;
                textBox.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
                textBox.AutoSize = false;
                textBox.Height = 22;
                textBox.Font = heading2;
            }

            // customizing combo boxes
            List<ComboBox> comboBoxes = new List<ComboBox>() { groupCountComboBox, visitIDComboBox, userTypeComboBox, cColumnComboBox, cOrderComboBox, pColumnComboBox, pOrderComboBox, wColumnComboBox, wOrderComboBox };
            foreach (var comboBox in comboBoxes)
            {
                comboBox.Font = heading2;
                // remove border color from combo boxes
            }

            // customizing datetime picker
            List<DateTimePicker> dateTimePickers = new List<DateTimePicker>() { vArrivalTimePicker, cDepartureTimePicker, vDatePicker, cDepartureTimePicker, dailySalesDatePicker, weeklySalesDatePicker };
            foreach (var dateTimePicker in dateTimePickers)
            {
                dateTimePicker.Controls.Add(new Label() { Height = 1, Dock = DockStyle.Bottom, BackColor = Color.White });
                dateTimePicker.AutoSize = false;
                dateTimePicker.Height = 22;
                dateTimePicker.Font = heading2;
            }

            // customizing the buttons
            List<Button> buttons = new List<Button>() { vAddButton, vEditButton, vDeleteButton, vSaveButton, pSaveButton, pEditButton, pDeleteButton, cSaveButton, calculatePriceButton, checkoutTableTypeButton, eEditButton, eUpdateButton, cSortButton, pSortButton, wSortButton, vExportButton, cExportButton, pExportButton};
            foreach (var button in buttons)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
                button.Font = heading2;

                // customizing button edges
                button.Region = new Region(edgifyBorder(button.Width, button.Height));
            }

            // customising the datagridview
            List<DataGridView> dataGrids = new List<DataGridView>() { visitorDataGridView, priceDataGridView, checkoutDataGridView, employeeDataGridView, dailyTransactionGridView, weeklyTransactionGridView };
            foreach (var dataGrid in dataGrids)
            {
                dataGrid.BorderStyle = BorderStyle.None;
                dataGrid.EnableHeadersVisualStyles = false;
                dataGrid.Region = new Region(edgifyBorder(dataGrid.Width, dataGrid.Height));

                dataGrid.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 40, 40, 40);
                dataGrid.RowHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGrid.RowHeadersDefaultCellStyle.Font = heading2;
                dataGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                dataGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(255, 40, 40, 40);
                dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGrid.ColumnHeadersDefaultCellStyle.Font = heading2Intro;
                dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

                dataGrid.DefaultCellStyle.BackColor = Color.FromArgb(255, 52, 50, 50);
                dataGrid.DefaultCellStyle.ForeColor = Color.White;
                dataGrid.DefaultCellStyle.Font = heading2;
                dataGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dataGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 80, 161, 217);
                dataGrid.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 80, 161, 217);

                dataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
                dataGrid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGrid.RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            }

            // Rounding the panel edges
            List<Panel> panels = new List<Panel>() { visitorFormPanel, visitorSeparatorPanel, dashboardSeparatorPanel, priceSeparatorPanel, priceFormPanel, checkoutSeparatorPanel, checkoutFormPanel, employeeSeparatorPanel, employeeFormPanel, cSortPanel, pSortPanel, wSortPanel};
            foreach (var panel in panels)
            {
                panel.Region = new Region(edgifyBorder(panel.Width, panel.Height));
            }

            // Customizing the charts
            List<Chart> charts = new List<Chart>() {dailyAgeGroupChart, weeklyTransactionsChart, weeklyEarningChart};
            foreach(var chart in charts){
                chart.ForeColor = Color.White;
                chart.ChartAreas[0].BackColor = Color.FromArgb(255, 40, 40, 40);
                chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
                chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;
                chart.ChartAreas[0].AxisX.LineColor = Color.White;
                chart.ChartAreas[0].AxisY.LineColor = Color.White;
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(255, 60, 60, 60);
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(255, 60, 60, 60);
                chart.ChartAreas[0].AxisX.LabelStyle.Font = heading2;
                chart.ChartAreas[0].AxisY.LabelStyle.Font = heading2;
                chart.ChartAreas[0].AxisX.TitleFont = heading2Intro;
                chart.ChartAreas[0].AxisY.TitleFont = heading2Intro;
                chart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
                chart.ChartAreas[0].AxisY.TitleForeColor = Color.White;
                chart.Region = new Region(edgifyBorder(chart.Width, chart.Height));

                // change the legend color
                chart.Legends[0].ForeColor = Color.White;
                chart.Legends[0].Font = heading2;
                chart.Legends[0].BackColor = Color.FromArgb(255, 40, 40, 40);
            }

        }



        /* -------------------------------------------------------- Navigation / User Flow -------------------------------------------------------- */

        private void editUserProfileLabel_Click(object sender, EventArgs e)
        {

        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            // Close form as logout form the system
            this.logoutForm = true;
            this.Close();
        }

        private void visitorPageButton_Click(object sender, EventArgs e)
        {
            if (checkWorkingHour())
            {
                updateGroupCountComboBox();
                clearVisitorFields();
                updateVisitorID();
                updateVisitorDataBase(false);
                groupCountComboBox.SelectedIndex = -1;
                allPageTabs.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("You are not allowed to add visitors at this hour");
            }
        }

        private void checkoutPageButton_Click(object sender, EventArgs e)
        {
            if (checkWorkingHour())
            {
                updateVisitIDComboBox();
                clearCheckoutFields();
                updateVisitorDataBase(false);
                allPageTabs.SelectedIndex = 1;
            }
            else
            {
                MessageBox.Show("You are not allowed to checkout at this hour");
            }
        }

        private void pricePageButton_Click(object sender, EventArgs e)
        {
            clearPriceFields();
            updatePriceDataBase(false);
            allPageTabs.SelectedIndex = 2;
        }

        private void dashboardPageButton_Click(object sender, EventArgs e)
        {
            allPageTabs.SelectedIndex = 3;
            plotDailySales(null, null);
            plotWeeklySales(null, null);
        }

        private void employeePageButton_Click(object sender, EventArgs e)
        {
            updateUserDataBase(false);
            allPageTabs.SelectedIndex = 4;            
        }



        /* -------------------------------------------------------- Price Page -------------------------------------------------------- */

        private bool validatePriceFields()
        {

            // Check if the price fields are empty
            if (pGroupCountTextBox.Text == "" || pDurationTextBox.Text == "" || pChildWeekendTextBox.Text == "" || pChildWeekdayTextBox.Text == "" || pAdultWeekendTextBox.Text == "" || pAdultWeekdayTextBox.Text == "" || pAgedWeekdayTextBox.Text == "" || pAgedWeekendTextBox.Text == "")
            {
                MessageBox.Show("Please fill in all the fields");
                return false;
            }

            try
            {
                // Check if the group count is less than 0
                if (int.Parse(pGroupCountTextBox.Text) < 1)
                {
                    MessageBox.Show("Group count needs to be greater than 0");
                    return false;
                }

                // Check if the duration is between 1 and 8 hours
                if (int.Parse(pDurationTextBox.Text) < 1 || int.Parse(pDurationTextBox.Text) > 8)
                {
                    MessageBox.Show("Duration must be between 1 and 8 hours");
                    return false;
                }

                // check if the prices are less than 0
                List<String> prices = new List<String>() { pChildWeekendTextBox.Text, pChildWeekdayTextBox.Text, pAdultWeekendTextBox.Text, pAdultWeekdayTextBox.Text, pAgedWeekdayTextBox.Text, pAgedWeekendTextBox.Text };
                foreach (var price in prices)
                {
                    if (float.Parse(price) < 0)
                    {
                        MessageBox.Show("Prices cannot be negative");
                        return false;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter numbers only");
                return false;
            }

            return true;

        }

        private void clearPriceFields()
        {
            // Reset all the price fields to empty
            pGroupCountTextBox.Text = "";
            pDurationTextBox.Text = "";
            pChildWeekdayTextBox.Text = "";
            pAdultWeekdayTextBox.Text = "";
            pAgedWeekdayTextBox.Text = "";
            pChildWeekendTextBox.Text = "";
            pAdultWeekendTextBox.Text = "";
            pAgedWeekendTextBox.Text = "";

            pSaveButton.Text = "Save";
            pEditButton.Text = "Edit";

            // enable text boxes that can be edited
            pGroupCountTextBox.ReadOnly = false;
            pDurationTextBox.ReadOnly = false;

        }

        private void updatePriceDataBase(bool updateDatabse)
        {

            if (updateDatabse)
            {
                // Initialize the filestream
                FileStream fileStream = new FileStream(priceDatasetPath, FileMode.Create, FileAccess.Write);

                // updating the price dataset file
                priceXmlSerializer.Serialize(fileStream, prices);
                fileStream.Close();
            }
            
            // load data in price datagrid
            BindingSource pbs = new BindingSource();
            pbs.DataSource = prices.ToList();
            priceDataGridView.DataSource = pbs;
            changeHeaderText(priceDataGridView, new List<string>(){ "Group Count", "Duration (Hours)", "Child Weekend Price", "Adult Weekend Price", "Aged Weekend Price", "Child Weekday Price", "Adult Weekday Price", "Aged Weekday Price" });
            
            // add the columns in the column combo box
            pColumnComboBox.Items.Clear(); 
            
            for (int i = 0; i < priceDataGridView.Columns.Count; i++)
            {
                pColumnComboBox.Items.Add(priceDataGridView.Columns[i].HeaderText);
            }
            pColumnComboBox.SelectedIndex = 0;
            pOrderComboBox.SelectedIndex = 0;

        }

        private void pSaveButton_Click(object sender, EventArgs e)
        {
            // Check if the price fields are valid
            if (validatePriceFields())
            {
                // Initialize the new price
                PriceModel curPrice = new PriceModel();

                // adding the details of the new price
                curPrice.groupCount = uint.Parse(pGroupCountTextBox.Text);
                curPrice.duration = uint.Parse(pDurationTextBox.Text);
                curPrice.childWeekendPrice = float.Parse(pChildWeekendTextBox.Text);
                curPrice.adultWeekendPrice = float.Parse(pAdultWeekendTextBox.Text);
                curPrice.agedWeekendPrice = float.Parse(pAdultWeekdayTextBox.Text);
                curPrice.childWeekdayPrice = float.Parse(pChildWeekdayTextBox.Text);
                curPrice.adultWeekdayPrice = float.Parse(pAdultWeekdayTextBox.Text);
                curPrice.agedWeekdayPrice = float.Parse(pAdultWeekdayTextBox.Text);

                if (pSaveButton.Text.Equals("Save"))
                {
                    // Check if the price already exists
                    if (prices.Where(x => x.groupCount == curPrice.groupCount && x.duration == curPrice.duration).Count() != 0)
                    {
                        MessageBox.Show("Prices for the group (" + pGroupCountTextBox.Text + ") and duration (" + pDurationTextBox.Text + ") already exists");
                        return;
                    }

                    // adding the new price to the list of prices
                    prices.Add(curPrice);

                    // pop up a message box to show the price was added
                    MessageBox.Show("Your new price has been added!");
                }
                else
                {
                    // Find the index of the price to be updated
                    int index = prices.FindIndex(x => x.groupCount == curPrice.groupCount & x.duration == curPrice.duration);

                    // Update the price in the dataset
                    prices[index] = curPrice;

                    // change the save button to update
                    pSaveButton.Text = "Save";
                    pEditButton.Text = "Edit";

                    // pop up a message box to show the price was updated
                    MessageBox.Show("Your  price has been updated!");

                    // Enable disabled text boxes
                    pGroupCountTextBox.ReadOnly = false;
                    pDurationTextBox.ReadOnly = false;
                }

                // clear the price fields
                clearPriceFields();
                updatePriceDataBase(true);
            }
        }

        private void pEditButton_Click(object sender, EventArgs e)
        {
            // check if user has selected a price
            if (priceDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a price to edit");
                return;
            }

            if (pEditButton.Text.Equals("Edit"))
            {
                // get the selected row from the datagrid
                DataGridViewRow selectedRow = priceDataGridView.SelectedRows[0];

                // get the price id
                pGroupCountTextBox.Text = selectedRow.Cells[0].Value.ToString();
                pDurationTextBox.Text = selectedRow.Cells[1].Value.ToString();
                pChildWeekendTextBox.Text = selectedRow.Cells[2].Value.ToString();
                pAdultWeekendTextBox.Text = selectedRow.Cells[3].Value.ToString();
                pAgedWeekendTextBox.Text = selectedRow.Cells[4].Value.ToString();
                pChildWeekdayTextBox.Text = selectedRow.Cells[5].Value.ToString();
                pAdultWeekdayTextBox.Text = selectedRow.Cells[6].Value.ToString();
                pAgedWeekdayTextBox.Text = selectedRow.Cells[7].Value.ToString();

                // change the save button to update
                pSaveButton.Text = "Update";

                // disable text boxes that can't be edited
                pGroupCountTextBox.ReadOnly = true;
                pDurationTextBox.ReadOnly = true;

                pEditButton.Text = "Cancel";
            }
            else
            {
                // clear the price fields
                clearPriceFields();
            }

        }

        private void pDeleteButton_Click(object sender, EventArgs e)
        {
            // check if user has selected a price
            if (priceDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a price to delete");
                return;
            }

            // get the selected row from the datagrid
            DataGridViewRow selectedRow = priceDataGridView.SelectedRows[0];

            // add a message box to confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this price?", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (result.Equals(DialogResult.Yes))
            {
                // remove the price from the dataset
                prices.RemoveAll(price => price.groupCount == int.Parse(selectedRow.Cells[0].Value.ToString()) & price.duration == uint.Parse(selectedRow.Cells[1].Value.ToString()));

                // load data in datagrid
                clearPriceFields();
                updatePriceDataBase(true);
            }
        }

        private void pSortButton_Click(object sender, EventArgs e)
        {
            if (pColumnComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a column to sort.");
                return;
            }

            if(pOrderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sort order.");
                return;
            }

            // get the column name and order type
            string columnName = priceDataGridView.Columns[pColumnComboBox.SelectedIndex].Name;
            bool ascending = pOrderComboBox.SelectedIndex == 0;

            // create a list of the data
            List<object> data = new List<object>();
            BindingSource ppbs = (BindingSource)priceDataGridView.DataSource;

            foreach (var item in ppbs)
            {
                data.Add(item);
            }

            // sort the list
            List<object> sorted = MergeSort(data, columnName, ascending);

            // clear the bindingsource
            ppbs.Clear();

            // add the sorted data back to the bindingsource
            ppbs.DataSource = sorted;

            priceDataGridView.DataSource = ppbs;
            
        }

        private void pExportButton_Click(object sender, EventArgs e)
        {
            exportDataGrid(priceDataGridView);
        }


        /* -------------------------------------------------------- Visitor Page -------------------------------------------------------- */

        private void updateGroupCountComboBox()
        {
            // clear the group combobox
            groupCountComboBox.Items.Clear();

            // add all the unique groups from price model
            foreach (var groupCount in prices.Select(x => x.groupCount).Distinct())
            {
                groupCountComboBox.Items.Add(groupCount);
            }
        }

        private void updateGroupCounter(object sender, EventArgs e)
        {
            // get the value from groupCountComboBox
            int groupCount = 0;

            if (groupCountComboBox.SelectedItem != null)
            {
                groupCount = int.Parse(groupCountComboBox.SelectedItem.ToString());
            }

            // get the number of rows in the datagrid
            int rowCount = visitorDataGridView.Rows.Count;

            // exception handling
            if (rowCount > groupCount)
            {
                MessageBox.Show("Group count can't be lowered while there are " + rowCount + " visitors in the datagrid. Please delete some visitors before proceeding.");
            }
            else
            {
                if (rowCount == groupCount)
                {
                    groupCounterLabel.Text = "-- Full --";
                }
                else
                {
                    // update the groupCounter
                    groupCounterLabel.Text = "( " + (rowCount + 1) + " of " + groupCount + " )";
                }
            }

        }

        private void updateVisitorDataBase(bool updateDatabse)
        {

            if (updateDatabse)
            {
                // Initialize the new visitor
                FileStream fileStream = new FileStream(visitorDatasetPath, FileMode.Create, FileAccess.Write);

                // updating the visitor dataset file
                visitorXmlSerializer.Serialize(fileStream, visitors);
                fileStream.Close();
            }

            updateVisitorID();

            // load data in datagrid
            var visitorList = visitors.Where(v => v.visitID == ulong.Parse(vIDTextBox.Text));
            BindingSource vbs = new BindingSource();
            vbs.DataSource = visitorList.Select(x => new { x.visitID, x.visitorID, x.visitorName, x.age, x.ageGroup, x.phonenumber }).ToList();
            visitorDataGridView.DataSource = vbs;
            changeHeaderText(visitorDataGridView, new List<string> { "Visit ID", "Visitor ID", "Visitor Name", "Age", "Age Group", "Phone Number" });

            var visitorList2 = visitors.Where(v => v.vDate != emptyDate);
            BindingSource cbs = new BindingSource();
            List<string> columnNames;
            if (checkoutTableTypeButton.Text == "Checked out visitors")
            {
                visitorList2 = visitorList2.Where(v => v.departureTime == emptyTime);
                cbs.DataSource = visitorList2.Select(x => new { x.visitID, x.visitorID, x.visitorName, x.age, x.ageGroup, x.phonenumber, x.vDate, x.arrivalTime, x.groupCount }).ToList();
                columnNames=  new List<string> { "Visit ID", "Visitor ID", "Visitor Name", "Age", "Age Group", "Phone Number", "Entry Date", "Arrival Time", "Group Count" };
            }
            else
            {
                visitorList2 = visitorList2.Where(v => v.departureTime != emptyTime);
                cbs.DataSource = visitorList2.Select(x => new { x.visitID, x.visitorID, x.visitorName, x.age, x.ageGroup, x.phonenumber, x.vDate, x.arrivalTime, x.departureTime, x.price, x.groupCount }).ToList();
                columnNames = new List<string> { "Visit ID", "Visitor ID", "Visitor Name", "Age", "Age Group", "Phone Number", "Entry Date", "Arrival Time", "Departure Time", "Visit Cost", "Group Count" };
            }

            checkoutDataGridView.DataSource = cbs;
            changeHeaderText(checkoutDataGridView, columnNames);

            // add the columns in the column combo box
            cColumnComboBox.Items.Clear();
            for (int i = 0; i < checkoutDataGridView.Columns.Count; i++)
            {
                cColumnComboBox.Items.Add(checkoutDataGridView.Columns[i].HeaderText);
            }
            cColumnComboBox.SelectedIndex = 0;
            cOrderComboBox.SelectedIndex = 0;

            updateGroupCounter(null, null);
        }

        private void updateVisitorID()
        {
            // Funtion to set the default value for visitor ID from visitor dataset

            ulong maxID = 0;
            ulong maxVisitID = 0;

            try
            {
                // find the highest visitor ID in the dataset
                maxID = visitors.Select(x => x.visitorID).Max();
                maxVisitID = visitors.Where(x => x.vDate != emptyDate).Select(x => x.visitID).Max();
            }
            catch
            {
                // if there is no visitor in the dataset
            }

            // set the default value for visit ID
            vIDTextBox.Text = (maxVisitID + 1).ToString();

            // set the default value for visitor ID
            visitorIDTextBox.Text = (maxID + 1).ToString();

        }

        private bool validateVisitorFields()
        {
            // Check if value for combo box is selected
            if (groupCountComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a group count first.");
                return false;
            }

            // Check if the number of visitors is more than the group count
            if (visitorDataGridView.Rows.Count >= int.Parse(groupCountComboBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Number of visitors can't be more than the group count.");
                return false;
            }

            // Check if the fileds are emtpy
            if (vNameTextBox.Text == "" || vAgeTextBox.Text == "" || vPhoneNumberTextBox.Text == "" || vDatePicker.Value == null || vArrivalTimePicker.Value == null)
            {
                MessageBox.Show("Please fill in all the fields");
                return false;
            }

            try
            {
                // Check if age is above 1 years old
                if (int.Parse(vAgeTextBox.Text) < 1)
                {
                    MessageBox.Show("Age must be above 1 years old");
                    return false;
                }
            }
            catch
            {
                MessageBox.Show("Please enter numbers for Age");
                return false;
            }

            // check if the phone number is valid
            if (!vPhoneNumberTextBox.Text.All(char.IsDigit))
            {
                MessageBox.Show("Please enter a valid phone number");
                return false;
            }

            return true;
        }

        private void clearVisitorFields()
        {
            // Reset all the visitor fields to empty
            vIDTextBox.Text = "";
            vNameTextBox.Text = "";
            vAgeTextBox.Text = "";
            vPhoneNumberTextBox.Text = "";
            vDatePicker.Value = DateTime.Now;
            vArrivalTimePicker.Value = DateTime.Now;

            // change the button labels
            vAddButton.Text = "Add";
            vEditButton.Text = "Edit";
        }

        private void vSaveButton_Click(object sender, EventArgs e)
        {
            // check if the groupcount is selected
            if (groupCountComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a group count first before saving.");
                return;
            }
                
            // check if enough visitor fields are filled
            if (visitorDataGridView.Rows.Count != int.Parse(groupCountComboBox.SelectedItem.ToString()))
            {
                MessageBox.Show("Please fill the details of all " + groupCountComboBox.SelectedItem.ToString() + " visitors as some are missing nbefpre saving. Add the visitors by clicking on the add button.");
                return;
            }
        

            // add date and time to all the visitors in the list
            foreach (var v in visitors.Where(x => x.visitID == ulong.Parse(vIDTextBox.Text)))
            {
                v.vDate = vDatePicker.Value;
                v.vDate = new DateTime(v.vDate.Year, v.vDate.Month, v.vDate.Day);
                v.arrivalTime = vArrivalTimePicker.Value;
                v.arrivalTime = new DateTime(emptyDate.Year, emptyDate.Month, emptyDate.Day, v.arrivalTime.Hour, v.arrivalTime.Minute, v.arrivalTime.Second);
                v.groupCount = uint.Parse(groupCountComboBox.SelectedItem.ToString());
            }

            MessageBox.Show("Visitors saved successfully");
            clearVisitorFields();
            updateVisitorDataBase(true);
        }

        private void vAddButton_Click(object sender, EventArgs e)
        {
            // Check if the visitor fields are valid
            if (validateVisitorFields())
            {
                // Initialize the new visitor
                VisitorModel curVisitor = new VisitorModel();

                // adding the details of the new price
                curVisitor.visitID = ulong.Parse(vIDTextBox.Text);
                curVisitor.visitorID = ulong.Parse(visitorIDTextBox.Text);
                curVisitor.visitorName = vNameTextBox.Text;
                curVisitor.age = uint.Parse(vAgeTextBox.Text);
                curVisitor.ageGroup = findAgeGroupLabel(curVisitor.age);
                curVisitor.phonenumber = vPhoneNumberTextBox.Text;
                curVisitor.vDate = emptyDate;                   // addding an invalid date to make sure the datetime is not null
                curVisitor.arrivalTime = emptyTime;             // addding an invalid time to make sure the datetime is not null
                curVisitor.departureTime = emptyTime;           // addding an invalid time to make sure the datetime is not null
                curVisitor.price = -1;
                curVisitor.groupCount = 0;

                if (vAddButton.Text.Equals("Add"))
                {
                    // adding the new visitor to the list of visitors
                    visitors.Add(curVisitor);

                    // pop up a message box to show the visitor was added, and clear the price fields
                    MessageBox.Show("The visitor details have been added!");
                }
                else
                {
                    // Find the index of the visitor to be updated
                    int index = visitors.FindIndex(x => x.visitID == curVisitor.visitID);

                    // Update the visitor in the dataset
                    visitors[index] = curVisitor;

                    // change the button labels
                    vAddButton.Text = "Add";
                    vEditButton.Text = "Edit";

                    // pop up a message box to show the visitor was updated
                    MessageBox.Show("The visitor's data has been updated!");
                }

                // reset visitor fields
                clearVisitorFields();
                updateVisitorID();
                updateVisitorDataBase(true);
            }

        }

        private void vEditButton_Click(object sender, EventArgs e)
        {
            // check if user has selected a visitor
            if (visitorDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a visitor to edit");
                return;
            }

            if (vEditButton.Text.Equals("Edit"))
            {
                // get the selected row from the datagrid
                DataGridViewRow selectedRow = visitorDataGridView.SelectedRows[0];

                // get the price id
                vIDTextBox.Text = selectedRow.Cells[0].Value.ToString();
                visitorIDTextBox.Text = selectedRow.Cells[1].Value.ToString();
                vNameTextBox.Text = selectedRow.Cells[2].Value.ToString();
                vAgeTextBox.Text = selectedRow.Cells[3].Value.ToString();
                vPhoneNumberTextBox.Text = selectedRow.Cells[5].Value.ToString();

                // change the save button to update
                vAddButton.Text = "Update";
                vEditButton.Text = "Cancel";
            }
            else
            {
                // clear the visitor fields
                clearVisitorFields();
                updateVisitorID();

            }
        }

        private void vDeleteButton_Click(object sender, EventArgs e)
        {
            // check if user has selected a visitor
            if (visitorDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a visitor to delete");
                return;
            }

            // get the selected row from the datagrid
            DataGridViewRow selectedRow = visitorDataGridView.SelectedRows[0];

            // add a message box to confirm the deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete visitor (" + selectedRow.Cells[2] + ") ?", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (result.Equals(DialogResult.Yes))
            {
                // remove the price from the dataset
                visitors.RemoveAll(visitor => visitor.visitorID == uint.Parse(selectedRow.Cells[1].Value.ToString()));

                // load data in datagrid
                clearVisitorFields();
                updateVisitorDataBase(true);
            }
        }

        private void vExportButton_Click(object sender, EventArgs e)
        {
            exportDataGrid(visitorDataGridView);
        }


        /* -------------------------------------------------------- Checkout Page -------------------------------------------------------- */

        private void updateVisitIDComboBox()
        {
            // clear the combo box
            visitIDComboBox.Items.Clear();

            // create a list of non checked out visitors
            var visitorList = visitors.Where(x => x.departureTime == emptyTime);

            // add all the visitor ids to the combo box
            foreach (var v in visitorList.Select(x => x.visitID).Distinct())
            {
                visitIDComboBox.Items.Add(v);
            }
        }

        private void clearCheckoutFields()
        {
            // clear the checkout fields
            visitIDComboBox.SelectedIndex = -1;
            cGroupCountTextBox.Text = "";
            cDateTextBox.Text = "";
            cArrivalTimeTextBox.Text = "";
            cDepartureTimePicker.Value = DateTime.Now;
            cPriceTextBox.Text = "";
        }

        private void checkoutTableTypeButton_Click(object sender, EventArgs e)
        {
            if (checkoutTableTypeButton.Text == "Checked out visitors")
            {
                checkoutTableTypeButton.Text = "Checking in visitors";
            }
            else
            {
                checkoutTableTypeButton.Text = "Checked out visitors";
            }

            updateVisitorDataBase(false);
        }

        private void fillCheckoutFields(object sender, EventArgs e)
        {
            if (visitIDComboBox.SelectedIndex == -1)
            {
                return;
            }

            // get all visitors for the selected visit id
            var visitorList = visitors.Where(x => x.visitID == ulong.Parse(visitIDComboBox.SelectedItem.ToString()));

            // fill the checkout fields
            cGroupCountTextBox.Text = visitorList.First().groupCount.ToString();
            cDateTextBox.Text = visitorList.First().vDate.ToString("dddd, dd MMMM yyyy");
            cArrivalTimeTextBox.Text = visitorList.First().arrivalTime.ToString("hh:mm tt");
            cDepartureTimePicker.Value = DateTime.Now;
            cPriceTextBox.Text = "-- Press Calculate Button --";
        }

        private void calculatePriceButton_Click(object sender, EventArgs e)
        {
            if (visitIDComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a visit ID before proceeding!");
                return;
            }

            // get all visitors for the selected visit id
            var visitorList = visitors.Where(x => x.visitID == ulong.Parse(visitIDComboBox.SelectedItem.ToString()));
            DateTime checkinTime = visitorList.First().arrivalTime;
            DateTime checkoutTime = cDepartureTimePicker.Value;
            bool weekend = isWeekend(visitorList.First().vDate);
            uint groupCount = visitorList.First().groupCount;

            // Assure if the checkout time is after the arrival time
            if (checkoutTime <= checkinTime)
            {
                MessageBox.Show("Checkout time cannot be before checkin time!");
                return;
            }

            // Find the hours from the two times
            int hours = (checkoutTime - checkinTime).Hours;
            int minutes = (checkoutTime - checkinTime).Minutes;

            // Add an additional hour if the minutes are greater than 0
            if (minutes > 0) hours++;

            // find the price list
            var curPrice = prices.Where(x => x.groupCount == groupCount & x.duration == hours);

            // check if the price exists
            if (curPrice.Count() == 0)
            {
                MessageBox.Show("There is no price for the selected group (" + groupCount.ToString() + ") count and duration (" + hours.ToString() + ") hours. Please contact the administrator.");
                return;
            }

            // Add price for each visitor
            foreach (var v in visitorList)
            {
                v.price = findPrice(v.ageGroup, weekend, hours, curPrice.First());
            }

            // update the price text box
            cPriceTextBox.Text = visitorList.Sum(x => x.price).ToString();
        }

        private void cSaveButton_Click(object sender, EventArgs e)
        {
            if (cPriceTextBox.Equals("-- Press Calculate Button --"))
            {
                MessageBox.Show("Please calculate the price before saving!");
                return;
            }

            float pre_price = float.Parse(cPriceTextBox.Text);
            cPriceTextBox.Text = "-- Press Calculate Button --";
            calculatePriceButton_Click(sender, e);


            if (!cPriceTextBox.Text.Equals("-- Press Calculate Button --"))
            {
                if (pre_price == float.Parse(cPriceTextBox.Text))
                {
                    DateTime departTime = cDepartureTimePicker.Value;
                    // get all visitors for the selected visit id
                    var visitorList = visitors.Where(x => x.visitID == ulong.Parse(visitIDComboBox.SelectedItem.ToString()));

                    // update the departure time
                    foreach (var v in visitorList)
                    {
                        v.departureTime = departTime;
                        v.departureTime = new DateTime(emptyDate.Year, emptyDate.Month, emptyDate.Day, v.departureTime.Hour, v.departureTime.Minute, v.departureTime.Second);
                    }

                    updateVisitorDataBase(true);
                    clearCheckoutFields();

                }
                else if (!cPriceTextBox.Text.Equals("-- Press Calculate Button --"))
                {
                    MessageBox.Show("The price has been changed. Please press Save again to proceed.");
                }
            }
        }

        private void cSortButton_Click(object sender, EventArgs e)
        {
            if (cColumnComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a column to sort.");
                return;
            }

            if(cOrderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sort order.");
                return;
            }

            // get the column name and order type
            string columnName = checkoutDataGridView.Columns[cColumnComboBox.SelectedIndex].Name;
            bool ascending = cOrderComboBox.SelectedIndex == 0;

            // create a list of the data
            List<object> data = new List<object>();
            BindingSource bs = (BindingSource)checkoutDataGridView.DataSource;

            foreach (var item in bs)
            {
                data.Add(item);
            }

            // sort the list
            List<object> sorted = MergeSort(data, columnName, ascending);

            // clear the bindingsource
            bs.Clear();

            // add the sorted data back to the bindingsource
            bs.DataSource = sorted;

            checkoutDataGridView.DataSource = bs;
            
        }

        private void cExportButton_Click(object sender, EventArgs e)
        {
            exportDataGrid(checkoutDataGridView);
        }


        /* -------------------------------------------------------- Dashboard Page -------------------------------------------------------- */

        private void plotDailySales(object sender, EventArgs e)
        {
            // Get the date from the date picker
            var chosenDate = dailySalesDatePicker.Value;

            // filter by the chosen date
            var filteredVisitors = visitors.Where(v => v.vDate.Date == chosenDate.Date & v.departureTime != emptyTime).ToList();

            // group age groups and get the total group of visitors
            var ageGroupDictionary = filteredVisitors.GroupBy(v => new{ v.ageGroup, v.groupCount } ).Select(v => new { v.Key.ageGroup, v.Key.groupCount, totalVisitors = v.Count()});

            // load data in datagrid
            BindingSource dtbs = new BindingSource();
            dtbs.DataSource = ageGroupDictionary.ToList();
            dailyTransactionGridView.DataSource = dtbs;
            changeHeaderText(dailyTransactionGridView, new List<string>(){"Age Group", "Group Count", "Total Visitors"});

            dailyAgeGroupChart.Series.Clear();
            int counter = 0;

            foreach(string ageLabel in ageGroupDictionary.Select(x => x.ageGroup).Distinct())
            {
                dailyAgeGroupChart.Series.Add(ageLabel);
                var ageGroup = ageGroupDictionary.Where(x => x.ageGroup == ageLabel);
                foreach(uint groupCount in ageGroup.Select(x => x.groupCount).Distinct().OrderBy(x => x))
                {
                    dailyAgeGroupChart.Series[counter].Points.AddXY(groupCount, ageGroup.Where(x => x.groupCount == groupCount).Sum(x => x.totalVisitors));
                    dailyAgeGroupChart.Series[counter].ChartType = SeriesChartType.Column;
                    dailyAgeGroupChart.Series[counter].IsValueShownAsLabel = true;
                    dailyAgeGroupChart.Series[counter].LabelFormat = "{0} visitor/s";
                    dailyAgeGroupChart.Series[counter].LabelForeColor = Color.Gray;
                }
                counter++;
            }
            dailyAgeGroupChart.ChartAreas[0].AxisX.Title = "Group Count";
            dailyAgeGroupChart.ChartAreas[0].AxisY.Title = "Total Visitors";
            
        }

        private void plotWeeklySales(object sender, EventArgs e)
        {
            // Get the chosen date from the date picker
            var chosenDate = weeklySalesDatePicker.Value;

            // find the week number of the chosen date
            var weekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(chosenDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday);

            // filter by the week number
            var filteredVisitors = visitors.Where(v => CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(v.vDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday) == weekNumber & v.departureTime != emptyTime);

            // group days and get the total group of visitors
            var dayDictionary = filteredVisitors.GroupBy(v => v.vDate.DayOfWeek.ToString()).Select(v => new { day = v.Key, totalVisitors = v.Count(), totalEarning = v.Sum(y => y.price) });

            // load data in datagrid
            BindingSource wtbs = new BindingSource();
            wtbs.DataSource = dayDictionary.ToList();
            weeklyTransactionGridView.DataSource = wtbs;
            changeHeaderText(weeklyTransactionGridView, new List<string>() { "Day", "Total Visitors", "Total Earning" });

            // plot the transactions chart
            weeklyTransactionsChart.Series.Clear();
            weeklyTransactionsChart.Series.Add("Total Visitors");
            weeklyTransactionsChart.DataSource = dayDictionary.ToList();
            weeklyTransactionsChart.Series[0].XValueMember = "day";
            weeklyTransactionsChart.Series[0].YValueMembers = "totalVisitors";
            weeklyTransactionsChart.Series[0].ChartType = SeriesChartType.Column;
            weeklyTransactionsChart.Series[0].IsValueShownAsLabel = true;
            weeklyTransactionsChart.Series[0].LabelFormat = "{0} visitor/s";
            weeklyTransactionsChart.Series[0].IsVisibleInLegend = false;
            weeklyTransactionsChart.ChartAreas[0].AxisX.Title = "Day of the Week";
            weeklyTransactionsChart.ChartAreas[0].AxisY.Title = "Total Visitors";
            weeklyTransactionsChart.Series[0].LabelForeColor = Color.Gray;

            // plot the earning chart
            weeklyEarningChart.Series.Clear();
            weeklyEarningChart.Series.Add("Total Earning");
            weeklyEarningChart.DataSource = dayDictionary.ToList();
            weeklyEarningChart.Series[0].XValueMember = "day";
            weeklyEarningChart.Series[0].YValueMembers = "totalEarning";
            weeklyEarningChart.Series[0].ChartType = SeriesChartType.Column;
            weeklyEarningChart.Series[0].IsValueShownAsLabel = true;
            weeklyEarningChart.Series[0].LabelFormat = "NPR. {0}";
            weeklyEarningChart.Series[0].IsVisibleInLegend = false;
            weeklyEarningChart.ChartAreas[0].AxisX.Title = "Day of the Week";
            weeklyEarningChart.ChartAreas[0].AxisY.Title = "Total Earning";
            weeklyEarningChart.Series[0].LabelForeColor = Color.Gray;


            // add the columns in the column combo box
            wColumnComboBox.Items.Clear();
            for (int i = 1; i < weeklyTransactionGridView.Columns.Count; i++)
            {
                wColumnComboBox.Items.Add(weeklyTransactionGridView.Columns[i].HeaderText);
            }
            wColumnComboBox.SelectedIndex = 0;
            wOrderComboBox.SelectedIndex = 0;
        }

        private void wSortButton_Click(object sender, EventArgs e)
        {
            if (wColumnComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a column to sort.");
                return;
            }

            if(wOrderComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a sort order.");
                return;
            }

            // get the column name and order type
            string columnName = weeklyTransactionGridView.Columns[wColumnComboBox.SelectedIndex+1].Name;
            bool ascending = wOrderComboBox.SelectedIndex == 0;

            // create a list of the data
            List<object> data = new List<object>();
            BindingSource wpbs = (BindingSource)weeklyTransactionGridView.DataSource;

            foreach (var item in wpbs)
            {
                data.Add(item);
            }

            // sort the list
            List<object> sorted = MergeSort(data, columnName, ascending);

            // clear the bindingsource
            wpbs.Clear();

            // add the sorted data back to the bindingsource
            wpbs.DataSource = sorted;

            weeklyTransactionGridView.DataSource = wpbs;
        }

        /* -------------------------------------------------------- Employee Page -------------------------------------------------------- */

        private void clearEmployeeForm()
        {
            eUsernameTextBox.Text = "";
            eNameTextBox.Text = "";
            eJoinDateTextBox.Text = "";
            userTypeComboBox.Items.Clear();

            eEditButton.Text = "Edit";
            eUpdateButton.Hide();
        }

        private void updateUserDataBase(bool updateDatabse)
        {
            if (updateDatabse)
            {
                // Initialize the new user
                FileStream fileStream = new FileStream(userDatasetPath, FileMode.Create, FileAccess.Write);

                // updating the user dataset file
                userXmlSerializer.Serialize(fileStream, users);
                fileStream.Close();
            }

            // load data in employee datagrid
            BindingSource ebs = new BindingSource();
            ebs.DataSource = users.Select(x => new {x.username, x.name, x.userType, x.created}).ToList();
            employeeDataGridView.DataSource = ebs;
            
            changeHeaderText(employeeDataGridView, new List<string>() { "Username", "Name", "User Type", "Created Date" });
        }

        private void eEditButton_Click(object sender, EventArgs e)
        {
            if(eEditButton.Text.Equals("Edit"))
            {
                // get the selected row from the datagrid
                DataGridViewRow selectedRow = employeeDataGridView.SelectedRows[0];

                // if the selected user is the current user, then disable do not allow to edit
                if (selectedRow.Cells[0].Value.ToString().Equals(curUser.username))
                {
                    MessageBox.Show("You cannot edit access to your own account.");
                    return;
                }

                // fill the textboxes with the selected row
                eUsernameTextBox.Text = selectedRow.Cells[0].Value.ToString();
                eNameTextBox.Text = selectedRow.Cells[1].Value.ToString();
                eJoinDateTextBox.Text = formatDateTime(DateTime.Parse(selectedRow.Cells[3].Value.ToString()));

                // fill the user type combobox with the selected row
                userTypeComboBox.Items.Clear();
                userTypeComboBox.Items.Add("Admin");
                userTypeComboBox.Items.Add("Staff");
                userTypeComboBox.SelectedIndex = userTypeComboBox.FindStringExact(selectedRow.Cells[2].Value.ToString());

                eEditButton.Text = "Cancel";
                eUpdateButton.Show();
            }
            else if(eEditButton.Text.Equals("Cancel"))
            {
                clearEmployeeForm();
            }
        }

        private void eUpdateButton_Click(object sender, EventArgs e)
        {
            // get the visitor from the username textbox
            var selectedUser = users.Where(x => x.username.Equals(eUsernameTextBox.Text)).FirstOrDefault();

            // update the visitor type
            selectedUser.userType = userTypeComboBox.SelectedItem.ToString();
            MessageBox.Show("User type updated successfully");

            // update the user dataset
            updateUserDataBase(true);

            // clear the form
            clearEmployeeForm();
        }

        
    }
}
