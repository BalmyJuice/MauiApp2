using Microsoft.Maui.Animations;
using System.Net.Mail;
using System.Net;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using static MauiApp2.DataBaseRepository;

namespace MauiApp2.View;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();

	}

    private async void LogIn(object sender, EventArgs e)
    {
        //var user = (Users)BindingContext;
        //if (!String.IsNullOrEmpty(user.Name))
        //{
        //    App.Database.SaveItem(user);
        //}

        //TodoItemDatabase db = new TodoItemDatabase();
        //var a = await db.SaveItemAsync(new DataBase.Users { Name = "Slavik", Email = "slavik@mail.ru", Password = "123321" });
        //var result = await db.GetItemsAsync();
        //AlertDialog dialog = new AlertDialog()
        //{
        //    BackgroundColor = Color.FromHex("#FFFFFF"),
        //    TitleTextColor = Color.FromHex("#000000"),
        //    MessageTextColor = Color.FromHex("#000000"),
        //    TitleFontFamily = "Arial",
        //    TitleFontSize = 18,
        //    MessageFontFamily = "Arial",
        //    MessageFontSize = 14
        //};

        if (Name.Text != null && Email.Text != null && Age.Text != null && Password.Text != null && RPassword.Text != null)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            bool isEmailValid = regex.IsMatch(Email.Text);
            string[] emailParts = Email.Text.Split('@');
            string domain = emailParts[1];
            var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
            var emailData = await todoItemDatabase.GetEmailDataAsync(Email.Text);
            if (isEmailValid)
            {
                if (domain == "mail.ru" || domain == "gmail.com" || domain == "mtp.by")
                {

                    if (emailData == null)
                    {
                        if (Password.Text == RPassword.Text)
                        {
                            TodoItemDatabase db = new TodoItemDatabase();
                            var a = await db.SaveItemAsync(new DataBase.Users { Name = Name.Text, Email = Email.Text, Age = Age.Text, Password = Password.Text });
                            var result = await db.GetItemsAsync();

                            Preferences.Set("UserEmail", Email.Text);
                            // ������� ����� �������� AppShell
                            var mainPage = new AppShell(/*Name.Text, Email.Text, Age.Text*/);

                            // ������������� ����� �������� AppShell ��� ������� ��������
                            Application.Current.MainPage = mainPage;

                            // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
                            await mainPage.Navigation.PopToRootAsync();

                            // ���������� ��������� �� ����� � �������� �����������
                            var fromAddress = new MailAddress("slava-kisel-2017@mail.ru", "BlackRose");
                            var toAddress = new MailAddress(/*"slava.kisel.94@mail.ru" torunn4ik@gmail.comm*/Email.Text, "BlackRose");
                            const string fromPassword = "7aVP4DmV6f7yQevehaz7";
                            const string subject = "����������� ������ �������";
                            const string body = "������������, {0}! �� ������� ������������������ � ����� �������.";
                            string formattedBody = string.Format(body, Name.Text);

                            var smtp = new SmtpClient
                            {
                                Host = "smtp.mail.ru",
                                Port = 587,
                                EnableSsl = true,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };

                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = subject,
                                Body = formattedBody
                            })
                            {
                                smtp.Send(message);
                            }
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("������", "������ �� ���������", "��");
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("������", "����� ��� ������", "��");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("������", "�������� �����\n��������� ������: @mail.ru; @gmail.com, @mtp.by", "��");
                }
                
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("������", "����� ������� �� ���������", "��");
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("������", "�� ��� ���� ���������", "��");
        }

    }

    private async void OnAut(object? sender, EventArgs e)
    {
        // ������� ����� �������� AppShell
        var aut = new Authorization(/*Name.Text, Email.Text, Age.Text*/);

        // ������������� ����� �������� AppShell ��� ������� ��������
        Application.Current.MainPage = aut;

        // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
        await aut.Navigation.PopToRootAsync();
    }

    //private void SaveFriend(object sender, EventArgs e)
    //{
    //    var friend = (Users)BindingContext;
    //    if (!String.IsNullOrEmpty(friend.Name))
    //    {
    //        App.Database.SaveItem(friend);
    //    }
    //    this.Navigation.PopAsync();
    //}
    //private void DeleteFriend(object sender, EventArgs e)
    //{
    //    var friend = (Users)BindingContext;
    //    App.Database.DeleteItem(friend.Id);
    //    this.Navigation.PopAsync();
    //}
    //private void Cancel(object sender, EventArgs e)
    //{
    //    this.Navigation.PopAsync();
    //}
}