using Rate_Tests;
using Customer_Tests;

public class TestForm : Form
{
    Label lblAmountOfTests = new Label() { Text = "Anzahl der Tests:", Location = new Point(10, 10) };
    TextBox txtAmountOfTests = new TextBox() { Location = new Point(120, 10) };
    CheckBox chkAzureRateTest = new CheckBox() { Text = "Azure Rate Testen", Location = new Point(10, 40), Width = 200 };
    CheckBox chkAWSRateTest = new CheckBox() { Text = "AWS Rate Testen", Location = new Point(10, 70), Width = 200 };
    CheckBox chkAzureQueueTests = new CheckBox() { Text = "Azure Queue Testen", Location = new Point(10, 100), Width = 200 };
    CheckBox chkAWSQueueTests = new CheckBox() { Text = "AWS Queue Testen", Location = new Point(10, 130), Width = 200 };
    CheckBox chkPrintAllInsuranceData = new CheckBox() { Text = "Versicherungsdaten ausgeben", Location = new Point(10, 160), Width = 200 };
    CheckBox chkPrintAPIResponse = new CheckBox() { Text = "API-Antwort ausgeben", Location = new Point(10, 190), Width = 200 };
    Button btnStart = new Button() { Text = "Start", Location = new Point(10, 220) };

    public TestForm()
    {
        Controls.Add(lblAmountOfTests);
        Controls.Add(txtAmountOfTests);
        Controls.Add(chkAzureRateTest);
        Controls.Add(chkAWSRateTest);
        Controls.Add(chkAzureQueueTests);
        Controls.Add(chkAWSQueueTests);
        Controls.Add(chkPrintAllInsuranceData);
        Controls.Add(chkPrintAPIResponse);
        Controls.Add(btnStart);

        btnStart.Click += BtnStart_Click;
    }

    private async void BtnStart_Click(object sender, EventArgs e)
    {
        int amountOfTests = int.Parse(txtAmountOfTests.Text);
        bool printAllInsuranceData = chkPrintAllInsuranceData.Checked;
        bool printAPIResponse = chkPrintAPIResponse.Checked;

        bool azureRateTest = chkAzureRateTest.Checked;
        bool awsRateTest = chkAWSRateTest.Checked;

        bool azureQueueTests = chkAzureQueueTests.Checked;
        bool awsQueueTests = chkAWSQueueTests.Checked;

        await MainClass.RunTests(amountOfTests, printAllInsuranceData, printAPIResponse, azureRateTest, awsRateTest, azureQueueTests, awsQueueTests);
    }
}

public static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new TestForm());
    }
}

public class MainClass {
    public static async Task RunTests(int amountOfTests, bool printAllInsuranceData, bool printAPIResponse, bool azureRateTest, bool awsRateTest, bool azureQueueTests, bool awsQueueTests) {

        Console.WriteLine("Started Testing, please wait ...");
        var (cats, customers) = await InsuranceCreation.CreateTestInsurances(amountOfTests, printAllInsuranceData);
        if (azureRateTest || awsRateTest) 
        {
            await RateTesting.CalculateRate(printAPIResponse, customers, cats, azureRateTest, awsRateTest, amountOfTests);
        }
        if (azureQueueTests || awsQueueTests) 
        {
            await CustomerTesting.QueueTests(amountOfTests, printAPIResponse, cats, customers, azureQueueTests, awsQueueTests);
        }
        Console.WriteLine("Tests Completed.");
        return;
    }
}



