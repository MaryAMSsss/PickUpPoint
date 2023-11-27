using Demo_var_6Last.DataB;
using Demo_var_6Last.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Demo_var_6Last.Views
{
    /// <summary>
    /// Логика взаимодействия для ContentWindow.xaml
    /// </summary>
    
    public partial class ContentWindow : Window
    {
        User user1;
        Order order1;
        public List<PickUpPoint> pickUpPoints = PickUpPointDB.GetPoints();
        public ContentWindow(User user)
        {            
            InitializeComponent();
            user1 = user;
            AddUserNameToControl();
            pickUpCb.ItemsSource = pickUpPoints;
        }
        public void AddUserNameToControl()
        {
            string nameUser = user1.Lfp;
            userId.Text = nameUser;
        }
        PickUpPoint pickUpPoint = new PickUpPoint();
        public void AddOrderToDb(Order order)
        {
            PickUpPoint pickUpPointCb = pickUpCb.SelectedItem as PickUpPoint;//получили всю строку пункта выдачи
            string point;            
            DateTime dateTime = DateTime.Now;
            DateTime deliveryDate = dateOrderPicker.SelectedDate??DateTime.Now.AddDays(3);
            string orderStatus = StatusTB.Text;
            int pickUpCode = Convert.ToInt32(pickUpCodeTB.Text);
            if (pickUpCode == null) 
            {
                MessageBox.Show("Вы не ввели код получения");
                return;
            }
            else if(orderStatus == null)
            {
                MessageBox.Show("Вы не ввели статус");
                return;
            }
            Order orderr = new Order(dateTime, deliveryDate, pickUpPointCb.PointId, user1.UserId, pickUpCode, orderStatus);
            OrderDB.AddOrder(orderr);
        }
        private void addOrderButton_Click(object sender, RoutedEventArgs e)
        {
            AddOrderToDb(order1);
            MessageBox.Show("Заказ успешно создан");
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
