using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                FileInfo[] files = di2.GetFiles("*.mb");
                foreach (FileInfo file in files)
                {
                    DirectoryInfo di3 = new DirectoryInfo(di2.FullName + "\\" + file.Name.Replace(".mb", ""));
                    if (!di3.Exists)
                    {
                        di3.Create();
                    }
                    FileInfo[] fbxfiles = di3.GetFiles();
                    if (fbxfiles.Length == 0)
                    {
                        sb.Append("file - f - options \"v=0;\" - ignoreVersion - typ \"mayaBinary\" - o \"" + file.FullName.Replace("\\", "/") + "\";\n");
                        sb.Append("setAttr \"defaultRenderGlobals.imageFormat\" 32;\nsetAttr defaultRenderGlobals.animation 1;\nselect -r Cam143 ;\nselectKey - clear ;\nsetAttr \"Cam143.scaleX\" 0.06559;\nsetAttr \"Cam143.scaleY\" 0.06559;\nsetAttr \"Cam143.scaleZ\" 0.06559;\nselect - r CamCube143;\nselectKey - clear;\nsetAttr \"CamCube143.translateY\" 250;\nsetAttr \"CamCube143.translateZ\" 250;\nsetAttr \"CamCube143.scaleX\" 15.24667;\nsetAttr \"CamCube143.scaleY\" 15.24667;\nsetAttr \"CamCube143.scaleZ\" 15.24667;\nsetAttr \"CamCube143.rotatePivotY\" - 250;\nsetAttr \"CamCube143.rotatePivotZ\" - 250;\nsetAttr \"CamCube143.scalePivotY\" - 16.39702;\nsetAttr \"CamCube143.scalePivotZ\" - 16.39702;\nsetAttr \"CamCube143.scalePivotTranslateY\" - 233.60298;\nsetAttr \"CamCube143.scalePivotTranslateZ\" - 233.60298;\nfile - save;");
                        string filename = file.FullName.Replace(".mb", "").Replace("\\", "/");
                        string action = filename.Substring(filename.LastIndexOf("/") + 1);
                        if (action.IndexOf("Still") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Hold";
                            action = "Hold";
                        }
                        if (action.IndexOf("Hold") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Hold";
                            action = "Hold";
                        }
                        if (action.IndexOf("Attack") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Attack";
                            action = "Attack";
                        }
                        if (action.IndexOf("Dying") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Death";
                            action = "Death";
                        }
                        if (action.IndexOf("Death") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Death";
                            action = "Death";
                        }
                        if (action.IndexOf("Walk") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Walk";
                            action = "Walk";
                        }
                        if (action.IndexOf("Mov") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Walk";
                            action = "Walk";
                        }
                        if (action.IndexOf("Stun") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Stun";
                            action = "Stun";
                        }
                        if (action.IndexOf("Cast") >= 0)
                        {
                            filename = filename.Substring(0, filename.LastIndexOf("/")) + "/Cast";
                            action = "Cast";
                        }
                        DirectoryInfo diaction = new DirectoryInfo(filename);
                        if (!diaction.Exists)
                        {
                            diaction.Create();
                        }
                        string monstername = di2.Name.Replace("_Animation", "");
                        string destfilename = filename + "/" + monstername + "_" + action;
                        string destfilenamewithmbext = destfilename + ".mb";
                        sb.Append("setAttr \"CamCube143.rotateY\" 0;\nsetAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_South_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_South.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 45;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_SouthWest_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_SouthWest.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 90;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_West_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_West.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 135;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_NorthWest_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_NorthWest.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 180;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_North_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_North.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 225;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_NorthEast_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_NorthEast.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 270;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_East_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_East.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n" +
                        "setAttr \"CamCube143.rotateY\" 315;\n" +
                        "setAttr - type \"string\" defaultRenderGlobals.imageFilePrefix \"" + monstername + "_SouthEast_" + action + "\";\n" +
                        "file - rename \"" + destfilename + "_SouthEast.mb\";\n" +
                        "file - save - type \"mayaBinary\";\n");
                    }
                }
            }
            Clipboard.SetText(sb.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                if (di2.Name.IndexOf("Attack") >= 0 || di2.Name.IndexOf("Cast") >= 0 || di2.Name.IndexOf("Death") >= 0 || di2.Name.IndexOf("Stun") >= 0 || di2.Name.IndexOf("Walk") >= 0 || di2.Name.IndexOf("Hold") >= 0)
                {
                    di2.Delete();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                foreach (DirectoryInfo di3 in di2.GetDirectories())
                {
                    label1.Text = "Currently processing directory:: " + di3.FullName;
                    if (di3.Name == "Attack" || di3.Name == "Cast" || di3.Name == "Death" || di3.Name == "Stun" || di3.Name == "Walk" || di3.Name == "Hold")
                    {
                        FileInfo[] files = di3.GetFiles("*.mb");
                        foreach (FileInfo file in files)
                        {
                            //MayaFilesToRender
                            file.CopyTo("H:\\MayaFilesToRender\\" + file.Name);
                        }
                        DirectoryInfo di4 = new DirectoryInfo(di3.FullName + "\\Images");
                        if (!di4.Exists)
                        {
                            di4.Create();
                        }
                        if (di4.GetFiles().Length == 0)
                        {
                            Application.DoEvents();
                            ExecuteCommand("\"H:\\My Documents\\MayaFiles\\render.bat\"");
                            DirectoryInfo di5 = new DirectoryInfo(@"C:\Users\akshay\Documents\maya\projects\default\images");
                            foreach (FileInfo file2 in di5.GetFiles())
                            {
                                file2.MoveTo(di4.FullName + "\\" + file2.Name);
                            }
                            foreach (FileInfo file4 in di5.GetFiles())
                            {
                                file4.Delete();
                            }
                        }
                        DirectoryInfo di6 = new DirectoryInfo("H:\\MayaFilesToRender\\");
                        foreach (FileInfo file3 in di6.GetFiles())
                        {
                            file3.Delete();
                        }
                    }
                }
            }
        }

        static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = true;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = false;
            processInfo.RedirectStandardOutput = false;
            processInfo.CreateNoWindow = true;
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;

            process = Process.Start(processInfo);
            process.WaitForExit();

            exitCode = process.ExitCode;

            process.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles\\Slime_Animation");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                DirectoryInfo di3 = new DirectoryInfo(di2.FullName + "/FBX");
                if (!di3.Exists)
                {
                    di3.Create();
                }
                FileInfo[] files = di2.GetFiles("*.mb");
                FileInfo[] fbxfiles = di3.GetFiles();
                foreach (FileInfo file in files)
                {
                    if (fbxfiles.Length > 0)
                    {
                        foreach (FileInfo fbxfile in fbxfiles)
                        {
                            if (file.Name.Replace(".mb", ".fbx") != fbxfile.Name)
                            {
                                sb.Append("file - f - options \"v=0;\" - ignoreVersion - typ \"mayaBinary\" - o \"" + file.FullName.Replace("\\", "/") + "\";\n");
                                string filename = file.FullName.Replace(".mb", ".fbx").Replace("\\", "/");
                                filename = filename.Insert(filename.LastIndexOf("/") + 1, "FBX/");
                                sb.Append("file -force -options \"v = 0; \" -type \"FBX export\" -pr -ea \"" + filename + "\";\n");
                            }
                        }
                    }
                    else
                    {
                        sb.Append("file - f - options \"v=0;\" - ignoreVersion - typ \"mayaBinary\" - o \"" + file.FullName.Replace("\\", "/") + "\";\n");
                        string filename = file.FullName.Replace(".mb", ".fbx").Replace("\\", "/");
                        filename = filename.Insert(filename.LastIndexOf("/") + 1, "FBX/");
                        sb.Append("file -force -options \"v = 0; \" -type \"FBX export\" -pr -ea \"" + filename + "\";\n");
                    }
                }
            }
            Clipboard.SetText(sb.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                foreach (DirectoryInfo di3 in di2.GetDirectories())
                {
                    foreach (FileInfo file in di3.GetFiles("*.mb"))
                    {
                        file.Delete();
                    }
                    DirectoryInfo di4 = new DirectoryInfo(di3.FullName + "\\Images");
                    if (di4.Exists)
                    {
                        foreach (FileInfo file1 in di4.GetFiles())
                        {
                            file1.Delete();
                        }
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                foreach (DirectoryInfo di3 in di2.GetDirectories())
                {
                    if (di3.GetFiles("*.mb").Length > 0)
                    {
                        FileInfo file = di3.GetFiles("*.mb")[0];
                        string filename = string.Empty;
                        if (file.Name.IndexOf("Attack") >= 0)
                        {
                            filename = di2.FullName + "\\Attack.mb";
                        }
                        else if (file.Name.IndexOf("Cast") >= 0)
                        {
                            filename = di2.FullName + "\\Cast.mb";
                        }
                        else if (file.Name.IndexOf("Death") >= 0)
                        {
                            filename = di2.FullName + "\\Death.mb";
                        }
                        else if (file.Name.IndexOf("Hold") >= 0)
                        {
                            filename = di2.FullName + "\\Hold.mb";
                        }
                        else if (file.Name.IndexOf("Walk") >= 0)
                        {
                            filename = di2.FullName + "\\Walk.mb";
                        }
                        else if (file.Name.IndexOf("Stun") >= 0)
                        {
                            filename = di2.FullName + "\\Stun.mb";
                        }
                        file.CopyTo(filename);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                foreach (DirectoryInfo di3 in di2.GetDirectories())
                {
                    DirectoryInfo di4 = new DirectoryInfo(di3.FullName + "\\Images");
                    if (di4.Exists)
                    {
                        foreach (FileInfo file1 in di4.GetFiles())
                        {
                            file1.Delete();
                        }
                    }
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("H:\\My Documents\\MayaFiles");
            foreach (DirectoryInfo di2 in di.GetDirectories())
            {
                foreach (DirectoryInfo di3 in di2.GetDirectories())
                {
                    DirectoryInfo[] dis = di3.GetDirectories();
                    if(dis.Length > 0 && dis[0].Name == "Images")
                    {
                        foreach(FileInfo file in dis[0].GetFiles())
                        {
                            if(file.Name.LastIndexOf(".") == -1)
                            {
                                file.MoveTo(file.FullName + ".png");
                            }
                        }
                    }
                }
            }
        }
    }
}