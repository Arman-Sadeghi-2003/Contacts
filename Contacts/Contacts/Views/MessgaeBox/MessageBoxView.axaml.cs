using Avalonia.Controls;

namespace Contacts;

public partial class MessageBoxView : Window
{
    public MessageBoxView()
    {
        InitializeComponent();
    }

    public MessageBoxView(string title, string content) : this()
    {
        DataContext = this;
        this.MsgTitle = title;
        this.MsgContent = content;
    }

    public string? MsgTitle { get; set; }
    public string? MsgContent { get; set; }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        this.Close();
    }
}