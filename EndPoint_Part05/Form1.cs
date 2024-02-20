using EndPoint_Part05.CustomControl;
using Models.Shopping;
using System;
using System.Windows.Forms;
using SadrTools.Extension;
using Models.Personel;
using System.Linq;
using System.Drawing;
using ViewModels.Personel;
using Basic = Models.Personel;
using System.Data;

namespace EndPoint_Part05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button button = new Button();

            Button button1 = new SuccessButton();
          
            Grid.CellClick += DataGridView_CellClick;


        }
        ///////////////////////////////////////////////////////////////////
        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) 
            {

                var selectedPerson = Grid.Rows[e.RowIndex].DataBoundItem as Basic.Person;


                ClearOrHidePreviousGridContent();

                DisplayTelephoneAndEmailInformation(selectedPerson);
            }
        }



        private DataGridView telephoneAndEmailDataGridView;

        private void DisplayTelephoneAndEmailInformation(Basic.Person person)
        {
            telephoneAndEmailDataGridView = new DataGridView();
            telephoneAndEmailDataGridView.AutoGenerateColumns = true;
            telephoneAndEmailDataGridView.DataSource = person.Telephones;
  
            telephoneAndEmailDataGridView.Location = new Point(52,100); 
            telephoneAndEmailDataGridView.Size = new Size(345,80);
     
            telephoneAndEmailDataGridView.Dock = DockStyle.None;
            
            Controls.Add(telephoneAndEmailDataGridView);

        }

        private void ClearOrHidePreviousGridContent()
        {
            if (telephoneAndEmailDataGridView != null)
            {
                Controls.Remove(telephoneAndEmailDataGridView);
                telephoneAndEmailDataGridView.Dispose();
            }
            else if (Grid.DataSource is DataTable dataTable)
            {
                dataTable.Rows.Clear();
            }
            else
            {
                Grid.DataSource = null;
            }
        }




        /////////////////////////////////////////////////////////////////
        private void BtnShow_Click(object sender, EventArgs e)
        {

            var people = SampleData.Personel.GetPeople();

            Grid.DataSource = people;

           // var resultInText = people.PrintMe<Person>();

            //MessageBox.Show(resultInText);

        }

        private void BtnDisplayOrders_Click(object sender, EventArgs e)
        {

            var customer1 = new Customer(fullName: "باید فول نیم در لحظه ایجاد آبجکت مقدار بگیرد");


            var orders = SampleData.Shopping.GetOrders();
            Grid.DataSource = orders;


        }

        private void SuccessButton1_Click(object sender, EventArgs e)
        {

            //ToDo : Yasamin : Linq Examples on Orders ( GRP , ... ) 

            //ToDo : Intamedia




        }

        private void BtnPersonDTO_Click(object sender, EventArgs e)
        {
            // DTO       : DATA TRANSFER OBJECT

            // ViewModel : برای نمایش برای گرید ....و لزوما در دیتابیس یا در لایه دامین شما به این شکل وجود ندارد

            // PersonDto
            // PersonViewModel


            var people = SampleData.Personel.GetPeople().Select(x => new
            {
                MyFullName = x.FullName,
                MyAlaki = x.Age
            }).ToList();


            Grid.DataSource = people;

            MessageBox.Show("Continue ..........? ");


            var people2 = SampleData.Personel.GetPeople().Select(x =>
            new PersonViewModel
            {
                PersonID = x.ID,
                Age = x.Age,
                Birthday = x.PersianBirthDate,
                PersonLastName = x.LastName,
                PersonName = x.FirstName
            }).ToList();

            Grid.DataSource = people2;
        }
    }
}
