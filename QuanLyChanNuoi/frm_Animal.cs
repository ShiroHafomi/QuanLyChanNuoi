﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyChanNuoi
{
    public partial class frm_Animal: Form
    {
        public frm_Animal()
        {
            InitializeComponent();
        }
        LOPDUNGCHUNG lopchung  = new LOPDUNGCHUNG();
        private void frm_Animal_Load(object sender, EventArgs e)
        {
            LoadAnimal();
            LoadPen();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(Weight.Text, out float weight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return;
            }
            string gender = radioButton_Male.Checked ? "Male" : "Female";
            string sql = "INSERT INTO Animal(Name, Species, Breed, Gender, Weight, PenID) " +"VALUES('" + Name_Text.Text + "','" + Species_Text.Text + "','" + Breed.Text + "','" + gender + "','" + Weight.Text + "','" + cmb_PenID.Text + "')";
            int kq = lopchung.ChucNang(sql);
            if (kq > 0)
            {
                MessageBox.Show("Add Success");
            }
            else
            {
                MessageBox.Show("Add Failed");
            }
        }


        private void radioButton_Male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button_update_Click(object sender, EventArgs e)
        {
            if (!float.TryParse(Weight.Text, out float weight))
            {
                MessageBox.Show("Weight must be a valid number.");
                return;
            }
            string gender = radioButton_Male.Checked ? "Male" : "Female";
            string sql = "UPDATE Animal SET Name = '" + Name_Text.Text + "', Species = '" + Species_Text.Text + "', Breed = '" + Breed.Text + "',Gender = '" + gender + "',Weight = '"+ Weight.Text + "', PenID = '"+ cmb_PenID.Text + "'WHERE AnimalID = '" + AnimalID_Text.Text + "'";
            int kq = lopchung.ChucNang(sql);
            if (kq > 0)
            {
                MessageBox.Show("Update Success");
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
            LoadAnimal();
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Animal WHERE AnimalID = '" + AnimalID_Text.Text + "'";
            int kq = lopchung.ChucNang(sql);
            if (kq > 0)
            {
                MessageBox.Show("Delete Success");
            }
            else
            {
                MessageBox.Show("Delete Failed");
            }
            LoadAnimal();
        }
        public void LoadAnimal()
        {
            string sql = "SELECT * from Animal";
            dataGridView1.DataSource = lopchung.LayDLBang(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            AnimalID_Text.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            Name_Text.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            Species_Text.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            Breed.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            Weight.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            cmb_PenID.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();

        }
        public void LoadPen()
        {
            string querryLoad_Pen = "SELECT * FROM Pen";
            cmb_PenID.DataSource = lopchung.LayDLBang(querryLoad_Pen);
            cmb_PenID.DisplayMember = "PenName";
            cmb_PenID.ValueMember = "PenID";
        }

        private void Cmb_PenID_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btn_Menu_Click(object sender, EventArgs e)
        {

        }
    }
}
