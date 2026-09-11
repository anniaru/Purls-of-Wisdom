using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace YarnShop
{
    public partial class Notices : Form
    {
        List<Notice> displayedNotices = new List<Notice>();
        bool showDismissed = false;
        bool showArchived = false;
        bool defaultOrder = true;
        DateTime dateToReviewFilter = DateTime.Today.Date;
        DateTime dateIssuedFilter = DateTime.Today.Date;

        bool ascPriority = false;
        bool ascReview = false;

        string currentCommand = "";

        // Make form draggable
        bool drag = false;
        Point dragCursor;
        Point dragForm;

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void pbxBar_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            dragCursor = Cursor.Position;
            dragForm = Location;
        }
        private void pbxBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point difference = Point.Subtract(Cursor.Position, new Size(dragCursor));
                Location = Point.Add(dragForm, new Size(difference));
            }
        }
        private void pbxBar_MouseUp(object sender, MouseEventArgs e)
        {

            drag = false;
        }
        public Notices()
        {
            InitializeComponent();
        }
        private void FormNotices_Load(object sender, EventArgs e)
        {
            refreshAllNotices(false);
        }
        private void btnFilter_Click(object sender, EventArgs e) // Show order by filters
        {
            if (btnPriorityOrder.Visible)
            {
                defaultOrder = true;
                btnPriorityOrder.Visible = false;
                btnReviewOrder.Visible = false;
                ascPriority = false;
                ascReview = false;
                refreshPanel(defaultOrder);
            }
            else
            {
                defaultOrder = false;
                btnPriorityOrder.Visible = true;
                btnReviewOrder.Visible = true;
                btnPriorityOrder.Image = Image.FromFile("down.png");
                btnReviewOrder.Image = Image.FromFile("down.png");
                ascPriority = false;
                ascReview = false;
            }
        }
        private void btnPriorityOrder_Click(object sender, EventArgs e) // Changes the order of all notices shown according to priority
        {
            if (ascPriority) // If notices are currently ordered by ascending priority
            {
                btnPriorityOrder.Image = Image.FromFile("down.png"); ascPriority = false;
            }
            else // If notices are not being ordered by ascending priority
            {
                btnPriorityOrder.Image = Image.FromFile("up.png"); ascPriority = true;
            }
            displayedNotices = mergeSort(displayedNotices.ToArray<Notice>(), "Priority", ascPriority).ToList(); // Sorts the notices by priority
            refreshPanel(false);
        }
        private void btnReviewOrder_Click(object sender, EventArgs e) // Changes the order of all notices shown according to review date
        {
            if (ascReview) // If notices are currently ordered by ascending review date
            {
                btnReviewOrder.Image = Image.FromFile("down.png"); ascReview = false;
            }
            else // If notices are currently ordered by descending review date
            {
                btnReviewOrder.Image = Image.FromFile("up.png"); ascReview = true;
            }
            displayedNotices = mergeSort(displayedNotices.ToArray<Notice>(), "Date To Review", ascReview).ToList(); // Sorts the notice by review date
            refreshPanel(false);
        }
        private Notice[] merge(Notice[] left, Notice[] right, string orderBy, bool asc)
        {
            Notice[] merged = new Notice[left.Length + right.Length]; // merge the items and store in new array
            int indexLeft = 0; // left current position
            int indexRight = 0; // right current position
            int indexMerged = 0; // merged current position

            // while notices left to merge
            while (indexLeft < left.Length && indexRight < right.Length)
            {
                switch (orderBy)
                {
                    case "Date To Review": // If ordering by review date
                        if (asc) // If ascending order of review date
                        {
                            if (left[indexLeft].dateToReview < right[indexRight].dateToReview)
                            {
                                merged[indexMerged] = left[indexLeft];
                                indexLeft++;
                                indexMerged++;
                            }
                            else
                            {
                                merged[indexMerged] = right[indexRight];
                                indexRight++;
                                indexMerged++;
                            }
                        }
                        else // Descending order of review date
                        {
                            if (left[indexLeft].dateToReview > right[indexRight].dateToReview)
                            {
                                merged[indexMerged] = left[indexLeft];
                                indexLeft++;
                                indexMerged++;
                            }
                            else
                            {
                                merged[indexMerged] = right[indexRight];
                                indexRight++;
                                indexMerged++;
                            }
                        }
                        break;
                    case "Priority": // If ordering by priority
                        if (asc) // If ascending order of priority
                        {
                            if (left[indexLeft].priority < right[indexRight].priority)
                            {
                                merged[indexMerged] = left[indexLeft];
                                indexLeft++;
                                indexMerged++;
                            }
                            else
                            {
                                merged[indexMerged] = right[indexRight];
                                indexRight++;
                                indexMerged++;
                            }
                        }
                        else // descending order of priority
                        {
                            if (left[indexLeft].priority > right[indexRight].priority)
                            {
                                merged[indexMerged] = left[indexLeft];
                                indexLeft++;
                                indexMerged++;
                            }
                            else
                            {
                                merged[indexMerged] = right[indexRight];
                                indexRight++;
                                indexMerged++;
                            }
                        }
                        break;
                }

            }

            // Add any remaining data from the left array to the merged data
            while (indexLeft < left.Length)
            {
                merged[indexMerged] = left[indexLeft];
                indexLeft++;
                indexMerged++;
            }

            // Add any remaining data from the right array to the merged data
            while (indexRight < right.Length)
            {
                merged[indexMerged] = right[indexRight];
                indexRight++;
                indexMerged++;
            }

            return merged;
        }
        private Notice[] mergeSort(Notice[] notices, string orderBy, bool asc)
        {
            Notice[] leftHalf; // left half of items
            Notice[] rightHalf; // right half of items
            Notice[] mergedItems = new Notice[notices.Length]; // store merged items with each recursive call

            if (notices.Length <= 1) // base case, recursion stops when each array contains one item
            {
                return notices;
            }
            else
            {
                int midpoint = (notices.Length - 1) / 2; // midpoint index
                int leftSize = midpoint + 1; // Size of the left half array
                int rightSize; // Size of the right half array

                // check if the total number of items is even to determine sizes of left and right arrays
                if (notices.Length % 2 == 0)
                {
                    rightSize = midpoint + 1; // Size of left and right arrays are equal since the length is even
                }
                else
                {
                    rightSize = midpoint; // Right array has one less item than left array since the length is odd
                }

                leftHalf = new Notice[leftSize]; // Left half
                rightHalf = new Notice[rightSize]; // Right half

                // Left half array populated up to and including the midpoint
                for (int i = 0; i < leftSize; i++)
                {
                    leftHalf[i] = notices[i];
                }

                // Right half array populated after midpoint
                int indexItems = midpoint + 1;
                for (int i = 0; i < rightSize; i++)
                {
                    rightHalf[i] = notices[indexItems];
                    indexItems++;
                }
                
                // Using recursion to sort both halves
                leftHalf = mergeSort(leftHalf, orderBy, asc);
                rightHalf = mergeSort(rightHalf, orderBy, asc);

                mergedItems = merge(leftHalf, rightHalf, orderBy, asc); // Merge both halves

                return mergedItems;
            }
        }
        public void refreshPanel(bool def)
        {
            if (def) // If all notices are to be sorted by default: descending review date, descending priority // if not being sorted by directly clicking the sort buttons
            {
                ascReview = false;
                ascPriority = false;
            }
            displayedNotices = mergeSort(displayedNotices.ToArray<Notice>(), "Date To Review", ascReview).ToList(); // sorts notices by date to review descending
            List<List<Notice>> noticesLists = new List<List<Notice>>(); // will store lists of notices for each individual date
            List<Notice> noticesDay = new List<Notice>(); // stores a list of notices for one specific date
            Notice prevNotice = null;
            if (displayedNotices.Count != 0) // If there are notices to sort
            {
                foreach (Notice notice in displayedNotices) // Separates all notices into lists where every notice in one list has the same review date
                {
                    if (prevNotice == null || prevNotice.dateToReview == notice.dateToReview)
                    {
                        // If the current notice has the same review date as the previous notice in the list
                        // If the current notice is the first notice in the list
                        noticesDay.Add(notice); // Add the notice to the list of notices for that specific review date
                    }
                    else
                    {
                        // If the current notice does not have the same review date as the previous notice
                        noticesLists.Add(new List<Notice>(noticesDay)); // Add the current list of notices for the specific date to the list of lists of all notices
                        noticesDay = new List<Notice>(); // Creates a new list
                        noticesDay.Add(notice); // Add the current notice to the new list
                    }
                    prevNotice = notice; // set the previous notice to the current notice so the next notice can be compared to it
                }

                if (noticesDay.Count > 0) // ensures last list of notices are added
                {
                    noticesLists.Add(new List<Notice>(noticesDay));
                }

                for (int i = 0; i < noticesLists.Count; i++)// goes through each list of notices for each date and sorts them by priority
                {
                    noticesLists[i] = mergeSort(noticesLists[i].ToArray<Notice>(), "Priority", ascPriority).ToList();
                }

                displayedNotices = new List<Notice>();
                foreach (List<Notice> noticesList in noticesLists)
                {
                    foreach(Notice notice in noticesList)
                    {
                        displayedNotices.Add(notice);
                    }
                }
            }
            flpNotices.Controls.Clear(); // Clears all notices displayed
            NoticeBox noticeBox;
            if (displayedNotices.Count > 0) // If there are notices to display
            {
                lblNoNotices.Visible = false;
                pbxNoNotices.Visible = false;
                int height = 40;
                for (int i = 0; i < displayedNotices.Count; i++) // Loops through the list of notices
                {
                    noticeBox = new NoticeBox(displayedNotices[i], height); 
                    noticeBox.Location = new Point(20, height);
                    flpNotices.Controls.Add(noticeBox); 
                    noticeBox.NoticeUpdated += notice_NoticeUpdated; // Subscribes to the notice box's event so
                    height += 90;
                }
            }
            else // If there are no notices
            {
                lblNoNotices.Visible = true;
                pbxNoNotices.Visible = true;
            }
            flpNotices.HorizontalScroll.Visible = false;
            flpNotices.HorizontalScroll.Enabled = false;
        }
        private void notice_NoticeUpdated(object sender, EventArgs e)
        {
            if(sender is NoticeBox nbx)
            {
                // Updates all notices shown
                refreshAllNotices(true);
            }
        }
        private void refreshAllNotices(bool filter)
        {
            // Gets all notices ordered by date to review, then by priority, unfiltered.
            displayedNotices.Clear();
            bool error = false;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = shopDB.mdb";
            OleDbCommand cmd = con.CreateCommand();
            OleDbDataReader reader;
            con.Open();
            if (!filter) // If all notices are to be refreshed without a filter, all active notices are retrieved
            {
                currentCommand = "SELECT *, 'TableStockNotices' AS Source FROM TableStockNotices WHERE Dismissed = False AND Archived = False UNION ALL SELECT *, 'TableCustOrderNotices' AS Source FROM TableCustOrderNotices WHERE Dismissed = False AND Archived = False UNION ALL SELECT *, 'TableSupplierOrderNotices' AS Source FROM TableSupplierOrderNotices WHERE Dismissed = False AND Archived = False UNION ALL SELECT *, 'TableEventNotices' AS Source FROM TableEventNotices WHERE Dismissed = False AND Archived = False ORDER BY Source ASC";
            }
            cmd.CommandText = currentCommand;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@dtr", DateTime.Parse(dateToReviewFilter.ToString()));
            cmd.Parameters.AddWithValue("@dti", DateTime.Parse(dateIssuedFilter.ToString()));
            cmd.Connection = con;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    bool archived = false;
                    bool dismissed = false;
                    // Access often uses -1 and 0 instead of True or False for boolean fields. This ensures data retrieved in this different format will be used correctly
                    if (Convert.ToInt32(reader[7]) == -1 || Convert.ToBoolean(reader[7])) 
                    {
                        dismissed = true;
                    }
                    if (Convert.ToInt32(reader[8]) == -1 || Convert.ToBoolean(reader[8]))
                    {
                        archived = true;
                    }
                    string type = "";
                    if (reader[3].ToString().Contains("Stock") || reader[3].ToString().Contains("Selling") || reader[3].ToString().Contains("Sales"))
                    {
                        type = "Stock";
                    }
                    if (reader[3].ToString().Contains("Collection"))
                    {
                        type = "Order Collection";
                    }
                    if (reader[3].ToString().Contains("Processing"))
                    {
                        type = "Order Processing";
                    }
                    if (reader[3].ToString().Contains("Supply"))
                    {
                        type = "Supply Delivery";
                    }
                    if (reader[3].ToString().Contains("Payments"))
                    {
                        type = "Event Payments";
                    }
                    if (reader[3].ToString().Contains("Spaces"))
                    {
                        type = "Event Spaces Available";
                    }
                    displayedNotices.Add(new Notice(Convert.ToInt32(reader[1]), Convert.ToInt32(reader[2]), reader[3].ToString(), Convert.ToInt32(reader[4]), Convert.ToDateTime(reader[5]), Convert.ToDateTime(reader[6]), dismissed, archived, type));
                }
                catch
                {
                    if (!error)
                    {
                        MessageBox.Show("Notice data is missing.", "Missing Data");
                        error = true;
                    }
                }
            }
            con.Close();
            refreshPanel(defaultOrder);
        }
        private void clearChecked(CheckedListBox clsbToClear)
        {
            for (int i = 0; i < clsbToClear.Items.Count; i++)
            {
                clsbToClear.SetSelected(i, false);
                clsbToClear.SetItemChecked(i, false);
            }
            clsbToClear.ClearSelected();
        }
        private void btnClear_Click(object sender, EventArgs e) // Clear all filters
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                clearAllFilters();
                refreshAllNotices(false);
            }
        }
        private void clearAllFilters()
        {
            clearChecked(clsbStock);
            clearChecked(clsbOrders);
            clearChecked(clsbPriority);
            clearChecked(clsbEvents);
            rbtn1dayReview.Checked = false;
            rbtn3daysReview.Checked = false;
            rbtn1weekReview.Checked = false;
            rbtnOlderReview.Checked = false;
            rbtnDay.Checked = false;
            rbtn3days.Checked = false;
            rbtn1week.Checked = false;
            rbtnOlder.Checked = false;
            chbxActive.Checked = false;
            chbxArchived.Checked = false;
            chbxDismissed.Checked = false;
        }
        private void btnApply_Click(object sender, EventArgs e) // Applies filters
        {
            bool query = false;
            int numTables = 0;
            string commandText = "";
            string eventCommandText = "SELECT *, 'TableEventNotices' AS Source FROM TableEventNotices ";
            string custOrderCommandText = "SELECT *, 'TableCustOrderNotices' AS Source FROM TableCustOrderNotices ";
            string supplierOrderCommandText = "SELECT *, 'TableSupplierOrderNotices' AS Source FROM TableSupplierOrderNotices ";
            string stockCommandText = "SELECT *, 'TableStockNotices' AS Source FROM TableStockNotices ";
            string priorityCommandText = " AND Priority IN (";

            string condition = "WHERE Title IN (";
            List<string> selectedEventFilters = clsbEvents.CheckedItems.Cast<string>().ToList();
            List<string> selectedOrderFilters = clsbOrders.CheckedItems.Cast<string>().ToList();
            List<string> selectedStockFilters = clsbStock.CheckedItems.Cast<string>().ToList();
            List<string> selectedPriorityFilters = clsbPriority.CheckedItems.Cast<string>().ToList();
            List<string> fullQuery = new List<string>
            {
                eventCommandText,
                custOrderCommandText,
                supplierOrderCommandText,
                stockCommandText
            };

            // REVIEW DATE
            bool dateToReview = false;
            string dateToReviewCondition = "DateToReview ";
            if (rbtn1dayReview.Checked)
            {
                dateToReview = true;
                dateToReviewFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-1).ToString());
                dateToReviewCondition += "> @dtr ";
            }
            if (rbtn3daysReview.Checked)
            {
                dateToReview = true;
                dateToReviewFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-3).ToString());
                dateToReviewCondition += "> @dtr ";
            }
            if (rbtn1weekReview.Checked)
            {
                dateToReview = true;
                dateToReviewFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-7).ToString());
                dateToReviewCondition += "> @dtr ";
            }
            if (rbtnOlderReview.Checked)
            {
                dateToReview = true;
                dateToReviewFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-7).ToString());
                dateToReviewCondition += "< @dtr ";
            }

            // ISSUE DATE
            bool dateIssued = false;
            string dateIssuedCondition = "DateIssued ";
            if (rbtnDay.Checked)
            {
                dateIssued = true;
                dateIssuedFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-1).ToString());
                dateIssuedCondition += "> @dti ";
            }
            if (rbtn3days.Checked)
            {
                dateIssued = true;
                dateIssuedFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-3).ToString());
                dateIssuedCondition += "> @dti ";
            }
            if (rbtn1week.Checked)
            {
                dateIssued = true;
                dateIssuedFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-7).ToString());
                dateIssuedCondition += "> @dti ";
            }
            if (rbtnOlder.Checked)
            {
                dateIssued = true;
                dateIssuedFilter = DateTime.Parse(DateTime.Today.Date.AddDays(-7).ToString());
                dateIssuedCondition += "< @dti ";
            }


            // EVENT NOTICES
            if (clsbEvents.CheckedItems.Count > 0) 
            {
                query = true;
                numTables++;

                commandText += eventCommandText + condition;
                foreach(string eventFilter in selectedEventFilters)
                {
                    if (commandText.EndsWith("("))
                    {
                        switch (eventFilter)
                        {
                            case "Payments":
                                commandText += "'Event Payments'";
                                break;
                            case "Spaces":
                                commandText += "'Event Spaces Available'";
                                break;
                        }
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        switch (eventFilter)
                        {
                            case "Payments":
                                commandText += ",'Event Payments'";
                                break;
                            case "Spaces":
                                commandText += ",'Event Spaces Available'";
                                break;
                        }
                    }
                }
                commandText += ")";
                if (clsbPriority.CheckedItems.Count > 0) 
                {
                    commandText += priorityCommandText;
                    foreach(string priorityFilter in selectedPriorityFilters)
                    {
                        if (commandText.EndsWith("("))
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += "3";
                                    break;
                                case "Medium":
                                    commandText += "2";
                                    break;
                                case "Low":
                                    commandText += "1";
                                    break;
                            }
                        }
                        // Add the checked filter to the command string.
                        else
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += ",3";
                                    break;
                                case "Medium":
                                    commandText += ",2";
                                    break;
                                case "Low":
                                    commandText += ",1";
                                    break;
                            }
                        }
                    }
                    commandText += ")";

                }
                if (dateToReview && dateIssued)
                {
                    commandText += " AND " + dateToReviewCondition + " AND " + dateIssuedCondition + " ";
                }
                else if(dateToReview)
                {
                    commandText += " AND " + dateToReviewCondition + " ";
                }
                else if (dateIssued)
                {
                    commandText += " AND " + dateIssuedCondition +" ";
                }
                
                if(!chbxActive.Checked && !chbxArchived.Checked && !chbxDismissed.Checked)
                {
                    commandText += " AND Archived = False AND Dismissed = False ";
                }
                else
                {
                    if (!(chbxActive.Checked && chbxDismissed.Checked && chbxArchived.Checked))// if all of them arent selected
                    {
                        if(chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False AND Dismissed = False ";
                        }
                        else if(!chbxActive.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Archived = True ";
                        }
                        else if(!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = True ";
                        } 
                    }
                }
            }
            if (clsbStock.CheckedItems.Count > 0)
            {
                numTables++;
                if (query)
                {
                    commandText += " UNION ALL ";
                }
                else
                {
                    query = true;
                }
                commandText += stockCommandText + condition;
                foreach (string stockFilter in selectedStockFilters)
                {
                    if (commandText.EndsWith("("))
                    {
                        if (selectedStockFilters.Contains("Low Stock") && selectedStockFilters.Contains("Selling Fast"))
                        {
                            commandText += "'Low Stock & Selling Fast','Low Stock'";
                        }
                        else
                        {

                            commandText += "'" + stockFilter + "'";
                        }
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        commandText += ",'" + stockFilter + "'";
                    }
                }
                commandText += ")";
                if (clsbPriority.CheckedItems.Count > 0)
                {
                    commandText += priorityCommandText;
                    foreach (string priorityFilter in selectedPriorityFilters)
                    {
                        if (commandText.EndsWith("("))
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += "3";
                                    break;
                                case "Medium":
                                    commandText += "2";
                                    break;
                                case "Low":
                                    commandText += "1";
                                    break;
                            }
                        }
                        // Add the checked filter to the command string.
                        else
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += ",3";
                                    break;
                                case "Medium":
                                    commandText += ",2";
                                    break;
                                case "Low":
                                    commandText += ",1";
                                    break;
                            }
                        }
                    }
                    commandText += ")";

                }
                if (dateToReview && dateIssued)
                {
                    commandText += " AND " + dateToReviewCondition + " AND " + dateIssuedCondition + " ";
                }
                else if (dateToReview)
                {
                    commandText += " AND " + dateToReviewCondition + " ";
                }
                else if (dateIssued)
                {
                    commandText += " AND " + dateIssuedCondition + " ";
                }

                if (!chbxActive.Checked && !chbxArchived.Checked && !chbxDismissed.Checked)
                {
                    commandText += " AND Archived = False AND Dismissed = False ";
                }
                else
                {
                    if (!(chbxActive.Checked && chbxDismissed.Checked && chbxArchived.Checked))// if all of them arent selected
                    {
                        if (chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False AND Dismissed = False ";
                        }
                        else if (!chbxActive.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Archived = True ";
                        }
                        else if (!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = True ";
                        }
                    }
                }
            }
            if (clsbOrders.CheckedItems.Count > 0 && selectedOrderFilters.Contains("Supply")) 
            {
                numTables++;
                if (query)
                {
                    commandText += " UNION ALL ";
                }
                else
                {
                    query = true;
                }
                commandText += supplierOrderCommandText + "WHERE Title LIKE '%Supply Delivery%'";
                if (clsbPriority.CheckedItems.Count > 0)
                {
                    commandText += priorityCommandText;
                    foreach (string priorityFilter in selectedPriorityFilters)
                    {
                        if (commandText.EndsWith("("))
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += "3";
                                    break;
                                case "Medium":
                                    commandText += "2";
                                    break;
                                case "Low":
                                    commandText += "1";
                                    break;
                            }
                        }
                        // Add the checked filter to the command string.
                        else
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += ",3";
                                    break;
                                case "Medium":
                                    commandText += ",2";
                                    break;
                                case "Low":
                                    commandText += ",1";
                                    break;
                            }
                        }
                    }
                    commandText += ")";

                }
                if (dateToReview && dateIssued)
                {
                    commandText += " AND " + dateToReviewCondition + " AND " + dateIssuedCondition + " ";
                }
                else if (dateToReview)
                {
                    commandText += " AND " + dateToReviewCondition + " ";
                }
                else if (dateIssued)
                {
                    commandText += " AND " + dateIssuedCondition + " ";
                }

                if (!chbxActive.Checked && !chbxArchived.Checked && !chbxDismissed.Checked)
                {
                    commandText += " AND Archived = False AND Dismissed = False ";
                }
                else
                {
                    if (!(chbxActive.Checked && chbxDismissed.Checked && chbxArchived.Checked))// if all of them arent selected
                    {
                        if (chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False AND Dismissed = False ";
                        }
                        else if (!chbxActive.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Archived = True ";
                        }
                        else if (!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = True ";
                        }
                    }
                }
            }
            if (clsbOrders.CheckedItems.Count > 0 && (selectedOrderFilters.Contains("Collection") || selectedOrderFilters.Contains("Processing")))
            {
                numTables++;
                if (query)
                {
                    commandText += " UNION ALL ";
                }
                else
                {
                    query = true;
                }
                commandText += custOrderCommandText + "WHERE Title LIKE";
                foreach (string custOrderFilter in selectedOrderFilters)
                {
                    if (commandText.EndsWith("E"))
                    {
                        switch (custOrderFilter)
                        {
                            case "Collection":
                                commandText += " '%Order Collection Overdue%'";
                                break;
                            case "Processing":
                                commandText += " '%Order Processing Overdue%'";
                                break;
                        }
                    }
                    // Add the checked filter to the command string.
                    else
                    {
                        switch (custOrderFilter)
                        {
                            case "Collection":
                                commandText += " OR Title LIKE '%Order Collection Overdue%'";
                                break;
                            case "Processing":
                                commandText += " OR Title LIKE '%Order Processing Overdue%'";
                                break;
                        }
                    }
                }
                if (clsbPriority.CheckedItems.Count > 0)
                {
                    commandText += priorityCommandText;
                    foreach (string priorityFilter in selectedPriorityFilters)
                    {
                        if (commandText.EndsWith("("))
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += "3";
                                    break;
                                case "Medium":
                                    commandText += "2";
                                    break;
                                case "Low":
                                    commandText += "1";
                                    break;
                            }
                        }
                        // Add the checked filter to the command string.
                        else
                        {
                            switch (priorityFilter)
                            {
                                case "High":
                                    commandText += ",3";
                                    break;
                                case "Medium":
                                    commandText += ",2";
                                    break;
                                case "Low":
                                    commandText += ",1";
                                    break;
                            }
                        }
                    }
                    commandText += ")";

                }
                if (dateToReview && dateIssued)
                {
                    commandText += " AND " + dateToReviewCondition + " AND " + dateIssuedCondition;
                }
                else if (dateToReview)
                {
                    commandText += " AND " + dateToReviewCondition;
                }
                else if (dateIssued)
                {
                    commandText += " AND " + dateIssuedCondition;
                }
                if (!chbxActive.Checked && !chbxArchived.Checked && !chbxDismissed.Checked)
                {
                    commandText += " AND Archived = False AND Dismissed = False ";
                }
                else
                {
                    if (!(chbxActive.Checked && chbxDismissed.Checked && chbxArchived.Checked))// if all of them arent selected
                    {
                        if (chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = False ";
                        }
                        else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Archived = False AND Dismissed = False ";
                        }
                        else if (!chbxActive.Checked && chbxArchived.Checked)
                        {
                            commandText += " AND Archived = True ";
                        }
                        else if (!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                        {
                            commandText += " AND Dismissed = True ";
                        }
                    }
                }
            }
            if (!query) // if no specific filter is selected
            {
                numTables = 4;
                int numUnions = 0;

                foreach(string str in fullQuery)
                {
                    bool conditionPresent = false;
                    commandText += str; 
                    if (clsbPriority.CheckedItems.Count > 0)
                    {
                        conditionPresent = true;
                        commandText += "WHERE Priority IN (";
                        foreach (string priorityFilter in selectedPriorityFilters)
                        {
                            if (commandText.EndsWith("("))
                            {
                                switch (priorityFilter)
                                {
                                    case "High":
                                        commandText += "3";
                                        break;
                                    case "Medium":
                                        commandText += "2";
                                        break;
                                    case "Low":
                                        commandText += "1";
                                        break;
                                }
                            }
                            // Add the checked filter to the command string.
                            else
                            {
                                switch (priorityFilter)
                                {
                                    case "High":
                                        commandText += ",3";
                                        break;
                                    case "Medium":
                                        commandText += ",2";
                                        break;
                                    case "Low":
                                        commandText += ",1";
                                        break;
                                }
                            }
                        }
                        commandText += ")";

                    }
                    if (commandText.EndsWith(")") && (dateToReview || dateIssued))
                    {
                        conditionPresent = true;
                        if (dateToReview && dateIssued)
                        {
                            commandText += " AND " + dateToReviewCondition + " AND " + dateIssuedCondition + " ";
                        }
                        else if (dateToReview)
                        {
                            commandText += " AND " + dateToReviewCondition + " ";
                        }
                        else if (dateIssued)
                        {
                            commandText += " AND " + dateIssuedCondition + " ";
                        }
                    }
                    else
                    {
                        if (dateToReview && dateIssued)
                        {
                            conditionPresent = true;
                            commandText += "WHERE " + dateToReviewCondition + " AND " + dateIssuedCondition + " ";
                        }
                        else if (dateToReview)
                        {
                            conditionPresent = true;
                            commandText += "WHERE " + dateToReviewCondition + " ";
                        }
                        else if (dateIssued)
                        {
                            conditionPresent = true;
                            commandText += "WHERE " + dateIssuedCondition + " ";
                        }
                    }
                    
                    if (!chbxActive.Checked && !chbxArchived.Checked && !chbxDismissed.Checked)
                    {
                        if (!conditionPresent)
                        {
                            commandText += "WHERE Archived = False AND Dismissed = False ";
                        }
                        else
                        {
                            commandText += " AND Archived = False AND Dismissed = False ";
                        }
                    }
                    else
                    {
                        if (!(chbxActive.Checked && chbxDismissed.Checked && chbxArchived.Checked))// if all of them arent selected
                        {
                            if (!conditionPresent)
                            {
                                if (chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += "WHERE Archived = False ";
                                }
                                else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                                {
                                    commandText += "WHERE Dismissed = False ";
                                }
                                else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += "WHERE Archived = False AND Dismissed = False ";
                                }
                                else if (!chbxActive.Checked && chbxArchived.Checked)
                                {
                                    commandText += "WHERE Archived = True ";
                                }
                                else if (!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += "WHERE Dismissed = True ";
                                }
                            }
                            else
                            {
                                if (chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += " AND Archived = False ";
                                }
                                else if (chbxActive.Checked && !chbxDismissed.Checked && chbxArchived.Checked)
                                {
                                    commandText += " AND Dismissed = False ";
                                }
                                else if (chbxActive.Checked && !chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += " AND Archived = False AND Dismissed = False ";
                                }
                                else if (!chbxActive.Checked && chbxArchived.Checked)
                                {
                                    commandText += " AND Archived = True ";
                                }
                                else if (!chbxActive.Checked && chbxDismissed.Checked && !chbxArchived.Checked)
                                {
                                    commandText += " AND Dismissed = True ";
                                }
                            }
                            
                        }
                    }
                    numUnions++;
                    if (numUnions < 4)
                    {
                        commandText += "UNION ALL ";
                    }
                    
                }
                

            }
            if (numTables > 1)
            {
                commandText += " ORDER BY DateToReview DESC, Priority DESC, Source ASC";
            }
            else
            {
                commandText += " ORDER BY DateToReview DESC, Priority DESC";
            }

            currentCommand = commandText;
            refreshAllNotices(true);
        }
        private void btnArchive_Click(object sender, EventArgs e) // Clears all filters and shows all archived notices
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (!showArchived) // If archived notices aren't currently being shown, show all archived notices
                {
                    currentCommand = "SELECT *, 'TableStockNotices' AS Source FROM TableStockNotices WHERE Archived = True UNION ALL SELECT *, 'TableCustOrderNotices' AS Source FROM TableCustOrderNotices WHERE Archived = True UNION ALL SELECT *, 'TableSupplierOrderNotices' AS Source FROM TableSupplierOrderNotices WHERE Archived = True UNION ALL SELECT *, 'TableEventNotices' AS Source FROM TableEventNotices WHERE Archived = True ORDER BY DateToReview DESC, Priority DESC, Source ASC;";
                    chbxActive.Checked = false;
                    chbxArchived.Checked = true;
                    chbxDismissed.Checked = false;
                    refreshAllNotices(true);
                }
                else
                {
                    refreshAllNotices(false);
                }
                clearAllFilters();
            }
        }
        private void btnDismissed_Click(object sender, EventArgs e) // Clears all filters and shows all dismissed notices
        {
            DialogResult result = MessageBox.Show("This will clear all filters. Proceed?", "Clear All Filters", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                if (!showDismissed) // If dismissed notices aren't currently being shown, show all dismissed notices
                {
                    currentCommand = "SELECT *, 'TableStockNotices' AS Source FROM TableStockNotices WHERE Archived = False AND Dismissed = True UNION ALL SELECT *, 'TableCustOrderNotices' AS Source FROM TableCustOrderNotices WHERE Archived = False AND Dismissed = True UNION ALL SELECT *, 'TableSupplierOrderNotices' AS Source FROM TableSupplierOrderNotices WHERE Archived = False AND Dismissed = True UNION ALL SELECT *, 'TableEventNotices' AS Source FROM TableEventNotices WHERE Archived = False AND Dismissed = True ORDER BY DateToReview DESC, Priority DESC, Source ASC;";
                    refreshAllNotices(true);
                }
                else
                {
                    refreshAllNotices(false);
                }
                clearAllFilters();
            }
            
        }
        private void btnRefresh_Click(object sender, EventArgs e) // Show all current results by default order
        {
            defaultOrder = true;
            btnPriorityOrder.Visible = false;
            btnReviewOrder.Visible = false;
            ascPriority = false;
            ascReview = false;
            refreshPanel(defaultOrder);
        }
    }   
    
}
