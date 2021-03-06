﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Recording_Student_Achievements
{
    public partial class NewStudent : Form
    {
        private OleDbConnection conn = new OleDbConnection();
        public NewStudent()
        {
            InitializeComponent();
            string path = "C:\\Users\\Public\\Desktop\\";

            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Table.accdb;Persist Security Info=False;"; //For not Alex's laptop
            //conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Table.mdb;Persist Security Info=True"; //For Alex's laptop
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //OleDbCommand cmd = new OleDbCommand("INSERT INTO Student ([Family Name Alias], [Family Name Legal], [First Name Legal], [Preferred Name], [Year Level], [Room Number], [Gender], [Date of Birth], [Ethnicity], [NSN], [Funding Year Level], [Start Date])"
            //    + " VALUES(" + familyNameAlias.Text + ", " + familyNameLegal.Text + ", [" + firstNameLegal.Text + "], " + preferredName.Text + ", " + yearLevelCombo.Text + ", " + roomCombo.Text
            //        + ", " + genderCombo.Text + ", '" + dateOfBirth.Text + "', " + ethnicityCombo.Text + ", " + nsn.Text + ", " + fundingLevelCombo.Text + ", '" + startDate.Text + "');");
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandType = CommandType.Text;
           
            cmd.Connection = conn;

            Console.WriteLine(familyNameAlias.Text + ", " + familyNameLegal.Text + ", [" + firstNameLegal.Text + "], " + preferredName.Text + ", " + yearLevelCombo.Text + ", " + roomCombo.Text
                    + ", " + genderCombo.Text + ", '" + dateOfBirth.Text + "', " + ethnicityCombo.Text + ", " + nsn.Text + ", " + fundingLevelCombo.Text + ", '" + startDate.Text + "');");

            try
            {
                

                //if (conn.State == ConnectionState.Open)
               // {
                    cmd.Parameters.Add("@Family Name Alias", OleDbType.VarChar).Value = familyNameAlias.Text;
                    cmd.Parameters.Add("@Family Name Legal", OleDbType.VarChar).Value = familyNameLegal.Text;
                    cmd.Parameters.Add("@First Name Legal", OleDbType.VarChar).Value = firstNameLegal.Text;
                    cmd.Parameters.Add("@Preferred Name", OleDbType.VarChar).Value = preferredName.Text;
                    cmd.Parameters.Add("@Year Level", OleDbType.VarChar).Value = yearLevelCombo.Text;
                    cmd.Parameters.Add("@Room Number", OleDbType.VarChar).Value = roomCombo.Text;
                    cmd.Parameters.Add("@Gender", OleDbType.VarChar).Value = genderCombo.Text;
                    cmd.Parameters.Add("@Date Of Birth", OleDbType.VarChar).Value = dateOfBirth.Text;
                    cmd.Parameters.Add("@Ethnicity", OleDbType.VarChar).Value = ethnicityCombo.Text;
                    cmd.Parameters.Add("@NSN", OleDbType.VarChar).Value = nsn.Text;
                    cmd.Parameters.Add("@Funding Year Level", OleDbType.VarChar).Value = fundingLevelCombo.Text;
                    cmd.Parameters.Add("@Start Date", OleDbType.VarChar).Value = startDate.Text;

                    cmd.CommandText = "INSERT INTO Student ([Family Name Alias], [Family Name Legal], [First Name Legal], [Preferred Name], [Year Level], [Room Number], [Gender], [Date of Birth], [Ethnicity], [NSN], [Funding Year Level], [Start Date])"
              + " VALUES([@Family Name Alias],  [@Family Name Legal] , [@First Name Legal], [@Preferred Name], [@Year Level], [@Room Number], [@Gender], [@Date Of Birth], [@Ethnicity], [@NSN], [@Funding Year Level], [@Start Date]);";
                    conn.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Added");
                    conn.Close();
               // }
               // else
                //{
                  //  MessageBox.Show("Connection Failed");
               // }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
            }



            this.Close();
        }
    }
}