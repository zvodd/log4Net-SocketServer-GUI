﻿namespace CSRemoteLog4net
{
    partial class MainWin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            inputServerAddr = new TextBox();
            butStartServer = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            // 
            // inputServerAddr
            // 
            inputServerAddr.Location = new Point(518, 12);
            inputServerAddr.Name = "inputServerAddr";
            inputServerAddr.Size = new Size(100, 23);
            inputServerAddr.TabIndex = 0;
            inputServerAddr.Text = "127.0.0.1:8080";
            // 
            // butStartServer
            // 
            butStartServer.Location = new Point(624, 12);
            butStartServer.Name = "butStartServer";
            butStartServer.Size = new Size(75, 23);
            butStartServer.TabIndex = 1;
            butStartServer.Text = "Start";
            butStartServer.UseVisualStyleBackColor = true;
            butStartServer.Click += ButStartServer_Click;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 12);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(405, 424);
            listBox1.TabIndex = 2;
            // 
            // MainWin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBox1);
            Controls.Add(butStartServer);
            Controls.Add(inputServerAddr);
            Name = "MainWin";
            Text = "MainWin";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox inputServerAddr;
        private Button butStartServer;
        private ListBox listBox1;
    }
}
