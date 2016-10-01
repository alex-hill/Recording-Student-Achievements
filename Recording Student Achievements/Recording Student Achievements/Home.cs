﻿using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace Recording_Student_Achievements
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            ns = new NewStudent();
            ws = new WithdrawStudent();
            ir = new IndividualReport();
            uc = new UpdateCalculations();
            sa = new StudentAchievement();
            da = new DeleteAll();
            ut = new UpdateTeachers();
        }


        private NewStudent ns;
        private void label6_Click(object sender, EventArgs e)
        {
            if (!ns.Visible && !ns.IsDisposed)
            {
                // Add the message
                ns.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ns.IsDisposed)
            {
                ns = new NewStudent();
                ns.Show();
            }
        }

        private WithdrawStudent ws;
        private void withdrawStudentLbl_Click(object sender, EventArgs e)
        {
            if (!ws.Visible && !ws.IsDisposed)
            {
                // Add the message
                ws.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ws.IsDisposed)
            {
                ws = new WithdrawStudent();
                ws.Show();
            }
        }

        private void withdrawAllStudentLbl_Click(object sender, EventArgs e)
        {
            if (!ws.Visible && !ws.IsDisposed)
            {
                // Add the message
                ws.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ws.IsDisposed)
            {
                ws = new WithdrawStudent();
                ws.Show();
            }
        }
        private IndividualReport ir;
        private void singleReportLbl_Click(object sender, EventArgs e)
        {
            if (!ir.Visible && !ir.IsDisposed)
            {
                ir.Show();
            }

            // Can now add more than one student (previously crashed if tried to add another student)
            if (ir.IsDisposed)
            {
                ir = new IndividualReport();
                ir.Show();
            }
        }
        private UpdateCalculations uc;
        private void updateDatabaseLbl_Click(object sender, EventArgs e)
        {
            if (!uc.Visible && !uc.IsDisposed)
            {
                // Add the message
                uc.Show();
            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (uc.IsDisposed)
            {
                uc = new UpdateCalculations();
                uc.Show();
            }
        }

        private StudentAchievement sa;
        private void geekItLbl_Click(object sender, EventArgs e)
        {

            sa = new StudentAchievement();
            if (!sa.Visible && !sa.IsDisposed)
            {
                // Add the message
                sa.Show();

            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (sa.IsDisposed)
            {
                sa = new StudentAchievement();
                sa.Show();
            }
            Visible = false;
            sa.geekLbl_Click(sender, e);

        }

        private void addAssessmentLbl_Click(object sender, EventArgs e)
        {
            /*
             * 
             */
        }

        private DeleteAll da;
        private void deleteAll_Click(object sender, EventArgs e)
        {

            if (!da.Visible && !da.IsDisposed)
            {
                // Add the mesdage
                da.Show();


            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (da.IsDisposed)
            {
                da = new DeleteAll();
                da.Show();
            }
        }



        private UpdateTeachers ut;
        private void updateTeachersLbl_Click(object sender, EventArgs e)
        {

            if (!ut.Visible && !ut.IsDisposed)
            {
                // Add the mesutge
                ut.Show();


            }
            // Can now add more than one student (previously crashed if tried to add another student)
            if (ut.IsDisposed)
            {
                ut = new UpdateTeachers();
                ut.Show();
            }
        }

        private void readingVennLbl_Click(object sender, EventArgs e)
        {
            VennDiagram.makeVenn();
        }
    }
}
