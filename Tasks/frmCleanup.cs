﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
namespace Tasks
{
    public partial class frmCleanup : Form
    {
        public frmCleanup()

        {
            InitializeComponent();


        }
        [DllImport("Shell32.dll")]
        static extern int SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlag dwFlags);
        enum RecycleFlag : int

        {

            SHERB_NOCONFIRMATION = 0x00000001, // No confirmation, when emptying
            SHERB_NOPROGRESSUI = 0x00000001, // No progress tracking window during the emptying of the recycle bin
            SHERB_NOSOUND = 0x00000004 // No sound when the emptying of the recycle bin is complete

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false & checkBox2.Checked == false & checkBox4.Checked == false & checkBox3.Checked == false)
            {
                taskDialog1.Show();
                listBox1.Items.Add("Error: Did not select anything to clean.");
            }
            listBox1.Items.Add("Cleanup Started.");


            if (checkBox1.Checked == true)
            {
                SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlag.SHERB_NOSOUND | RecycleFlag.SHERB_NOCONFIRMATION);
                listBox1.Items.Add("Recycle Bin Cleaned.");


            }

            if (checkBox2.Checked == true)
            {
                try
                {

                    string dir = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile)) + "\\Downloads";
                    foreach (var file in Directory.GetFiles(dir.ToString()))
                    {
                        File.Delete(file);
                        listBox1.Items.Add("Deleted " + file);
                    }
                    listBox1.Items.Add("Downloads Folder Cleaned.");
                }
                catch (IOException Ex)
                {

                    Console.WriteLine(
                        "Unable to delete this file, it is currently in use by the system. Exception: " +
                        Ex.GetType().Name);
                }



                if (checkBox3.Checked == true)
                {
                    try
                    {
                        var dir = new DirectoryInfo("C:\\Windows\\Temp");
                        foreach (var file in Directory.GetFiles(dir.ToString()))
                        {
                            File.Delete(file);
                            listBox1.Items.Add("Deleted " + file);
                        }
                        listBox1.Items.Add("Temp Files Cleaned.");
                    }


                    catch (IOException Ex)
                    {

                        listBox1.Items.Add(
                            "Unable to delete this file, it is currently in use by the system. Exception: " +
                            Ex.GetType().Name);
                    }

                    try
                    {
                        var dir2 = new DirectoryInfo(Path.GetTempPath());
                        foreach (var file2 in Directory.GetFiles(dir2.ToString()))
                        {
                            File.Delete(file2);
                            listBox1.Items.Add("Deleted " + file2);
                        }
                    }
                    catch (IOException Ex)
                    {

                        listBox1.Items.Add(
                            "Unable to delete this file, it is currently in use by the system. Exception: " +
                            Ex.GetType().Name);
                    }


                }
            }

            if (checkBox4.Checked == true)
            {
                try
                {
                    var dir = new DirectoryInfo("C:\\Windows\\Prefetch");
                    foreach (var file in Directory.GetFiles(dir.ToString()))
                    {
                        File.Delete(file);
                        listBox1.Items.Add("Deleted " + file);
                    }
                    listBox1.Items.Add("Prefetch Cleaned.");

                }
                catch (IOException Ex)
                {

                    Console.WriteLine(
                        "Unable to delete this file, it is currently in use by the system. Exception: " +
                        Ex.GetType().Name);
                }

                catch (System.UnauthorizedAccessException Ex)
                {

                    listBox1.Items.Add(
                        "Unable to delete this file, you are not allowed to delete this file. Exception: " +
                        Ex.GetType().Name);
                }


               
            }
        }

    }
    }
    

