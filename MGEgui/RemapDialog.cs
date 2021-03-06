using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SlimDX.RawInput;
using SlimDX.Multimedia;



namespace MGEgui {
    public class RemapDialog : Form {
        #region Form designer gunk
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
        	this.bCancel = new System.Windows.Forms.Button();
        	this.bClear = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// bCancel
        	// 
        	this.bCancel.Location = new System.Drawing.Point(12, 12);
        	this.bCancel.Name = "bCancel";
        	this.bCancel.Size = new System.Drawing.Size(60, 23);
        	this.bCancel.TabIndex = 0;
        	this.bCancel.Text = "Cancel";
        	this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
        	// 
        	// bClear
        	// 
        	this.bClear.Location = new System.Drawing.Point(78, 12);
        	this.bClear.Name = "bClear";
        	this.bClear.Size = new System.Drawing.Size(60, 23);
        	this.bClear.TabIndex = 1;
        	this.bClear.Text = "Clear";
        	this.bClear.Click += new System.EventHandler(this.bClear_Click);
        	// 
        	// RemapDialog
        	// 
        	this.ClientSize = new System.Drawing.Size(154, 47);
        	this.ControlBox = false;
        	this.Controls.Add(this.bClear);
        	this.Controls.Add(this.bCancel);
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "RemapDialog";
        	this.ShowInTaskbar = false;
        	this.Text = "Please hit a key";
        	this.TopMost = true;
        	this.Load += new System.EventHandler(this.RemapDialog_Load);
        	this.Closing += new System.ComponentModel.CancelEventHandler(this.RemapDialog_FormClosing);
        	this.ResumeLayout(false);
        }

        #endregion

        private Button bCancel;
        private Button bClear;
        #endregion
        
        public byte result;

        public RemapDialog() {
            InitializeComponent();
            DialogResult=DialogResult.Cancel;
        }

        private void bCancel_Click(object sender, EventArgs e) {
            DialogResult=DialogResult.Cancel;
            Close();
        }

        private void bClear_Click(object sender, EventArgs e) {
            DialogResult=DialogResult.OK;
            result=0;
            Close();
        }

        private void remap_input(object sender, KeyboardInputEventArgs e) {
            result = (byte)e.MakeCode;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void RemapDialog_FormClosing(object sender, CancelEventArgs e) {
        }

        private void RemapDialog_Load(object sender, EventArgs e) {
            Device.RegisterDevice(UsagePage.Generic, UsageId.Keyboard, DeviceFlags.None);
            Device.KeyboardInput += remap_input;
        }
    }
}
