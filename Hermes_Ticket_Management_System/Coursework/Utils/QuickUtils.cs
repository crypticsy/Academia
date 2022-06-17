using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Linq;

namespace Hermes
{
    class QuickUtils
    {
// Initialize the paths and font collection
        public static string dirPath;
        public static string userPicturesPath;
        public static PrivateFontCollection pfc;
        private static string fontsPath;

        // Custom Font initialization
        public static Font formTitleFont;
        public static Font highlightedFont;
        public static Font titleFont;
        public static Font heading1;
        public static Font heading2;
        public static Font heading2Intro;
        public static Font heading3;
        public static Font buttonFont;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public static void addResources()
        {
            // Set the paths
            dirPath = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(Application.ExecutablePath)));
            userPicturesPath = Path.Combine(dirPath, Path.Combine("data", "Profile picture"));
            fontsPath = Path.Combine(dirPath, Path.Combine("Static", "Fonts"));

            // Initialize the font collection
            pfc = new PrivateFontCollection();

            // Add the fonts to the font collection from the font folder
            string[] font_files = Directory.GetFiles(fontsPath);
            foreach (var fonts in font_files)
            {
                pfc.AddFontFile(Path.Combine(fonts));
            }

            formTitleFont = new Font(pfc.Families[4], 25);
            highlightedFont = new Font(pfc.Families[4], 15);
            titleFont = new Font(pfc.Families[4], 12);
            heading1 = new Font(pfc.Families[2], 12);
            heading2 = new Font(pfc.Families[2], 9);
            heading2Intro = new Font(pfc.Families[4], 9);
            heading3 = new Font(pfc.Families[3], 8);
            buttonFont = new Font(pfc.Families[2], 9);
        }

        public static GraphicsPath edgifyBorder(int width, int height)
        {
            GraphicsPath ellipseRadius = new GraphicsPath();
            ellipseRadius.StartFigure();
            ellipseRadius.AddArc(new Rectangle(0, 0, 10, 10), 180, 90);
            ellipseRadius.AddLine(10, 0, width - 10, 0);
            ellipseRadius.AddArc(new Rectangle(width - 10, 0, 10, 10), -90, 90);
            ellipseRadius.AddLine(width, 10, width, height - 10);
            ellipseRadius.AddArc(new Rectangle(width - 10, height - 10, 10, 10), 0, 90);
            ellipseRadius.AddLine(width - 10, height, 10, height);
            ellipseRadius.AddArc(new Rectangle(0, height - 10, 10, 10), 90, 90);
            ellipseRadius.CloseFigure();
            return ellipseRadius;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            // Resize the image to the specified width and height (size).
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static bool isWeekend(DateTime date)
        {
            // Check if the date is a weekend
            return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool checkWorkingHour()
        {
            // Check if the current time is within working hours
            DateTime currentTime = DateTime.Now;
            //return true;                                             /*** FOR TESTING PURPOSES ONLY ***/
            return currentTime.Hour >= 10 && currentTime.Hour < 18;
        }

        public static string formatDateTime(DateTime date)
        {
            // Format the date and time
            return date.ToString("dddd, dd MMMM yyyy hh:mm tt");
        }

        public static Image RoundCorners(Image image, int cornerRadius)
        {
            cornerRadius *= 2;
            Bitmap roundedImage = new Bitmap(image.Width, image.Height);
            GraphicsPath gp = new GraphicsPath();
            gp.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90);
            gp.AddArc(0 + roundedImage.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90);
            gp.AddArc(0 + roundedImage.Width - cornerRadius, 0 + roundedImage.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90);
            gp.AddArc(0, 0 + roundedImage.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90);
            using (Graphics g = Graphics.FromImage(roundedImage))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.SetClip(gp);
                g.DrawImage(image, Point.Empty);
            }
            return roundedImage;
        }

        public static string findAgeGroupLabel(uint Age)
        {
            // Find the age group of the person
            if (Age < 18)
            {
                // for under 18, aka child
                return "Child";
            }
            else if (Age > 60)
            {
                // for over 60, aka aged
                return "Aged";
            }

            // for ages 18-60, aka adults
            return "Adult";
        }

        public static float findPrice(string ageGroup, bool isWeekend, int hour, PriceModel Price)
        {
            if (isWeekend)
            {
                if (ageGroup.Equals("Child"))
                {
                    return Price.childWeekendPrice;
                }
                else if (ageGroup.Equals("Adult"))
                {
                    return Price.adultWeekendPrice;
                }
                else if (ageGroup.Equals("Aged"))
                {
                    return Price.agedWeekendPrice;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (ageGroup.Equals("Child"))
                {
                    return Price.childWeekdayPrice;
                }
                else if (ageGroup.Equals("Adult"))
                {
                    return Price.adultWeekdayPrice;
                }
                else if (ageGroup.Equals("Aged"))
                {
                    return Price.agedWeekdayPrice;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static void changeHeaderText(DataGridView dg, List<String> columnList)
        {
            // Change the header text of the data grid
            for (int i = 0; i < dg.Columns.Count; i++)
            {
                dg.Columns[i].HeaderText = columnList[i];
            }   
        } 

        public static void exportDataGrid(DataGridView dg)
        {
            // create a save file dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            // add csv and excel file types
            saveFileDialog.Filter = "CSV File(*.csv)|*.csv|Excel File(*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Export Checkout Dataset";
            saveFileDialog.ShowDialog();

            // if the user has selected a file
            if (saveFileDialog.FileName != "")
            {
                // save csv file
                if (saveFileDialog.FilterIndex == 1)
                {
                    // create a csv file
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // write the header from columns
                        sw.WriteLine(string.Join(",", dg.Columns.Cast<DataGridViewColumn>().Select(x => x.HeaderText)));
                        
                        // Join the cells into a string and write to the file   
                        foreach (DataGridViewRow row in dg.Rows)
                        {
                            sw.WriteLine(string.Join(",", row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value)));
                        }
                    }
                }
                else
                {
                    // create a new excel workbook
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Workbooks.Add();

                    // create a worksheet
                    Microsoft.Office.Interop.Excel._Worksheet workSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelApp.ActiveSheet;

                    // add the headers
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        workSheet.Cells[1, i + 1] = dg.Columns[i].HeaderText;
                    }

                    // add the data
                    for (int i = 0; i < dg.Rows.Count; i++)
                    {
                        for (int j = 0; j < dg.Columns.Count; j++)
                        {
                            workSheet.Cells[i + 2, j + 1] = dg.Rows[i].Cells[j].Value.ToString();
                        }
                    }

                    // save the file
                    workSheet.SaveAs(saveFileDialog.FileName);
                    excelApp.Quit();
                }
            }
        }

    }
}
