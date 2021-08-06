# qywxmessage-csharp
  Corp Weixin Robot Message API in C#. 


## Usage

Add reference,

than:

```csharp
using System.Windows;
using qywxmessage; //reference

namespace easyWPFpost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        void button_Click(object sender, RoutedEventArgs e)
        {
            var str = txb1.Text;
            var str2 = "";
            if (chk1.IsChecked == true)
            {
                str2 = "PowerUser";
                txb2.Text = str2;
            }

            var strsend = "😁😁😁😁😁!" + str + str2;
            var resultstr = easywxpost.sendpack(strsend); //send your message

            // Show message box when button is clicked.
            MessageBox.Show(resultstr);
        }
        
    }
}
```