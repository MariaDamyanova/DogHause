using DogHouse.Controller;
using DogHouse.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DogHouse
{
    public partial class Form1 : Form
    {
        DogsController dogsController = new DogsController();
        BreedsController breedController = new BreedsController();

        public Form1()
        {
            InitializeComponent();
        }
        private void LoadRecord(Dog dog)
        {
            txtId.BackColor = Color.White;
            txtId.Text = dog.Id.ToString();
            txtName.Text = dog.Name;
            txtAge.Text = dog.Age.ToString();
            cmbBreed.Text = dog.Breeds.Name;
        }
        private void ClearScreen()
        {
            txtId.BackColor = Color.White;
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            cmbBreed.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            List<Breed> allBreeds = breedController.GetAllBreeds();
            cmbBreed.DataSource = allBreeds;
            cmbBreed.DisplayMember = "Name";
            cmbBreed.ValueMember = "Id";

            btnSelectAll_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || txtName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtName.Focus();
                return;
            }
            Dog newDog = new Dog();
            newDog.Age = int.Parse(txtAge.Text);
            newDog.Name = txtName.Text;

            newDog.BreedId = (int)cmbBreed.SelectedValue;

            dogsController.Create(newDog);
            MessageBox.Show("Записът е успешно добавен!");
            ClearScreen();
            btnSelectAll_Click(sender, e);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            List<Dog> allDog = dogsController.GetAll();
            listBox1.Items.Clear();
            foreach (var item in allDog)
            {
                listBox1.Items.Add($"{item.Id}. {item.Name} - Age: {item.Age}  Breed:{item.Breeds.Name}");
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog findedDog = dogsController.Get(findId);
            if (findedDog == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findedDog);
            //if (string.IsNullOrEmpty(txtId.Text))
            //{
            //    Dog findedDog = dogsController.Get(findId);
            //    if (findedDog == null)
            //    {
            //        MessageBox.Show("Нама такъв запис в базата данни!");
            //        txtId.Focus();
            //        return;
            //    }
            //    LoadRecord(findedDog);
            //}
            //else
            //{
            //    Dog updatedog = new Dog();
            //    updatedog.Name = txtName.Text;
            //    updatedog.Age = int.Parse(txtAge.Text);
            //    updatedog.BreedId = (int)cmbBreed.SelectedValue;

            //}
            btnSelectAll_Click(sender, e);
        }

          

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведи Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            Dog findDog = dogsController.Get(findId);
            if (findDog == null)
            {
                MessageBox.Show("Нама такъв запис в базата данни!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            LoadRecord(findDog);

            DialogResult answer = MessageBox.Show("Наистина ли искате да изтриете запис N" + findId + "?", "PROMPT", MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                dogsController.Delete(findId);
            }
            btnSelectAll_Click(sender, e);

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtId.Text) || !txtId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Въведете Id за търсене!");
                txtId.BackColor = Color.Red;
                txtId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtId.Text);
            }
            //Ако няма намерен запис търсим по Id и визуализираме на екрана
            if (string.IsNullOrEmpty(txtName.Text))
            {
                Dog findedDog = dogsController.Get(findId);
                if (findedDog == null)
                {
                    MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД! \n Въведете Id за търсене!");
                    txtId.BackColor = Color.Red;
                    txtId.Focus();
                    return;
                }
                LoadRecord(findedDog);
            }
            else //Ако има намерен вече запис променяме по полетата
            {
                Dog updatedDog = new Dog();
                updatedDog.Name = txtName.Text;
                updatedDog.Age = int.Parse(txtAge.Text);
                updatedDog.BreedId = (int)cmbBreed.SelectedValue;

                dogsController.Update(findId, updatedDog);
            }
            btnSelectAll_Click(sender, e);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
